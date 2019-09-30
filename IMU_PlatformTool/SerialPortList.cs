using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;//プロパティから追加指定もすること
using System.Text.RegularExpressions;

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

namespace MY.SerialPortList
{
    class SerialPortList
    {
        List<String> mDevName;//デバイスマネージャでの表示名
        List<String> mPortName;//COM12等のCOM名
        public SerialPortList()
        {
            mDevName = new List<String>();
            mPortName = new List<String>();
            this.Update();
        }

        //データを更新する
        public void Update()
        {
            //クリア
            mDevName.Clear();
            mPortName.Clear();

            //Windowsにデバイスのリストを要求
            ManagementClass mcW32SerPort = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection manageObj = mcW32SerPort.GetInstances();

            //デバイスリストからCOMポート関連を抽出
            foreach (ManagementObject aSerialPort in manageObj)
            {
                Object deviceCaption = aSerialPort.GetPropertyValue("Caption");
                if (deviceCaption == null) continue;

                String deviceName = deviceCaption.ToString();
                String portName = this.PickUpComName(deviceName);
                if (deviceName != "" && portName != "")
                {
                    //COMポート関連なら、データ登録
                    mDevName.Add(deviceName);
                    mPortName.Add(portName);
                }
            }
        }
        //指定の名前のCOMポートを探す
        public String GetComFromDevName(String dev_name)
        {
            String ret = "";
            foreach (String dev in mDevName)
            {
                System.Diagnostics.Debug.WriteLine(dev);

                if (dev.Contains(dev_name))
                {
                    ret = PickUpComName(dev);
                    break;
                }
            }
            return ret;

        }

        //指定の名前のCOMポートを探す
        public String GetDevNameFromCom(String com_name)
        {
            String ret = "";
            foreach (String dev in mDevName)
            {
                System.Diagnostics.Debug.WriteLine(dev);

                if (dev == null || com_name == null)
                {
                    break;
                }

                if (dev.IndexOf(com_name) !=-1)
                {
                    ret = dev;
                    break;
                }
            }
            return ret;

        }

        //ほげ(COMx)ほげ から、COMxを正規表現で抽出する。該当が無ければ""を返す。
        String PickUpComName(String inname)
        {
            String ret = "";
            if (Regex.IsMatch(inname, "\\(COM\\d+\\)"))
            {
                Match m = Regex.Match(inname, "\\(COM\\d+\\)");
                m.NextMatch();
                String temp = m.Value;
                if (Regex.IsMatch(inname, "COM\\d+"))
                {
                    Match m2 = Regex.Match(inname, "COM\\d+");
                    m2.NextMatch();
                    ret = m2.Value;
                }
            }
            else {
            }
            return ret;
        }
    }
}
