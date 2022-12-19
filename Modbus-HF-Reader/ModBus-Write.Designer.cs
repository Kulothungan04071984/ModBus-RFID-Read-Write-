
namespace Modbus_HF_Reader
{
    partial class ModBus_Write
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbModPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBaudRate = new System.Windows.Forms.ComboBox();
            this.ModBusSP = new System.IO.Ports.SerialPort(this.components);
            this.btnConnect = new System.Windows.Forms.Button();
            this.rtbModText = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtInventory = new System.Windows.Forms.RadioButton();
            this.rdbRead = new System.Windows.Forms.RadioButton();
            this.rdbWrite = new System.Windows.Forms.RadioButton();
            this.txtBlock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnProtocal = new System.Windows.Forms.Button();
            this.btnExcute = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port :";
            // 
            // cmbModPort
            // 
            this.cmbModPort.FormattingEnabled = true;
            this.cmbModPort.Location = new System.Drawing.Point(99, 26);
            this.cmbModPort.Name = "cmbModPort";
            this.cmbModPort.Size = new System.Drawing.Size(121, 21);
            this.cmbModPort.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate :";
            // 
            // cmdBaudRate
            // 
            this.cmdBaudRate.FormattingEnabled = true;
            this.cmdBaudRate.Items.AddRange(new object[] {
            "9600",
            "112500"});
            this.cmdBaudRate.Location = new System.Drawing.Point(99, 70);
            this.cmdBaudRate.Name = "cmdBaudRate";
            this.cmdBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cmdBaudRate.TabIndex = 3;
            // 
            // ModBusSP
            // 
            this.ModBusSP.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ModBusSP_DataReceived);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(256, 26);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(94, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Port Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // rtbModText
            // 
            this.rtbModText.Location = new System.Drawing.Point(495, 12);
            this.rtbModText.Name = "rtbModText";
            this.rtbModText.Size = new System.Drawing.Size(293, 426);
            this.rtbModText.TabIndex = 5;
            this.rtbModText.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtInventory);
            this.panel1.Controls.Add(this.rdbRead);
            this.panel1.Controls.Add(this.rdbWrite);
            this.panel1.Location = new System.Drawing.Point(31, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 94);
            this.panel1.TabIndex = 21;
            // 
            // rbtInventory
            // 
            this.rbtInventory.AutoSize = true;
            this.rbtInventory.Location = new System.Drawing.Point(4, 8);
            this.rbtInventory.Name = "rbtInventory";
            this.rbtInventory.Size = new System.Drawing.Size(69, 17);
            this.rbtInventory.TabIndex = 18;
            this.rbtInventory.TabStop = true;
            this.rbtInventory.Text = "Inventory";
            this.rbtInventory.UseVisualStyleBackColor = true;
            this.rbtInventory.CheckedChanged += new System.EventHandler(this.rbtInventory_CheckedChanged);
            // 
            // rdbRead
            // 
            this.rdbRead.AutoSize = true;
            this.rdbRead.Location = new System.Drawing.Point(4, 31);
            this.rdbRead.Name = "rdbRead";
            this.rdbRead.Size = new System.Drawing.Size(113, 17);
            this.rdbRead.TabIndex = 1;
            this.rdbRead.TabStop = true;
            this.rdbRead.Text = "Read Single Block";
            this.rdbRead.UseVisualStyleBackColor = true;
            this.rdbRead.CheckedChanged += new System.EventHandler(this.rdbRead_CheckedChanged);
            // 
            // rdbWrite
            // 
            this.rdbWrite.AutoSize = true;
            this.rdbWrite.Location = new System.Drawing.Point(4, 54);
            this.rdbWrite.Name = "rdbWrite";
            this.rdbWrite.Size = new System.Drawing.Size(112, 17);
            this.rdbWrite.TabIndex = 2;
            this.rdbWrite.TabStop = true;
            this.rdbWrite.Text = "Write Single Block";
            this.rdbWrite.UseVisualStyleBackColor = true;
            this.rdbWrite.CheckedChanged += new System.EventHandler(this.rdbWrite_CheckedChanged);
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(256, 186);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(34, 20);
            this.txtBlock.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Block";
            // 
            // btnProtocal
            // 
            this.btnProtocal.Location = new System.Drawing.Point(346, 181);
            this.btnProtocal.Name = "btnProtocal";
            this.btnProtocal.Size = new System.Drawing.Size(75, 23);
            this.btnProtocal.TabIndex = 27;
            this.btnProtocal.Text = "SetProtocal";
            this.btnProtocal.UseVisualStyleBackColor = true;
            this.btnProtocal.Click += new System.EventHandler(this.btnProtocal_Click);
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(346, 228);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 26;
            this.btnExcute.Text = "Excute";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(256, 139);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(114, 20);
            this.txtData.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Data :";
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(256, 97);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(165, 20);
            this.txtUID.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "UID :";
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(12, 290);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(105, 23);
            this.btnSendRequest.TabIndex = 30;
            this.btnSendRequest.Text = "Send Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(136, 293);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(285, 20);
            this.txtSend.TabIndex = 31;
            // 
            // ModBus_Write
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.txtBlock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnProtocal);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbModText);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmdBaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbModPort);
            this.Controls.Add(this.label1);
            this.Name = "ModBus_Write";
            this.Text = "ModBus_Write";
            this.Load += new System.EventHandler(this.ModBus_Write_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbModPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmdBaudRate;
        private System.IO.Ports.SerialPort ModBusSP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox rtbModText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtInventory;
        private System.Windows.Forms.RadioButton rdbRead;
        private System.Windows.Forms.RadioButton rdbWrite;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnProtocal;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.TextBox txtSend;
    }
}