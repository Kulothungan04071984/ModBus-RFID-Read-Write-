
namespace Modbus_HF_Reader
{
    partial class New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbWrite = new System.Windows.Forms.RadioButton();
            this.rdbRead = new System.Windows.Forms.RadioButton();
            this.rdbInventory = new System.Windows.Forms.RadioButton();
            this.Result = new System.Windows.Forms.GroupBox();
            this.txtWriteData = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSingleBlock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetProtocol = new System.Windows.Forms.Button();
            this.btnExcute = new System.Windows.Forms.Button();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.txtSenRequest = new System.Windows.Forms.TextBox();
            this.cmbBlock = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.Result.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(9, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(258, 367);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(515, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 392);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOG";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 67);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Calibri", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "ModBus-Read/Write";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port  :";
            // 
            // cmbPort
            // 
            this.cmbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(190, 104);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(121, 24);
            this.cmbPort.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.SkyBlue;
            this.btnConnect.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.Green;
            this.btnConnect.Location = new System.Drawing.Point(317, 99);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 33);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.BackColor = System.Drawing.Color.SkyBlue;
            this.btnDisConnect.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisConnect.ForeColor = System.Drawing.Color.Maroon;
            this.btnDisConnect.Location = new System.Drawing.Point(404, 99);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(94, 33);
            this.btnDisConnect.TabIndex = 7;
            this.btnDisConnect.Text = "Disconnect";
            this.btnDisConnect.UseVisualStyleBackColor = false;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox2.Controls.Add(this.rdbWrite);
            this.groupBox2.Controls.Add(this.rdbRead);
            this.groupBox2.Controls.Add(this.rdbInventory);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 130);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Block";
            // 
            // rdbWrite
            // 
            this.rdbWrite.AutoSize = true;
            this.rdbWrite.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbWrite.Location = new System.Drawing.Point(7, 93);
            this.rdbWrite.Name = "rdbWrite";
            this.rdbWrite.Size = new System.Drawing.Size(94, 21);
            this.rdbWrite.TabIndex = 2;
            this.rdbWrite.TabStop = true;
            this.rdbWrite.Text = "Write Block";
            this.rdbWrite.UseVisualStyleBackColor = true;
            this.rdbWrite.CheckedChanged += new System.EventHandler(this.rdbWrite_CheckedChanged);
            // 
            // rdbRead
            // 
            this.rdbRead.AutoSize = true;
            this.rdbRead.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbRead.Location = new System.Drawing.Point(7, 55);
            this.rdbRead.Name = "rdbRead";
            this.rdbRead.Size = new System.Drawing.Size(91, 21);
            this.rdbRead.TabIndex = 1;
            this.rdbRead.TabStop = true;
            this.rdbRead.Text = "Read Block";
            this.rdbRead.UseVisualStyleBackColor = true;
            this.rdbRead.CheckedChanged += new System.EventHandler(this.rdbRead_CheckedChanged);
            // 
            // rdbInventory
            // 
            this.rdbInventory.AutoSize = true;
            this.rdbInventory.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbInventory.Location = new System.Drawing.Point(7, 20);
            this.rdbInventory.Name = "rdbInventory";
            this.rdbInventory.Size = new System.Drawing.Size(81, 21);
            this.rdbInventory.TabIndex = 0;
            this.rdbInventory.TabStop = true;
            this.rdbInventory.Text = "UID Read";
            this.rdbInventory.UseVisualStyleBackColor = true;
            this.rdbInventory.CheckedChanged += new System.EventHandler(this.rdbInventory_CheckedChanged);
            // 
            // Result
            // 
            this.Result.BackColor = System.Drawing.Color.SkyBlue;
            this.Result.Controls.Add(this.cmbBlock);
            this.Result.Controls.Add(this.txtWriteData);
            this.Result.Controls.Add(this.label6);
            this.Result.Controls.Add(this.label5);
            this.Result.Controls.Add(this.txtData);
            this.Result.Controls.Add(this.label4);
            this.Result.Controls.Add(this.txtUID);
            this.Result.Controls.Add(this.label3);
            this.Result.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.Location = new System.Drawing.Point(192, 151);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(306, 167);
            this.Result.TabIndex = 9;
            this.Result.TabStop = false;
            this.Result.Text = "Entry";
            // 
            // txtWriteData
            // 
            this.txtWriteData.Location = new System.Drawing.Point(91, 93);
            this.txtWriteData.Name = "txtWriteData";
            this.txtWriteData.Size = new System.Drawing.Size(209, 24);
            this.txtWriteData.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Write Data :";
            // 
            // txtSingleBlock
            // 
            this.txtSingleBlock.Location = new System.Drawing.Point(26, 385);
            this.txtSingleBlock.Name = "txtSingleBlock";
            this.txtSingleBlock.Size = new System.Drawing.Size(75, 20);
            this.txtSingleBlock.TabIndex = 5;
            this.txtSingleBlock.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Block :";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(91, 59);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(209, 24);
            this.txtData.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Read Data :";
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(62, 23);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(238, 24);
            this.txtUID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "UID :";
            // 
            // btnSetProtocol
            // 
            this.btnSetProtocol.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSetProtocol.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetProtocol.Location = new System.Drawing.Point(26, 331);
            this.btnSetProtocol.Name = "btnSetProtocol";
            this.btnSetProtocol.Size = new System.Drawing.Size(152, 32);
            this.btnSetProtocol.TabIndex = 10;
            this.btnSetProtocol.Text = "Set Protocol";
            this.btnSetProtocol.UseVisualStyleBackColor = false;
            this.btnSetProtocol.Visible = false;
            this.btnSetProtocol.Click += new System.EventHandler(this.btnSetProtocol_Click);
            // 
            // btnExcute
            // 
            this.btnExcute.BackColor = System.Drawing.Color.SkyBlue;
            this.btnExcute.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcute.Location = new System.Drawing.Point(192, 331);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(306, 32);
            this.btnExcute.TabIndex = 11;
            this.btnExcute.Text = "Execute";
            this.btnExcute.UseVisualStyleBackColor = false;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Location = new System.Drawing.Point(14, 415);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(152, 23);
            this.btnSendRequest.TabIndex = 12;
            this.btnSendRequest.Text = "Send Request";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Visible = false;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // txtSenRequest
            // 
            this.txtSenRequest.Location = new System.Drawing.Point(190, 418);
            this.txtSenRequest.Name = "txtSenRequest";
            this.txtSenRequest.Size = new System.Drawing.Size(306, 20);
            this.txtSenRequest.TabIndex = 13;
            this.txtSenRequest.Visible = false;
            // 
            // cmbBlock
            // 
            this.cmbBlock.FormattingEnabled = true;
            this.cmbBlock.Items.AddRange(new object[] {
            "--Select Block--",
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07"});
            this.cmbBlock.Location = new System.Drawing.Point(91, 129);
            this.cmbBlock.Name = "cmbBlock";
            this.cmbBlock.Size = new System.Drawing.Size(109, 23);
            this.cmbBlock.TabIndex = 8;
            // 
            // New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSenRequest);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.txtSingleBlock);
            this.Controls.Add(this.btnSetProtocol);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDisConnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "New";
            this.Text = "ModBus-Reader";
            this.Load += new System.EventHandler(this.New_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Result.ResumeLayout(false);
            this.Result.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbWrite;
        private System.Windows.Forms.RadioButton rdbRead;
        private System.Windows.Forms.RadioButton rdbInventory;
        private System.Windows.Forms.GroupBox Result;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSingleBlock;
        private System.Windows.Forms.Button btnSetProtocol;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.TextBox txtSenRequest;
        private System.Windows.Forms.TextBox txtWriteData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBlock;
    }
}