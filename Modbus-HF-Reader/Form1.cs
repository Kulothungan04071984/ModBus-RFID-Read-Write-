using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Modbus_HF_Reader
{
    public partial class Form1 : Form
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
        string first8 = string.Empty;

        private const int BufferSize = 1024;
        private readonly object m_syncRoot = new object();
        //private SerialPort m_serialPort;
        private static readonly AsyncCallback m_endReadCallback = new AsyncCallback(EndRead);
        private static readonly AsyncCallback m_endWriteCallback = new AsyncCallback(EndWrite);
        int flog = 0;
        int write = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void SRModBusReader_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        
        {
            try
            {

                if (SRModBusReader.IsOpen)
                {
                    var rData = SRModBusReader.ReadLine();
                    RcData = rData;
                  
                    this.Invoke(new EventHandler(DisplayText));


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message.ToString());
            }
        }

        private void DisplayText(object sender, EventArgs e)
        {
            try
            {


                Thread.Sleep(1000);
                if (rbtInventory.Checked)
                {

                    if (Excute == 1)
                    {
                        Inventory++;
                        if (Inventory == 4)
                        {
                            Regex pattern = new Regex("[;,\t\r ]|[\n]{2}");
                            var str = pattern.Replace(RcData, "\n");
                            str = str.Replace("[", "");
                            str = str.Replace("]", "");
                            str = str.Replace("\n", "");
                            if (str.Length > 2)
                                str = str.Substring(0, str.Length - 2);

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

                    if (txtBlock.Text.ToString() != string.Empty && flog == 1)
                    {
                        if (Excute == 2)
                        {
                            Read++;
                            if (Read == 2)
                            {
                                var readData = RcData;
                                readData = readData.Replace("[", "");
                                readData = readData.Replace("]", "");
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
                rtblog.AppendText(RcData + " -" + count + "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
          
            cmbPortNumber.DataSource = ports;
            txtData.Enabled = false;
            txtUID.Enabled = false;

        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtInventory.Checked)
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
                    if (txtBlock.Text.ToString() != string.Empty)
                    {
                        var blockCount = txtBlock.Text.Length;
                        if (blockCount == 2)
                            BlockChange = "010B0003041802200" + blockCount + "0000";
                        InventoryStr = BlockChange;

                    }
                    else
                        MessageBox.Show("Please enter valid block");
                }
                else if (rdbWrite.Checked)
                {
                    string reverse = txtData.Text.ToString();
                    if (reverse.Length < 8)
                    {
                        var writeDataLength = 8 - reverse.Length;
                        for (int i = 0; i < writeDataLength; i++)
                        {
                            reverse += "0";
                        }
                    }
                    Excute = 0;
                    if (reverse.Length > 0)
                    {
                        rData = ReverseLoop(reverse);
                    }
                    writeBlock = "010F000304180221" + txtBlock.Text.ToString() + rData + "0000";

                    InventoryStr = writeBlock;
                }

                SendData(InventoryStr);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SendData(string commandText)
        {
            //var bytes = Encoding.ASCII.GetBytes("010B000304140401000000" + "\r");
            //SRModBusReader.Write(bytes, 0, bytes.Length);
            //var firstBlock = SRModBusReader.ReadExisting();
            //txtData.Text = firstBlock;
            SRModBusReader.DiscardOutBuffer();
            SRModBusReader.DiscardInBuffer();
            //  var bytes1 = Encoding.ASCII.GetBytes(txtBlockNumber.Text.ToString() + "\r");
            // SRModBusReader.BaseStream.BeginWrite(bytes1, 0, bytes1.Length,m_endWriteCallback,);
            var stateExcute = new AsyncState(this.SRModBusReader, Encoding.ASCII.GetBytes(string.Concat(commandText, this.NewLine)));
            this.SRModBusReader.BaseStream.BeginWrite(stateExcute.Buffer, 0, stateExcute.Buffer.Length, m_endWriteCallback, stateExcute);
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbPortNumber.Items.Count == 0 || cmbPortNumber.SelectedItem == null)
            {
                MessageBox.Show("Please select a Port", "Warning");
                return;
            }
            try
            {
                if (!SRModBusReader.IsOpen)
                {
                    string com = cmbPortNumber.SelectedItem.ToString();
                    SRModBusReader.PortName = com;
                    //SRModBusReader.PortName = "COM5";
                    SRModBusReader.BaudRate = 115200;
                    //SRModBusReader.BaudRate = 9600;
                    //SRModBusReader.DataBits = 8;
                    //SRModBusReader.Parity = Parity.None;
                    //SRModBusReader.StopBits = StopBits.One;

                    SRModBusReader.Open();
                    SRModBusReader.DiscardOutBuffer();
                    SRModBusReader.DiscardInBuffer();
                    //  var bytes1 = Encoding.ASCII.GetBytes(txtBlockNumber.Text.ToString() + "\r");
                    // SRModBusReader.BaseStream.BeginWrite(bytes1, 0, bytes1.Length,m_endWriteCallback,);
                    var state1 = new AsyncState(this.SRModBusReader, Encoding.ASCII.GetBytes(string.Concat("0108000304FF0000", this.NewLine)));
                    this.SRModBusReader.BaseStream.BeginWrite(state1.Buffer, 0, state1.Buffer.Length, m_endWriteCallback, state1);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                SRModBusReader.Close();
            }
        }

        private void btnProtocal_Click(object sender, EventArgs e)
        {
            if (SRModBusReader.IsOpen)
            {
              
                    SRModBusReader.DiscardOutBuffer();
                    SRModBusReader.DiscardInBuffer();

                    var state = new AsyncState(this.SRModBusReader, Encoding.ASCII.GetBytes(string.Concat("010A0003041001210000", this.NewLine)));
                    this.SRModBusReader.BaseStream.BeginWrite(state.Buffer, 0, state.Buffer.Length, m_endWriteCallback, state);
                    Thread.Sleep(1000);
                    SRModBusReader.DiscardOutBuffer();
                    SRModBusReader.DiscardInBuffer();
                if (flog == 1)
                {
                    
                       var state2 = new AsyncState(this.SRModBusReader, Encoding.ASCII.GetBytes(string.Concat("010C00030410002101020000", this.NewLine)));
                    this.SRModBusReader.BaseStream.BeginWrite(state2.Buffer, 0, state2.Buffer.Length, m_endWriteCallback, state2);
                    Thread.Sleep(1000);
                    SRModBusReader.DiscardOutBuffer();
                    SRModBusReader.DiscardInBuffer();
                }
                else
                {

                    var state2 = new AsyncState(this.SRModBusReader, Encoding.ASCII.GetBytes(string.Concat("010C00030410002101000000", this.NewLine)));
                    this.SRModBusReader.BaseStream.BeginWrite(state2.Buffer, 0, state2.Buffer.Length, m_endWriteCallback, state2);
                    Thread.Sleep(1000);
                    SRModBusReader.DiscardOutBuffer();
                    SRModBusReader.DiscardInBuffer();
                }

                    var state3 = new AsyncState(this.SRModBusReader, Encoding.ASCII.GetBytes(string.Concat("0109000304F0000000", this.NewLine)));
                    this.SRModBusReader.BaseStream.BeginWrite(state3.Buffer, 0, state3.Buffer.Length, m_endWriteCallback, state3);
                    Thread.Sleep(1000);

                    SRModBusReader.DiscardOutBuffer();
                    SRModBusReader.DiscardInBuffer();

                    var state4 = new AsyncState(this.SRModBusReader, Encoding.ASCII.GetBytes(string.Concat("0109000304F1FF0000", this.NewLine)));
                    this.SRModBusReader.BaseStream.BeginWrite(state4.Buffer, 0, state4.Buffer.Length, m_endWriteCallback, state4);
                
               
            

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
                    return (this.SRModBusReader != null &&
                            this.SRModBusReader.IsOpen);
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

        public string ReverseLoop(string rText)
        {
            try
            {
                reverseData = string.Empty;
                for (int i = rText.Length; i > 0; i--)
                {
                    reverseData += rText.Substring(i - 2, 2).ToString();
                    i = i - 1;
                }
                return reverseData;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
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

      
        private void rbtInventory_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtInventory.Checked)
            {
                Inventory = 1;
                rdbRead.Checked = false;
                rdbWrite.Checked = false;
                flog = 0;
                write = 0;
                txtData.Enabled = false;
            }
            else
                Inventory = 0;

        }

        private void rdbRead_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRead.Checked)
            {
                flog = 1;
                rbtInventory.Checked = false;
                rdbWrite.Checked = false;
                Inventory = 0;
                write = 0;
                txtData.Enabled = false;
            }
            else
                flog = 0;
          
        }

        private void rdbWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbWrite.Checked)
            {
                write = 1;
                rbtInventory.Checked = false;
                rdbRead.Checked = false;
                flog = 1;
                write = 0;
                txtData.Enabled = true;
            }
            else
                write = 0;

         
        }
    }
}


