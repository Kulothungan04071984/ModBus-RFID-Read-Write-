
namespace Modbus_HF_Reader
{
    partial class Form1
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
            this.SRModBusReader = new System.IO.Ports.SerialPort(this.components);
            this.rdbRead = new System.Windows.Forms.RadioButton();
            this.rdbWrite = new System.Windows.Forms.RadioButton();
            this.chkHighData = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.rtblog = new System.Windows.Forms.RichTextBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.cmbPortNumber = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnProtocal = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBlock = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtInventory = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 22);
            this.label1.MaximumSize = new System.Drawing.Size(1000, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "HF Reader";
            // 
            // SRModBusReader
            // 
            this.SRModBusReader.BaudRate = 11500;
            this.SRModBusReader.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SRModBusReader_DataReceived);
            // 
            // rdbRead
            // 
            this.rdbRead.AutoSize = true;
            this.rdbRead.Location = new System.Drawing.Point(3, 31);
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
            // chkHighData
            // 
            this.chkHighData.AutoSize = true;
            this.chkHighData.Location = new System.Drawing.Point(560, 47);
            this.chkHighData.Name = "chkHighData";
            this.chkHighData.Size = new System.Drawing.Size(74, 17);
            this.chkHighData.TabIndex = 3;
            this.chkHighData.Text = "High Data";
            this.chkHighData.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "UID :";
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(205, 147);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(165, 20);
            this.txtUID.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data :";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(205, 196);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(114, 20);
            this.txtData.TabIndex = 9;
            // 
            // rtblog
            // 
            this.rtblog.Location = new System.Drawing.Point(505, 90);
            this.rtblog.Name = "rtblog";
            this.rtblog.Size = new System.Drawing.Size(332, 334);
            this.rtblog.TabIndex = 10;
            this.rtblog.Text = "";
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(205, 316);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 11;
            this.btnExcute.Text = "Excute";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(212, 415);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 23);
            this.btnLog.TabIndex = 12;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            // 
            // cmbPortNumber
            // 
            this.cmbPortNumber.FormattingEnabled = true;
            this.cmbPortNumber.Location = new System.Drawing.Point(205, 104);
            this.cmbPortNumber.Name = "cmbPortNumber";
            this.cmbPortNumber.Size = new System.Drawing.Size(121, 21);
            this.cmbPortNumber.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Port :";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(355, 104);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 21);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnProtocal
            // 
            this.btnProtocal.Location = new System.Drawing.Point(364, 233);
            this.btnProtocal.Name = "btnProtocal";
            this.btnProtocal.Size = new System.Drawing.Size(75, 23);
            this.btnProtocal.TabIndex = 16;
            this.btnProtocal.Text = "SetProtocal";
            this.btnProtocal.UseVisualStyleBackColor = true;
            this.btnProtocal.Click += new System.EventHandler(this.btnProtocal_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(151, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Block";
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(205, 236);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(34, 20);
            this.txtBlock.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtInventory);
            this.panel1.Controls.Add(this.rdbRead);
            this.panel1.Controls.Add(this.rdbWrite);
            this.panel1.Location = new System.Drawing.Point(12, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 94);
            this.panel1.TabIndex = 20;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBlock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnProtocal);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbPortNumber);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.rtblog);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkHighData);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "HF Reader(Read-Write)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort SRModBusReader;
        private System.Windows.Forms.RadioButton rdbRead;
        private System.Windows.Forms.RadioButton rdbWrite;
        private System.Windows.Forms.CheckBox chkHighData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.RichTextBox rtblog;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.ComboBox cmbPortNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnProtocal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtInventory;
    }
}

