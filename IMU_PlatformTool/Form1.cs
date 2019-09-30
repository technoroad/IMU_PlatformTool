using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MY.SerialPortList;
using System.Globalization;
using System.IO;
using System.Threading;
using IMU_PlatformTool.Properties;

/*
The MIT License (MIT)

Copyright (c) 2019 Techno Road Inc.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

namespace ADIS16XXX_plot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int SAMPLING_CNT = 100;

        PlotModel myPlotModel = new PlotModel(); //PlotModelの生成
        List<LineSeries> lines = new List<LineSeries>();
        string csv_format = "";
        const string FilePath = @"csv\";

        StreamWriter LogFile;

        private void Form1_Load(object sender, EventArgs e)
        {
            //UI操作無効化
            panel1.Enabled = false;
            this.tabControl1.TabPages.Remove(this.tabPage2);

            // すべてのシリアル・ポート名を取得する
            String[] ports = System.IO.Ports.SerialPort.GetPortNames();
            // 取得したシリアル・ポート名を出力する
            foreach (String s in ports)
            {
                comGimPort.Items.Add(s);
            }

            //最後のを選択する
            //	comGimPort->SelectedIndex = comGimPort->Items->Count-1;

            //ターゲットデバイス名取得
            SerialPortList sp = new SerialPortList();
            String target_name = sp.GetComFromDevName("STMicro");
            //該当を選択
            foreach (String s in ports)
            {
                if (s == target_name)
                {
                    comGimPort.SelectedItem = s;
                    break;
                }
            }

            ComPortNameLabel.Text = sp.GetDevNameFromCom((string)comGimPort.SelectedItem);

            myPlotModel.DefaultColors = new List<OxyColor>
            {
                OxyColors.Red,
                OxyColors.Green,
                OxyColors.Blue,
                OxyColor.FromRgb(0x20, 0x4A, 0x87)
            };

            SAMPLING_CNT = int.Parse("" + sampling_val.Value) - 1;

            myPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = 0, Maximum = SAMPLING_CNT,MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot }); //x軸の設定 sampling_val
            myPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -double.Parse("" + yAxe_val.Value), Maximum = double.Parse("" + yAxe_val.Value), MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot }); // y軸の設定

            plotView1.Model = myPlotModel;

        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (ComSearchFlg)
            {
                Disconnect();
                ComSearchFlg = false;
                return;
            }

            if (IsCpmmected ==false)
            {
                Connect((string)comGimPort.SelectedItem, 9600);

                if (IsCpmmected)
                {
                    for (int i = 0; i < lines.Count; i++)
                    {
                        lines[i].Points.Clear();
                    }

                    //Debug.WriteLine("接続成功");
                    timSerial.Start();//通信状態自動監視開始
                    panel1.Enabled = true;
                    btnConnect.Text = Resources.Disconnecting_Str;
                    ViewUpdateTimer.Start();
                    fps_counter.Start();

                    Send("\r\n");
                    Send("stop\r\n");
                    Send("GET_STATUS\r\n");
                    Send("DUMP_PARAM\r\n");
                    Send("GET_PROD_ID\r\n");
                    Send("GET_BOARD_NAME\r\n");
                    Send("GET_FORMAT\r\n");
                    Send("GET_VERSION\r\n");
                }
                else
                {
                    Debug.WriteLine("接続失敗");
                }
            }
            else
            {
                Disconnect();
            }
        }

        void Connect(string comname, int baud)
        {
            if (comname == null)
            {
                return;
            }
            try
            {
                serialPort1.BaudRate = baud;      //ボーレート
                serialPort1.PortName = comname;   //ポート名
                serialPort1.DataBits = 8;                        //データビット8ビットを設定
                serialPort1.ReadTimeout = 1000;//time out
                serialPort1.WriteTimeout = 1000;//time out
                serialPort1.Open();

                return;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                //error
                return;
            }
        }

        void Disconnect()
        {
            timSerial.Stop();
            panel1.Enabled = false;
            btnConnect.Text = Resources.Connecting_Str;
            StatusLabel.Text = Resources.Disconnected_Str;
            Send("stop\r\n");
            fps_counter.Stop();
            serial_count = 0;
            //ViewUpdateTimer.Stop();

            try
            {
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        bool IsCpmmected
        {
            get
            {
                if (serialPort1 == null)
                {
                    return false;
                }
                if (serialPort1.IsOpen)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Send(string msg)
        {
            if (!IsCpmmected) return;
            byte[] data = System.Text.Encoding.ASCII.GetBytes(msg);

            serialPort1.Write(data, 0, data.Length);
        }

        List<string> RecvPacket = new List<string>();

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort1.BytesToRead == 0)
                {
                    return;
                }

                if (!serialPort1.IsOpen)
                {
                    return;
                }

                string text = serialPort1.ReadLine();

                do
                {
                    RecvPacket.Add(text);
                    text = serialPort1.ReadLine();
                } while (text != "");
                
            }
            catch(Exception e5)
            {

            }

        }

        bool ComSearchFlg = false;
        bool ComRecoveryFlg = false;

        private void timSerial_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (ComRecoveryFlg)
                {
                    ComRecoveryFlg = false;

                    for (int i = 0; i < lines.Count; i++)
                    {
                        lines[i].Points.Clear();
                    }

                    //Debug.WriteLine("接続成功");
                    timSerial.Start();//通信状態自動監視開始
                    panel1.Enabled = true;
                    btnConnect.Text = Resources.Disconnecting_Str;
                    ViewUpdateTimer.Start();
                    fps_counter.Start();

                    Send("\r\n");
                    Send("stop\r\n");
                    Send("GET_STATUS\r\n");
                    Send("DUMP_PARAM\r\n");
                    Send("GET_PROD_ID\r\n");
                    Send("GET_BOARD_NAME\r\n");
                    Send("GET_FORMAT\r\n");
                    Send("GET_VERSION\r\n");
                }
            }
            else
            {
                ComSearchFlg = true;
                StatusLabel.Text = Resources.ComSearch_Str;
                StatusUpdateTimer.Stop();
                StartBtn.Enabled = false;
                StopBtn.Enabled = false;
                Connect((String)comGimPort.SelectedItem, 115200);
                //Connect((String)comGimPort.SelectedItem, 19200);
                if (IsCpmmected)
                {
                    ComRecoveryFlg = true;
                    ComSearchFlg = false;
                    Debug.WriteLine("ReConeected");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (LogFile != null)
                {
                    LogFile.Close();
                    LogFile = null;
                }
                Send("stop\r\n");
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void max_val_ValueChanged(object sender, EventArgs e)
        {
            myPlotModel.Axes[1].Minimum = -double.Parse("" + yAxe_val.Value);
            myPlotModel.Axes[1].Maximum = double.Parse("" + yAxe_val.Value);
            myPlotModel.InvalidatePlot(true); // -- (3) , ここで軸設定が反映され、PlotViewが更新される
        }

        private void sampling_val_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Points.Clear();
            }

            SAMPLING_CNT = int.Parse("" + sampling_val.Value) - 1;
            myPlotModel.Axes[0].Minimum = 0;
            myPlotModel.Axes[0].Maximum = SAMPLING_CNT;
            myPlotModel.InvalidatePlot(true); // -- (3) , ここで軸設定が反映され、PlotViewが更新される
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Send("START_BIAS_CORRECTION\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            Send("PAGE_DUMP,0\r\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            Send("PAGE_DUMP,1\r\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            Send("PAGE_DUMP,2\r\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            Send("PAGE_DUMP,3\r\n");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Send("WRITE_REG,0x03,0x0E,0x3F0A\r\n");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Send("WRITE_REG,0x03,0x0E,0x070A\r\n");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Send("READ_TEMP\r\n");
        }

        int serial_count = 0;

        private void fps_counter_Tick(object sender, EventArgs e)
        {
            fps_label.Text = serial_count + "";
            serial_count = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string buf = "SET_KP_KI," + Kp_val.Value + "," + Ki_val.Value + "\r\n";
            Send(buf);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string buf = "RESET_FILTER\r\n" ;
            Send(buf);
        }

        public static DirectoryInfo SafeCreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return null;
            }
            return Directory.CreateDirectory(path);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            lines.Clear();
            myPlotModel.Series.Clear();

            Send("GET_SENSI\r\n");
            Send("DUMP_PARAM\r\n");
            Send("GET_FORMAT\r\n");
            Send("start\r\n");
            Send("GET_STATUS\r\n");

            if(LogFile != null)
            {
                LogFile.Close();
                LogFile = null;
            }
            SafeCreateDirectory(FilePath);
            SafeCreateDirectory(FilePath+ DateTime.Now.ToString("yyyyMMdd"));
            LogFile = new StreamWriter(FilePath+ DateTime.Now.ToString("yyyyMMdd")+"/" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv", false, Encoding.GetEncoding("UTF-8"));

            if(LogFile != null)
            {
                LogFile.WriteLine(
                    "#Sensor="+ ProductIdLabel.Text+","+
                    "Board_Name=" + BoardNameLabel.Text + "," +
                    "Send_Cycle=" +SendCycleNum.Value+"ms,"+
                    "Kp=" + Kp_val.Value+","+
                    "Ki=" + Ki_val.Value + "," +
                    "Startup_Time=" + StartupTimeNum.Value + "s," +
                    "Firmware_Version=" + VersionLabel.Text+"\r\n"+
                    csv_format
                    );
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            if (LogFile != null)
            {
                LogFile.Close();
                LogFile = null;
            }
            Send("stop\r\n");
            Send("GET_STATUS\r\n");
        }

        double Gyro_Sensi = 0;
        double Acc_Sensi = 0;

        private void text_parser(string text)
        {
            try
            {
                text = text.Replace("\r", "");
                string[] split_str = text.Split(',');

                //描画タスク
                BeginInvoke((Action)delegate ()
                {
                    UInt32 r;
                    double d;
                    if (!double.TryParse(split_str[0], out d) && !UInt32.TryParse(split_str[0], NumberStyles.AllowHexSpecifier, new CultureInfo("en-US"), out r))
                    {
                        if (split_str[0].Equals("READ_TEMP"))
                        {
                            TempLabel.Text = double.Parse(split_str[1]).ToString("F3") + "℃";
                        }
                        else if (split_str[0].Equals("PAGE_DUMP"))
                        {
                            int j = 0;
                            for (int i = 2; i < split_str.Length; i++)
                            {
                                this.dataGridView1.Rows.Add(new Object[] {
                                            split_str[1], "0x"+j.ToString("X2"), split_str[i]
                            });
                                j += 2;
                            }
                        }
                        else if (split_str[0].StartsWith("ERROR") || split_str[0].StartsWith("ERR"))
                        {
                            if (split_str[0].StartsWith("ERROR_PRODUCT_ID_INCORRECT"))
                            {
                                Disconnect();

                                DialogResult result = MessageBox.Show(Resources.Sens_Inco_Str,
                                    Resources.Error_Str,
                                    MessageBoxButtons.OK);
                            }
                            else if (split_str[0].Equals("ERR_NONE_CMD") || split_str[0].Equals("ERROR_NONE_CMD"))
                            {
                                if (split_str[1].Equals("DUMP_PARAM"))
                                {
                                    Disconnect();

                                    DialogResult result = MessageBox.Show(Resources.Old_firm_Str,
                                        Resources.Error_Str,
                                        MessageBoxButtons.OK);
                                }
                            }
                            else if(split_str[0].Equals("ERROR_GET_FORMAT"))
                            {
                                Disconnect();
                                DialogResult result = MessageBox.Show(Resources.Format_Err_Str,
                                    Resources.Error_Str,
                                    MessageBoxButtons.OK);
                            }
                        }
                        else if (split_str[0].Equals("DUMP_PARAM"))
                        {
                            VersionLabel.Text = split_str[1];
                            Kp_val.Value = (decimal)double.Parse(split_str[2]);
                            Ki_val.Value = (decimal)double.Parse(split_str[3]);
                            SendCycleNum.Value = (decimal)double.Parse(split_str[4]);
                            StartupTimeNum.Value = (decimal)double.Parse(split_str[5]);
                        }
                        else if (split_str[0].Equals("GET_FORMAT"))
                        {
                            lines.Clear();
                            myPlotModel.Series.Clear();
                            csv_format = "";

                            for (int i = 0; i < split_str.Length - 1; i++)
                            {
                                LineSeries myLine = new LineSeries();
                                myLine.Title = split_str[i + 1];
                                myPlotModel.Series.Add(myLine);
                                lines.Add(myLine);
                                csv_format += split_str[i + 1] + ",";
                            }
                            Debug.WriteLine("軸数:" + myPlotModel.Series.Count);
                        }
                        else if (split_str[0].Equals("GET_PROD_ID"))
                        {
                            ProductIdLabel.Text = split_str[1];
                        }
                        else if (split_str[0].Equals("GET_SENSI"))
                        {
                            Gyro_Sensi = double.Parse(split_str[1]);
                            Acc_Sensi = double.Parse(split_str[2]);
                        }
                        else if (split_str[0].Equals("SET_SEND_CYCLE"))
                        {
                            SendCycleNum.Value = (decimal)double.Parse(split_str[1]);
                        }
                        else if (split_str[0].Equals("SET_STARTUP_TIME")) 
                        {
                            StartupTimeNum.Value = (decimal)double.Parse(split_str[1]);
                        }
                        else if (split_str[0].Equals("GET_BOARD_NAME")) 
                        {
                            BoardNameLabel.Text = split_str[1];
                        }
                        else if (split_str[0].Equals("GET_VERSION")) 
                        {
                            VersionLabel.Text = split_str[1];
                        }
                        else if (split_str[0].Equals("GET_STATUS")) 
                        {
                            if (split_str[1].Equals("AutoBiasUpdating"))
                            {
                                int time = int.Parse(split_str[2]);
                                StatusLabel.Text = Resources.Bias_Updating_Str + time+ Resources.Sec_Str;
                                StatusUpdateTimer.Start();
                                StartBtn.Enabled = false;
                                StopBtn.Enabled = false;
                            }
                            else if (split_str[1].Equals("Ready"))
                            {
                                StatusLabel.Text = Resources.Ready_Str;
                                StatusUpdateTimer.Stop();
                                StartBtn.Enabled = true;
                                StopBtn.Enabled = false;
                            }
                            else if (split_str[1].Equals("Running"))
                            {
                                StatusLabel.Text = Resources.Running_Str;
                                StatusUpdateTimer.Stop();
                                StartBtn.Enabled = false;
                                StopBtn.Enabled = true;
                            }
                        }
                        else
                        {

                        }

                        TxtLog.AppendText(text+"\r\n");
                    }
                    else
                    {

                        serial_count++;

                        int dat_len = SAMPLING_CNT;//サンプル数(X軸)

                        List<double> dat_list = new List<double>();

                        if (UInt32.TryParse(split_str[0], NumberStyles.AllowHexSpecifier, new CultureInfo("en-US"), out r))
                        {
                            for(int i = 0; i < 3; i++)
                            {
                                UInt32 result;
                                UInt32.TryParse(split_str[i], NumberStyles.AllowHexSpecifier, new CultureInfo("en-US"), out result);

                                dat_list.Add((double)((Int32)result / Gyro_Sensi * Math.PI / 180.0));
                            }
                            for (int i = 3; i < 6; i++)
                            {
                                UInt32 result;
                                UInt32.TryParse(split_str[i], NumberStyles.AllowHexSpecifier, new CultureInfo("en-US"), out result);

                                dat_list.Add((double)((Int32)result *9.80665 / Acc_Sensi));
                            }
                            dat_list.Add(0);    //CSUM
                        }
                        else
                        {
                            for(int i=0;i< split_str.Length; i++)
                            {
                                dat_list.Add(double.Parse(split_str[i]));
                            }
                            
                        }

                        //エラー回避
                        if (lines.Count != dat_list.Count)
                        {
                            return;
                        }



                        //X軸の限界数以下であれば普通に保存する
                        if (lines[0].Points.Count < dat_len)
                        {
                            for (int i = 0; i < dat_list.Count; i++)
                            {
                                lines[i].Points.Add(new OxyPlot.DataPoint(lines[i].Points.Count, dat_list[i]));
                            }
                        }
                        else //X軸の限界数を上回ろうとしたら最後尾のデータを消して先頭に最新データを入れる。
                        {
                            //先頭にデータが格納できるようにデータをズラす
                            for (int i = 1; i < dat_len; i++)
                            {
                                for (int j = 0; j < dat_list.Count; j++)
                                {
                                    lines[j].Points[i - 1] = new OxyPlot.DataPoint(lines[j].Points[i].X - 1, lines[j].Points[i].Y);
                                }
                            }

                            //最後尾のデータを削除して、最新データを入力していく
                            for (int i = 0; i < dat_list.Count; i++)
                            {
                                lines[i].Points.RemoveAt(dat_len - 1);
                                lines[i].Points.Add(new OxyPlot.DataPoint(lines[i].Points.Count, dat_list[i]));
                            }
                        }
                        plotView1.Invalidate(); // --(2) , ここでデータの変更が反映され、PlotViewが更新される
                        myPlotModel.InvalidatePlot(true); // -- (3) , ここで軸設定が反映され、PlotViewが更新される

                        if(LogFile != null)
                        {
                            LogFile.WriteLine(text);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void ViewUpdateTimer_Tick(object sender, EventArgs e)
        {
            while (RecvPacket.Count != 0)
            {
                try
                {
                    string text = RecvPacket[0];
                    RecvPacket.RemoveAt(0);

                    text_parser(text);
                }
                catch (Exception e2)
                {

                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Send("SET_SEND_CYCLE,"+(int)SendCycleNum.Value+ "\r\n");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Resources.Setting_Que_Str,
                Resources.Question_Str,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
            }
            else if (result == DialogResult.No)
            {
                //「いいえ」が選択された時
                return;
            }

            Send("SAVE_PARAM\r\n");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Send("LOAD_INIT\r\n");
            Send("DUMP_PARAM\r\n");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Send("DUMP_PARAM\r\n");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Send("GET_PROD_ID\r\n");
            Send("GET_BOARD_NAME\r\n");
            Send("GET_VERSION\r\n");
        }

        private void OpenCsvBtn_Click(object sender, EventArgs e)
        {
            string c_path = System.AppDomain.CurrentDomain.BaseDirectory + FilePath;
            System.Diagnostics.Process.Start("explorer.exe", c_path);
        }

        private void StatusUpdateTimer_Tick(object sender, EventArgs e)
        {
            Send("GET_STATUS\r\n");
        }

        private void SetStartupTimeBtn_Click(object sender, EventArgs e)
        {
            Send("SET_STARTUP_TIME,"+ (int)StartupTimeNum.Value + "\r\n");
        }

        private void comGimPort_DropDown(object sender, EventArgs e)
        {
            comGimPort.Items.Clear();

            // すべてのシリアル・ポート名を取得する
            String[] ports = System.IO.Ports.SerialPort.GetPortNames();
            // 取得したシリアル・ポート名を出力する
            foreach (String s in ports)
            {
                comGimPort.Items.Add(s);
            }

            //最後のを選択する
            //	comGimPort->SelectedIndex = comGimPort->Items->Count-1;

            //ターゲットデバイス名取得
            SerialPortList sp = new SerialPortList();
            String target_name = sp.GetComFromDevName("STMicro");
            //該当を選択
            foreach (String s in ports)
            {
                if (s == target_name)
                {
                    comGimPort.SelectedItem = s;
                    break;
                }
            }

            ComPortNameLabel.Text = sp.GetDevNameFromCom((string)comGimPort.SelectedItem);
        }
    }
}
