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

namespace IMU_PlatformTool
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StartupTimeNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.GetTempBtn = new System.Windows.Forms.Button();
            this.Kp_val = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TempLabel = new System.Windows.Forms.Label();
            this.SetStartupTimeBtn = new System.Windows.Forms.Button();
            this.BoardNameLabel = new System.Windows.Forms.Label();
            this.GetBoardInfoBtn = new System.Windows.Forms.Button();
            this.ProductIdLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.loadBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.InitBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SendCycleNum = new System.Windows.Forms.NumericUpDown();
            this.SendCycleBtn = new System.Windows.Forms.Button();
            this.fps_label = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.PoseResetBtn = new System.Windows.Forms.Button();
            this.KpKiBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Ki_val = new System.Windows.Forms.NumericUpDown();
            this.BiasUpdateBtn = new System.Windows.Forms.Button();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.sampling_val = new System.Windows.Forms.NumericUpDown();
            this.yAxe_val = new System.Windows.Forms.NumericUpDown();
            this.comGimPort = new System.Windows.Forms.ComboBox();
            this.timSerial = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Colum2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recv_counter = new System.Windows.Forms.Timer(this.components);
            this.ViewUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.OpenCsvBtn = new System.Windows.Forms.Button();
            this.StatusUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.ComPortNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartupTimeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kp_val)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCycleNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ki_val)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampling_val)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yAxe_val)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnConnect
            // 
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.TxtLog);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.StatusLabel);
            this.panel1.Controls.Add(this.StartupTimeNum);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.GetTempBtn);
            this.panel1.Controls.Add(this.Kp_val);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TempLabel);
            this.panel1.Controls.Add(this.SetStartupTimeBtn);
            this.panel1.Controls.Add(this.BoardNameLabel);
            this.panel1.Controls.Add(this.GetBoardInfoBtn);
            this.panel1.Controls.Add(this.ProductIdLabel);
            this.panel1.Controls.Add(this.VersionLabel);
            this.panel1.Controls.Add(this.loadBtn);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.InitBtn);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.SendCycleNum);
            this.panel1.Controls.Add(this.SendCycleBtn);
            this.panel1.Controls.Add(this.fps_label);
            this.panel1.Controls.Add(this.StopBtn);
            this.panel1.Controls.Add(this.StartBtn);
            this.panel1.Controls.Add(this.PoseResetBtn);
            this.panel1.Controls.Add(this.KpKiBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Ki_val);
            this.panel1.Controls.Add(this.BiasUpdateBtn);
            this.panel1.Controls.Add(this.plotView1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sampling_val);
            this.panel1.Controls.Add(this.yAxe_val);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // TxtLog
            // 
            resources.ApplyResources(this.TxtLog, "TxtLog");
            this.TxtLog.Name = "TxtLog";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // StatusLabel
            // 
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.Name = "StatusLabel";
            // 
            // StartupTimeNum
            // 
            resources.ApplyResources(this.StartupTimeNum, "StartupTimeNum");
            this.StartupTimeNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.StartupTimeNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StartupTimeNum.Name = "StartupTimeNum";
            this.StartupTimeNum.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // GetTempBtn
            // 
            resources.ApplyResources(this.GetTempBtn, "GetTempBtn");
            this.GetTempBtn.Name = "GetTempBtn";
            this.GetTempBtn.UseVisualStyleBackColor = true;
            this.GetTempBtn.Click += new System.EventHandler(this.GetTempBtn_Click);
            // 
            // Kp_val
            // 
            this.Kp_val.DecimalPlaces = 5;
            this.Kp_val.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.Kp_val, "Kp_val");
            this.Kp_val.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Kp_val.Name = "Kp_val";
            this.Kp_val.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TempLabel
            // 
            resources.ApplyResources(this.TempLabel, "TempLabel");
            this.TempLabel.Name = "TempLabel";
            // 
            // SetStartupTimeBtn
            // 
            resources.ApplyResources(this.SetStartupTimeBtn, "SetStartupTimeBtn");
            this.SetStartupTimeBtn.Name = "SetStartupTimeBtn";
            this.SetStartupTimeBtn.UseVisualStyleBackColor = true;
            this.SetStartupTimeBtn.Click += new System.EventHandler(this.SetStartupTimeBtn_Click);
            // 
            // BoardNameLabel
            // 
            this.BoardNameLabel.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.BoardNameLabel, "BoardNameLabel");
            this.BoardNameLabel.Name = "BoardNameLabel";
            // 
            // GetBoardInfoBtn
            // 
            resources.ApplyResources(this.GetBoardInfoBtn, "GetBoardInfoBtn");
            this.GetBoardInfoBtn.Name = "GetBoardInfoBtn";
            this.GetBoardInfoBtn.UseVisualStyleBackColor = true;
            this.GetBoardInfoBtn.Click += new System.EventHandler(this.GetBoardInfoBtn_Click);
            // 
            // ProductIdLabel
            // 
            this.ProductIdLabel.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.ProductIdLabel, "ProductIdLabel");
            this.ProductIdLabel.Name = "ProductIdLabel";
            // 
            // VersionLabel
            // 
            resources.ApplyResources(this.VersionLabel, "VersionLabel");
            this.VersionLabel.Name = "VersionLabel";
            // 
            // loadBtn
            // 
            resources.ApplyResources(this.loadBtn, "loadBtn");
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // SaveBtn
            // 
            resources.ApplyResources(this.SaveBtn, "SaveBtn");
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // InitBtn
            // 
            resources.ApplyResources(this.InitBtn, "InitBtn");
            this.InitBtn.Name = "InitBtn";
            this.InitBtn.UseVisualStyleBackColor = true;
            this.InitBtn.Click += new System.EventHandler(this.InitBtn_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // SendCycleNum
            // 
            resources.ApplyResources(this.SendCycleNum, "SendCycleNum");
            this.SendCycleNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SendCycleNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SendCycleNum.Name = "SendCycleNum";
            this.SendCycleNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // SendCycleBtn
            // 
            resources.ApplyResources(this.SendCycleBtn, "SendCycleBtn");
            this.SendCycleBtn.Name = "SendCycleBtn";
            this.SendCycleBtn.UseVisualStyleBackColor = true;
            this.SendCycleBtn.Click += new System.EventHandler(this.SendCycleBtn_Click);
            // 
            // fps_label
            // 
            resources.ApplyResources(this.fps_label, "fps_label");
            this.fps_label.Name = "fps_label";
            // 
            // StopBtn
            // 
            resources.ApplyResources(this.StopBtn, "StopBtn");
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // StartBtn
            // 
            resources.ApplyResources(this.StartBtn, "StartBtn");
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // PoseResetBtn
            // 
            resources.ApplyResources(this.PoseResetBtn, "PoseResetBtn");
            this.PoseResetBtn.Name = "PoseResetBtn";
            this.PoseResetBtn.UseVisualStyleBackColor = true;
            this.PoseResetBtn.Click += new System.EventHandler(this.PoseResetBtn_Click);
            // 
            // KpKiBtn
            // 
            resources.ApplyResources(this.KpKiBtn, "KpKiBtn");
            this.KpKiBtn.Name = "KpKiBtn";
            this.KpKiBtn.UseVisualStyleBackColor = true;
            this.KpKiBtn.Click += new System.EventHandler(this.KpKiBtn_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // Ki_val
            // 
            this.Ki_val.DecimalPlaces = 5;
            this.Ki_val.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.Ki_val, "Ki_val");
            this.Ki_val.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Ki_val.Name = "Ki_val";
            this.Ki_val.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // BiasUpdateBtn
            // 
            resources.ApplyResources(this.BiasUpdateBtn, "BiasUpdateBtn");
            this.BiasUpdateBtn.Name = "BiasUpdateBtn";
            this.BiasUpdateBtn.UseVisualStyleBackColor = true;
            this.BiasUpdateBtn.Click += new System.EventHandler(this.BiasUpdateBtn_Click);
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.plotView1, "plotView1");
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // sampling_val
            // 
            this.sampling_val.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.sampling_val, "sampling_val");
            this.sampling_val.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.sampling_val.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.sampling_val.Name = "sampling_val";
            this.sampling_val.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.sampling_val.ValueChanged += new System.EventHandler(this.sampling_val_ValueChanged);
            // 
            // yAxe_val
            // 
            this.yAxe_val.DecimalPlaces = 3;
            this.yAxe_val.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            resources.ApplyResources(this.yAxe_val, "yAxe_val");
            this.yAxe_val.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.yAxe_val.Name = "yAxe_val";
            this.yAxe_val.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.yAxe_val.ValueChanged += new System.EventHandler(this.max_val_ValueChanged);
            // 
            // comGimPort
            // 
            this.comGimPort.FormattingEnabled = true;
            resources.ApplyResources(this.comGimPort, "comGimPort");
            this.comGimPort.Name = "comGimPort";
            this.comGimPort.DropDown += new System.EventHandler(this.comGimPort_DropDown);
            // 
            // timSerial
            // 
            this.timSerial.Tick += new System.EventHandler(this.timSerial_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.dataGridView1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Colum2,
            this.Colum3,
            this.Colum4});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            // 
            // Colum2
            // 
            resources.ApplyResources(this.Colum2, "Colum2");
            this.Colum2.Name = "Colum2";
            // 
            // Colum3
            // 
            resources.ApplyResources(this.Colum3, "Colum3");
            this.Colum3.Name = "Colum3";
            // 
            // Colum4
            // 
            resources.ApplyResources(this.Colum4, "Colum4");
            this.Colum4.Name = "Colum4";
            // 
            // recv_counter
            // 
            this.recv_counter.Interval = 1000;
            this.recv_counter.Tick += new System.EventHandler(this.recv_counter_Tick);
            // 
            // ViewUpdateTimer
            // 
            this.ViewUpdateTimer.Interval = 10;
            this.ViewUpdateTimer.Tick += new System.EventHandler(this.ViewUpdateTimer_Tick);
            // 
            // OpenCsvBtn
            // 
            resources.ApplyResources(this.OpenCsvBtn, "OpenCsvBtn");
            this.OpenCsvBtn.Name = "OpenCsvBtn";
            this.OpenCsvBtn.UseVisualStyleBackColor = true;
            this.OpenCsvBtn.Click += new System.EventHandler(this.OpenCsvBtn_Click);
            // 
            // StatusUpdateTimer
            // 
            this.StatusUpdateTimer.Interval = 1000;
            this.StatusUpdateTimer.Tick += new System.EventHandler(this.StatusUpdateTimer_Tick);
            // 
            // ComPortNameLabel
            // 
            resources.ApplyResources(this.ComPortNameLabel, "ComPortNameLabel");
            this.ComPortNameLabel.Name = "ComPortNameLabel";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComPortNameLabel);
            this.Controls.Add(this.OpenCsvBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.comGimPort);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartupTimeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kp_val)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCycleNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ki_val)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampling_val)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yAxe_val)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comGimPort;
        private System.Windows.Forms.NumericUpDown sampling_val;
        private System.Windows.Forms.NumericUpDown yAxe_val;
        private System.Windows.Forms.Timer timSerial;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button BiasUpdateBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum4;
        private System.Windows.Forms.Label TempLabel;
        private System.Windows.Forms.Button GetTempBtn;
        private System.Windows.Forms.Timer recv_counter;
        private System.Windows.Forms.Label fps_label;
        private System.Windows.Forms.NumericUpDown Kp_val;
        private System.Windows.Forms.NumericUpDown Ki_val;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button KpKiBtn;
        private System.Windows.Forms.Button PoseResetBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Timer ViewUpdateTimer;
        private System.Windows.Forms.NumericUpDown SendCycleNum;
        private System.Windows.Forms.Button SendCycleBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button InitBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Button GetBoardInfoBtn;
        private System.Windows.Forms.Label ProductIdLabel;
        private System.Windows.Forms.Label BoardNameLabel;
        private System.Windows.Forms.Button OpenCsvBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Timer StatusUpdateTimer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown StartupTimeNum;
        private System.Windows.Forms.Button SetStartupTimeBtn;
        private System.Windows.Forms.TextBox TxtLog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label ComPortNameLabel;
    }
}

