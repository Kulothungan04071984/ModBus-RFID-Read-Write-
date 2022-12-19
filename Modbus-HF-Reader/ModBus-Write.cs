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

namespace Modbus_HF_Reader
{
    public partial class ModBus_Write : Form
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
        public string modData = string.Empty;
        private const int BufferSize = 1024;
        private readonly object m_syncRoot = new object();
        //private SerialPort m_serialPort;
        private static readonly AsyncCallback m_endReadCallback = new AsyncCallback(EndRead);
        private static readonly AsyncCallback m_endWriteCallback = new AsyncCallback(EndWrite);
        int flog = 0;
        int write = 0;
        public ModBus_Write()
        {
            InitializeComponent();
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
        private void ModBus_Write_Load(object sender, EventArgs e)
        {
            var MODports = SerialPort.GetPortNames();
            cmbModPort.DataSource = MODports;
        }

        private void ModBusSP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if(ModBusSP.IsOpen)
                {
                    byte val = (byte)ModBusSP.ReadByte();
                    // test = testone.ToString();
                    int cnt = ModBusSP.ReadByte();
                    byte[] testtwo = new byte[cnt];


                    for (int i = 0; i < cnt; i++)
                    {
                        testtwo[i] = (byte)ModBusSP.ReadByte();
                        // modData = testtwo[i].ToString("X2");
                        // this.Invoke(new EventHandler(text));
                        modData = testtwo[i].ToString("X2");
                        this.Invoke(new EventHandler(DiplayModdata));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void DiplayModdata(object sender, EventArgs e)
        {
            rtbModText.AppendText( modData + " ");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(cmbModPort.Items.Count == 0 || cmbModPort.SelectedItem==null)
            {
                MessageBox.Show("Please select a Port", "Warning");
                return;
            }
            else if(cmdBaudRate.Items.Count == 0 || cmdBaudRate.SelectedItem==null)
            {
                MessageBox.Show("Please select a baud rate", "Warning");
                return;
            }

            if(!ModBusSP.IsOpen)
            {
                string comPort = cmbModPort.SelectedItem.ToString();
                string BaudRate = cmdBaudRate.SelectedItem.ToString();
                ModBusSP.PortName = comPort;
                ModBusSP.BaudRate =Convert.ToInt32(BaudRate);
                ModBusSP.Open();
                // ModBusSP.RtsEnable = false;
                ModBusSP.DiscardOutBuffer();
                ModBusSP.DiscardInBuffer();
                byte[] byteat = new byte[8];
                byteat[0] = 1;
                byteat[1] = 8;
                byteat[2] = 0;
                byteat[3] = 3;
                byteat[4] = 4;
                byteat[5] = 255;
                byteat[6] = 0;
                byteat[7] = 0;
                //var hexss = ConvertHex("0108000304FF0000");
                //var state1 = new AsyncState(this.ModBusSP, Encoding.ASCII.GetBytes(string.Concat("0108000304FF0000", this.NewLine)));
                //this.ModBusSP.BaseStream.BeginWrite(state1.Buffer, 0, state1.Buffer.Length, m_endWriteCallback, state1);
                // ModBusSP.RtsEnable = true;
                // ModBusSP.Write(hexss);
                ModBusSP.Write(byteat, 0, byteat.Length);
            }
        }

        public static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }

        private void btnProtocal_Click(object sender, EventArgs e)
        {
            if (ModBusSP.IsOpen)
            {

                ModBusSP.DiscardOutBuffer();
                ModBusSP.DiscardInBuffer();

                // var state = new AsyncState(this.ModBusSP, Encoding.ASCII.GetBytes(string.Concat("010A0003041001210000", this.NewLine)));
                //this.ModBusSP.BaseStream.BeginWrite(state.Buffer, 0, state.Buffer.Length, m_endWriteCallback, state);
                var one = ConvertHex("010A0003041001210000");
                ModBusSP.Write(one);

                Thread.Sleep(1000);
                ModBusSP.DiscardOutBuffer();
                ModBusSP.DiscardInBuffer();
                if (flog == 1)
                {

                    //var state2 = new AsyncState(this.ModBusSP, Encoding.ASCII.GetBytes(string.Concat("010C00030410002101020000", this.NewLine)));
                    //this.ModBusSP.BaseStream.BeginWrite(state2.Buffer, 0, state2.Buffer.Length, m_endWriteCallback, state2);
                    var two = ConvertHex("010C00030410002101020000");
                    ModBusSP.Write(two);
                    Thread.Sleep(1000);
                    ModBusSP.DiscardOutBuffer();
                    ModBusSP.DiscardInBuffer();
                }
                else
                {

                    //var state2 = new AsyncState(this.ModBusSP, Encoding.ASCII.GetBytes(string.Concat("010C00030410002101000000", this.NewLine)));
                    //this.ModBusSP.BaseStream.BeginWrite(state2.Buffer, 0, state2.Buffer.Length, m_endWriteCallback, state2);
                    var three = ConvertHex("010C00030410002101000000");
                    ModBusSP.Write(three);
                    Thread.Sleep(1000);
                    ModBusSP.DiscardOutBuffer();
                    ModBusSP.DiscardInBuffer();
                }

                // var state3 = new AsyncState(this.ModBusSP, Encoding.ASCII.GetBytes(string.Concat("0109000304F0000000", this.NewLine)));
                //this.ModBusSP.BaseStream.BeginWrite(state3.Buffer, 0, state3.Buffer.Length, m_endWriteCallback, state3);
                var four = ConvertHex("0109000304F0000000");
                ModBusSP.Write(four);
                Thread.Sleep(1000);

                ModBusSP.DiscardOutBuffer();
                ModBusSP.DiscardInBuffer();

                // var state4 = new AsyncState(this.ModBusSP, Encoding.ASCII.GetBytes(string.Concat("0109000304F1FF0000", this.NewLine)));
                // this.ModBusSP.BaseStream.BeginWrite(state4.Buffer, 0, state4.Buffer.Length, m_endWriteCallback, state4);
                var five = ConvertHex("0109000304F1FF0000");
                ModBusSP.Write(five);




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

        private void SendData(string commandText)
        {

            commandText = ConvertHex(commandText);
           // ModBusSP.RtsEnable = false;

            //var input = "01 04 00 00 00 01 31 CA";
            //byte[] data;
            //data = input.Split().Select(s => Convert.ToByte(s, 16)).ToArray();
            //ModBusSP.Write(data, 0, data.Length);

          // ModBusSP.RtsEnable = true;
            //  var bytes = Encoding.ASCII.GetBytes(commandText + "\r");
            // ModBusSP.Write(bytes, 0, bytes.Length);
            //var firstBlock = SRModBusReader.ReadExisting();
            //txtData.Text = firstBlock;
            ModBusSP.DiscardOutBuffer();
            ModBusSP.DiscardInBuffer();
            //var bytes1 = Encoding.ASCII.GetBytes(txtBlockNumber.Text.ToString() + "\r");
            //SRModBusReader.BaseStream.BeginWrite(bytes1, 0, bytes1.Length,m_endWriteCallback,);
            //  var stateExcute = new AsyncState(this.ModBusSP, Encoding.ASCII.GetBytes(string.Concat(commandText, this.NewLine)));
            //  this.ModBusSP.BaseStream.BeginWrite(stateExcute.Buffer, 0, stateExcute.Buffer.Length, m_endWriteCallback, stateExcute);
            ModBusSP.Write(commandText);
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

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            var srequest = txtSend.Text.ToString();
            SendData(srequest);
        }
    }
}
