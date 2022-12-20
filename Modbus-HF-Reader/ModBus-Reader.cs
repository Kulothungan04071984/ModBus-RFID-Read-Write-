using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus_HF_Reader
{
    public partial class New : Form
    {
        string RcData = string.Empty;
        string rbData = string.Empty;
        int count = 0;
        // byte[] arrData = new byte[cnt + 3];
        int Inventory = 0;
        int Excute = 0;
        int Read = 0;
        string InventoryStr = string.Empty;
        string BlockChange = string.Empty;
        string writeBlock = string.Empty;
        string reverseData = string.Empty;
        string rData = string.Empty;
        bool SetProtocol = false;

        private const int BufferSize = 1024;
        private readonly object m_syncRoot = new object();
        //private SerialPort m_serialPort;
        private static readonly AsyncCallback m_endReadCallback = new AsyncCallback(EndRead);
        private static readonly AsyncCallback m_endWriteCallback = new AsyncCallback(EndWrite);
        int flog = 0;
        int write = 0;
        public byte[] dataValue;
        public New()
        {
            InitializeComponent();
        }

        string test = string.Empty;
        int j = 0;
       // byte val;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                // // //test = serialPort1.ReadExisting();
                //  byte val = (byte)serialPort1.ReadByte();
                ////  // test = testone.ToString();
                //  int cnt = serialPort1.ReadByte();
                //  byte[] testtwo = new byte[cnt + 2];


                //  for (int i = 0; i < cnt + 2; i++)
                //  {
                //      if (i == 0)
                //          testtwo[0] = val;
                //      else if (i == 1)
                //          testtwo[1] = (byte)cnt;
                //      else
                //          testtwo[i] = (byte)serialPort1.ReadByte();

                //      test = testtwo[i].ToString("X2");
                //      this.Invoke(new EventHandler(text));
                //  }
                var rData = serialPort1.ReadExisting();
                RcData = rData;

                this.Invoke(new EventHandler(text));
            }
            //test = testtwo[i].ToString("X2");
            //test = ByteArrayToString(testtwo);
            //this.Invoke(new EventHandler(text));
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public void text(object sender, EventArgs e)
        {
            //richTextBox1.AppendText(test.ToString() +" ");
            try
            {


                Thread.Sleep(1000);
                if (rdbInventory.Checked)
                {

                    if (Excute == 1)
                    {
                        Inventory++;
                        if (Inventory == 3)
                        {
                            Regex pattern = new Regex("[;,\t\r ]|[\n]{2}");
                            var str = pattern.Replace(RcData, "\n");
                            str = str.Replace("[", "");
                            str = str.Replace("]", "");
                            str = str.Replace("?", "");
                            str = str.Replace("\n", "");
                            if (str.Length > 2)
                                str = str.Substring(0, str.Length - 1);

                            var rUID = ReverseLoop(str);
                            txtUID.Enabled = true;
                            txtUID.Text = string.Empty;
                            txtUID.AppendText(rUID);
                            txtUID.Enabled = false;

                            Inventory = 0;
                        }
                    }
                }
                else if (rdbRead.Checked)
                {

                    if (cmbBlock.Text != string.Empty && flog == 1)
                    {
                        if (Excute == 2)
                        {
                            Read++;
                            if (Read == 2)
                            {
                                var readData = RcData;
                                readData = readData.Replace("[", "");
                                readData = readData.Replace("]", "");
                                readData = readData.Replace("?", "");
                                readData = readData.Replace("\r", "");
                                readData = readData.Substring(2, readData.Length - 2);
                                var rReadData = ReverseLoop(readData);
                                txtData.Enabled = true;
                                txtData.Text = string.Empty;
                                txtData.AppendText(rReadData);
                                txtData.Enabled = false;
                                Read = 0;
                            }
                        }
                    }



                }
                //rtblog.AppendText(RcData + " -" + count + "\n");
                var rMessgae = RcData.ToString().Replace("?", "").Trim();
                if ("TRF7970A EVM" == rMessgae)
                    rMessgae = "Connected";
                else if("Register write request." == rMessgae)
                    rMessgae= "Sending Request";
                else if ("AM PM Togg" == rMessgae)
                    rMessgae = "Ready to Execute";
                else if ("Request mode." == rMessgae && rdbRead.Checked)
                        rMessgae = "Reading Data";
                else if ("Request mode." == rMessgae && rdbWrite.Checked)
                    rMessgae = "Data Written";

                //if ("[00]" == rMessgae)
                //    rMessgae = "Data Written ";
                if (rMessgae.Contains("["))
                    rMessgae = string.Empty;

                //richTextBox1.AppendText(RcData.ToString().Replace("?", "") + " " + "\n");
                richTextBox1.AppendText(rMessgae + " " + "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
          
        }
        private void New_Load(object sender, EventArgs e)
        {
           // btnSetProtocol.Enabled = false;
            btnExcute.Enabled = false;
            txtUID.Enabled = false;
            cmbBlock.Enabled = false;
            txtWriteData.Enabled = false;
            txtData.Enabled = false;
            var ports = SerialPort.GetPortNames();
            //serialPort1.PortName = Se
            cmbPort.DataSource = ports;
            //cmbPort.Items.Add("Select Port");
            

            //var input = "01 04 00 00 00 01 31 CA";
            //var byteeeee = input.Split(' ').ToArray();
           
            //dataValue = new byte[byteeeee.Length];
            //for (int i = 0; i < byteeeee.Length; i++)
            //{
            //    string hex_value = byteeeee[i];
            //    int int_value = Convert.ToInt32(hex_value, 16);
            //    dataValue[i] = (byte)int_value;
            //}
         
            //byte[] data = new byte[8];
            //data[0] = 1;
            //data[1] = 4;
            //data[2] = 0;
            //data[3] = 0;
            //data[4] = 0;
            //data[5] = 1;
            //data[6] = 49;
            //data[7] = 202;

            
            //serialPort1.Write(dataValue, 0, dataValue.Length);
            // serialPort1.Write(input);

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbPort.Items.Count == 0 )
            {
                MessageBox.Show("Please select a Port", "Warning");
                return;
            }
            //if (!serialPort1.IsOpen)
            //{
            //    serialPort1.PortName = cmbPort.SelectedItem.ToString();
            //    serialPort1.Open();
            //    MessageBox.Show( cmbPort.SelectedItem.ToString() + " Port is Connected", "Message");
            //}
           
            try
            {
                if (!serialPort1.IsOpen)
                {
                    //serialPort1.PortName = cmbPort.SelectedItem.ToString();
                    //serialPort1.Open();
                  
                    string com = cmbPort.SelectedItem.ToString();
                    serialPort1.PortName = com;
                    //serialPort1.PortName = "COM5";
                    //serialPort1.BaudRate = 115200;
                    serialPort1.BaudRate = 9600;
                    //serialPort1.DataBits = 8;
                    //serialPort1.Parity = Parity.None;
                    //serialPort1.StopBits = StopBits.One;

                    serialPort1.Open();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.DiscardInBuffer();
                    MessageBox.Show(cmbPort.SelectedItem.ToString() + " Port is Connected", "Message");
                    //  var bytes1 = Encoding.ASCII.GetBytes(txtBlockNumber.Text.ToString() + "\r");
                    // serialPort1.BaseStream.BeginWrite(bytes1, 0, bytes1.Length,m_endWriteCallback,);
                    var state1 = new AsyncState(this.serialPort1, Encoding.ASCII.GetBytes(string.Concat("0108000304FF0000", this.NewLine)));
                    this.serialPort1.BaseStream.BeginWrite(state1.Buffer, 0, state1.Buffer.Length, m_endWriteCallback, state1);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                serialPort1.Close();
            }
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
         
            try
            {
                if (serialPort1.IsOpen)
                {
                    byte[] req;
                    var request = txtSenRequest.Text.ToString();
                    if (request != string.Empty)
                    {
                        var reqSplit = request.Split(' ').ToArray();
                        if (reqSplit.Length > 1)
                        {
                            req = new byte[reqSplit.Length];
                            for (int i = 0; i < req.Length; i++)
                            {
                                req[i] = (byte)Convert.ToInt32(reqSplit[i]);
                            }
                            serialPort1.Write(req, 0, req.Length);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                serialPort1.Close();
                MessageBox.Show( cmbPort.SelectedItem.ToString() + " Port is  DisConnected" , "Message");
            }
        }

        public string PortName
        {
            get;
            private set;
        }

        public string NewLine
        {
            get;
            private set;
        }

        public int Timeout
        {
            get;
            private set;
        }

        public bool IsOpen
        {
            get
            {
                lock (this.m_syncRoot)
                {
                    return (this.serialPort1 != null &&
                            this.serialPort1.IsOpen);
                }
            }
        }
        private class AsyncState
        {
            public readonly SerialPort SerialPort;
            public readonly byte[] Buffer;
            public readonly MemoryStream Stream = new MemoryStream();

            public AsyncState(SerialPort serialPort)
            {
                this.SerialPort = serialPort;
                this.Buffer = new byte[BufferSize];
            }

            public AsyncState(SerialPort serialPort, byte[] buffer)
                : this(serialPort)
            {
                this.Buffer = buffer;
            }

            public string Data
            {
                get;
                set;
            }
        }
        private static void EndWrite(IAsyncResult result)
        {
            var state = result.AsyncState as AsyncState;

            lock (state)
            {
                try
                {
                    if (state.SerialPort.IsOpen)
                    {
                        state.SerialPort.BaseStream.EndWrite(result);
                        state.SerialPort.BaseStream.Flush();
                    }
                }
                catch
                {
                }
            }
        }

        private static void EndRead(IAsyncResult result)
        {
            var state = result.AsyncState as AsyncState;

            lock (state)
            {
                try
                {
                    if (state.SerialPort.IsOpen)
                    {
                        int readed = state.SerialPort.BaseStream.EndRead(result);
                        state.SerialPort.BaseStream.Flush();
                        state.Stream.Write(state.Buffer, 0, readed);
                        state.Stream.Flush();
                        state.Stream.Seek(0, SeekOrigin.Begin);

                        var buffer = new byte[state.Stream.Length];
                        state.Stream.Read(buffer, 0, buffer.Length);

                        var data = Encoding.ASCII.GetString(buffer);

                        if (data.EndsWith("\r\n"))
                        {
                            state.Data = data;
                            Monitor.Pulse(state);
                        }
                        else
                        {
                            state.SerialPort.BaseStream.BeginRead(state.Buffer, 0, state.Buffer.Length, m_endReadCallback, state);
                        }
                    }
                }
                catch
                {
                    Monitor.Pulse(state);
                }
            }
        }

        public void protocol()
        {
            if (serialPort1.IsOpen)
            {
               
                serialPort1.DiscardOutBuffer();
                serialPort1.DiscardInBuffer();

                var state = new AsyncState(this.serialPort1, Encoding.ASCII.GetBytes(string.Concat("010A0003041001210000", this.NewLine)));
                this.serialPort1.BaseStream.BeginWrite(state.Buffer, 0, state.Buffer.Length, m_endWriteCallback, state);
                Thread.Sleep(1000);
                serialPort1.DiscardOutBuffer();
                serialPort1.DiscardInBuffer();
                if (flog == 1)
                {
                    SetProtocol = true;
                    var state2 = new AsyncState(this.serialPort1, Encoding.ASCII.GetBytes(string.Concat("010C00030410002101020000", this.NewLine)));
                    this.serialPort1.BaseStream.BeginWrite(state2.Buffer, 0, state2.Buffer.Length, m_endWriteCallback, state2);
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    serialPort1.DiscardInBuffer();
                }
                else
                {
                    SetProtocol = false;
                    var state2 = new AsyncState(this.serialPort1, Encoding.ASCII.GetBytes(string.Concat("010C00030410002101000000", this.NewLine)));
                    this.serialPort1.BaseStream.BeginWrite(state2.Buffer, 0, state2.Buffer.Length, m_endWriteCallback, state2);
                    Thread.Sleep(1000);
                    serialPort1.DiscardOutBuffer();
                    serialPort1.DiscardInBuffer();
                }

                var state3 = new AsyncState(this.serialPort1, Encoding.ASCII.GetBytes(string.Concat("0109000304F0000000", this.NewLine)));
                this.serialPort1.BaseStream.BeginWrite(state3.Buffer, 0, state3.Buffer.Length, m_endWriteCallback, state3);
                Thread.Sleep(1000);

                serialPort1.DiscardOutBuffer();
                serialPort1.DiscardInBuffer();

                var state4 = new AsyncState(this.serialPort1, Encoding.ASCII.GetBytes(string.Concat("0109000304F1FF0000", this.NewLine)));
                this.serialPort1.BaseStream.BeginWrite(state4.Buffer, 0, state4.Buffer.Length, m_endWriteCallback, state4);


                btnExcute.Enabled = true;
            }
        }
        private void btnSetProtocol_Click(object sender, EventArgs e)
        {
           
            
        }

        private void SendData(string commandText)
        {
            //var bytes = Encoding.ASCII.GetBytes("010B000304140401000000" + "\r");
            //serialPort1.Write(bytes, 0, bytes.Length);
            //var firstBlock = serialPort1.ReadExisting();
            //txtData.Text = firstBlock;
            serialPort1.DiscardOutBuffer();
            serialPort1.DiscardInBuffer();
            //  var bytes1 = Encoding.ASCII.GetBytes(txtBlockNumber.Text.ToString() + "\r");
            // serialPort1.BaseStream.BeginWrite(bytes1, 0, bytes1.Length,m_endWriteCallback,);
            var stateExcute = new AsyncState(this.serialPort1, Encoding.ASCII.GetBytes(string.Concat(commandText, this.NewLine)));
            this.serialPort1.BaseStream.BeginWrite(stateExcute.Buffer, 0, stateExcute.Buffer.Length, m_endWriteCallback, stateExcute);
        }

        public void PortWarning()
        {
            MessageBox.Show("Please connect your port");
        }

        private void rdbInventory_CheckedChanged(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                PortWarning();
                return;
            }
            if (rdbInventory.Checked)
            {
                Inventory = 1;
                rdbRead.Checked = false;
                rdbWrite.Checked = false;
                flog = 0;
                write = 0;
                txtWriteData.Enabled = false;
                // btnSetProtocol.Enabled = true;
                cmbBlock.Enabled = false;
                protocol();


            }
            else
                Inventory = 0;
        }

        private void rdbRead_CheckedChanged(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                PortWarning();
                return;
            }
            if (rdbRead.Checked)
            {
                flog = 1;
                rdbInventory.Checked = false;
                rdbWrite.Checked = false;
                Inventory = 0;
                write = 0;
                btnExcute.Enabled = false;
                txtWriteData.Enabled = false;
                cmbBlock.Enabled = true;
                if (!SetProtocol)
                    protocol();
                else
                    btnExcute.Enabled = true;
            }
            else
                flog = 0;
        }

        private void rdbWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                PortWarning();
                return;
            }
            if (rdbWrite.Checked)
            {
                write = 1;
                rdbInventory.Checked = false;
                rdbRead.Checked = false;
                flog = 1;
                write = 0;
                btnExcute.Enabled = true;
                cmbBlock.Enabled = true;
                txtWriteData.Enabled = true;
               // protocol();
            }
            else
                write = 0;
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {

            try
            {
                if (rdbInventory.Checked)
                {
                    InventoryStr = "010B000304140401000000";
                    //txtUID.Text = SRModBusReader.ReadExisting();
                    Excute = 1;
                    Inventory = 1;
                }
                else if (rdbRead.Checked)
                {
                    Excute = 2;
                    Read = 0;
                    if (cmbBlock.Text.ToString() != string.Empty)
                    {
                        var blockCount = cmbBlock.Text.Length;
                        if (blockCount == 2)
                            BlockChange = "010B000304180220" + cmbBlock.Text.ToString() + "0000";
                        InventoryStr = BlockChange;

                    }
                    else
                        MessageBox.Show("Please enter valid block");
                    txtWriteData.Text = string.Empty;
                }
                else if (rdbWrite.Checked)
                {
                    string reverse = txtWriteData.Text.ToString();
                    if (reverse.Length < 8)
                    {
                        var writeDataLength = 8 - reverse.Length;
                        for (int i = 0; i < writeDataLength; i++)
                        {
                            reverse += "0";
                        }
                    }
                    Excute = 0;

                    //var wBlock = txtSingleBlock.Text.ToString();
                    //if (wBlock == "02")
                    //    reverse = DateTime.Now.ToString("ddMMyyyy");
                    //if (wBlock == "03")
                    //    reverse = DateTime.Now.ToString("HHmmss");

                    if (reverse.Length > 0)
                    {
                        rData = ReverseLoop(reverse);
                    }
                   

                    writeBlock = "010F000304180221" + cmbBlock.Text.ToString() + rData + "0000";

                    InventoryStr = writeBlock;
                    txtData.Text = string.Empty;
                }
                
                SendData(InventoryStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public string ReverseLoop(string rText)
        {
            try
            {
                if (rText.Length % 2 == 0)
                {
                    reverseData = string.Empty;
                    for (int i = rText.Length; i > 0; i--)
                    {
                        reverseData += rText.Substring(i - 2, 2).ToString();
                        i = i - 1;
                    }
                }
                else
                    reverseData = new string(rText.Reverse().ToArray());

                return reverseData;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
