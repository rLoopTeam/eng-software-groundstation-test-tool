namespace GS_GUI
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
            this.tC_Systems = new System.Windows.Forms.TabControl();
            this.tabPower = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabFlightControl = new System.Windows.Forms.TabPage();
            this.cBNodeList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPowerSinglePacket = new System.Windows.Forms.Button();
            this.btnPowerStartStream = new System.Windows.Forms.Button();
            this.btnPowerStopStream = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tBCount = new System.Windows.Forms.MaskedTextBox();
            this.tBSpare = new System.Windows.Forms.MaskedTextBox();
            this.tBTemp = new System.Windows.Forms.MaskedTextBox();
            this.tC_Systems.SuspendLayout();
            this.tabPower.SuspendLayout();
            this.SuspendLayout();
            // 
            // tC_Systems
            // 
            this.tC_Systems.Controls.Add(this.tabPower);
            this.tC_Systems.Controls.Add(this.tabFlightControl);
            this.tC_Systems.Location = new System.Drawing.Point(12, 41);
            this.tC_Systems.Name = "tC_Systems";
            this.tC_Systems.SelectedIndex = 0;
            this.tC_Systems.Size = new System.Drawing.Size(1058, 592);
            this.tC_Systems.TabIndex = 0;
            // 
            // tabPower
            // 
            this.tabPower.Controls.Add(this.tBTemp);
            this.tabPower.Controls.Add(this.tBSpare);
            this.tabPower.Controls.Add(this.tBCount);
            this.tabPower.Controls.Add(this.label5);
            this.tabPower.Controls.Add(this.label4);
            this.tabPower.Controls.Add(this.label3);
            this.tabPower.Controls.Add(this.btnPowerStopStream);
            this.tabPower.Controls.Add(this.btnPowerStartStream);
            this.tabPower.Controls.Add(this.btnPowerSinglePacket);
            this.tabPower.Controls.Add(this.label2);
            this.tabPower.Controls.Add(this.cBNodeList);
            this.tabPower.Controls.Add(this.label1);
            this.tabPower.Location = new System.Drawing.Point(4, 22);
            this.tabPower.Name = "tabPower";
            this.tabPower.Padding = new System.Windows.Forms.Padding(3);
            this.tabPower.Size = new System.Drawing.Size(1050, 566);
            this.tabPower.TabIndex = 0;
            this.tabPower.Text = "Power";
            this.tabPower.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Packet Type:";
            // 
            // tabFlightControl
            // 
            this.tabFlightControl.Location = new System.Drawing.Point(4, 22);
            this.tabFlightControl.Name = "tabFlightControl";
            this.tabFlightControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabFlightControl.Size = new System.Drawing.Size(1050, 566);
            this.tabFlightControl.TabIndex = 1;
            this.tabFlightControl.Text = "tabPage2";
            this.tabFlightControl.UseVisualStyleBackColor = true;
            // 
            // cBNodeList
            // 
            this.cBNodeList.FormattingEnabled = true;
            this.cBNodeList.Location = new System.Drawing.Point(10, 37);
            this.cBNodeList.Name = "cBNodeList";
            this.cBNodeList.Size = new System.Drawing.Size(167, 21);
            this.cBNodeList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parameters";
            // 
            // btnPowerSinglePacket
            // 
            this.btnPowerSinglePacket.Location = new System.Drawing.Point(801, 16);
            this.btnPowerSinglePacket.Name = "btnPowerSinglePacket";
            this.btnPowerSinglePacket.Size = new System.Drawing.Size(84, 23);
            this.btnPowerSinglePacket.TabIndex = 3;
            this.btnPowerSinglePacket.Text = "Single Packet";
            this.btnPowerSinglePacket.UseVisualStyleBackColor = true;
            this.btnPowerSinglePacket.Click += new System.EventHandler(this.btnPowerSinglePacket_Click);
            // 
            // btnPowerStartStream
            // 
            this.btnPowerStartStream.Location = new System.Drawing.Point(801, 45);
            this.btnPowerStartStream.Name = "btnPowerStartStream";
            this.btnPowerStartStream.Size = new System.Drawing.Size(84, 23);
            this.btnPowerStartStream.TabIndex = 4;
            this.btnPowerStartStream.Text = "Start Stream";
            this.btnPowerStartStream.UseVisualStyleBackColor = true;
            // 
            // btnPowerStopStream
            // 
            this.btnPowerStopStream.Location = new System.Drawing.Point(891, 45);
            this.btnPowerStopStream.Name = "btnPowerStopStream";
            this.btnPowerStopStream.Size = new System.Drawing.Size(84, 23);
            this.btnPowerStopStream.TabIndex = 4;
            this.btnPowerStopStream.Text = "StopStream";
            this.btnPowerStopStream.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Spare:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Temperature";
            // 
            // tBCount
            // 
            this.tBCount.Location = new System.Drawing.Point(125, 144);
            this.tBCount.Name = "tBCount";
            this.tBCount.Size = new System.Drawing.Size(100, 20);
            this.tBCount.TabIndex = 8;
            // 
            // tBSpare
            // 
            this.tBSpare.Location = new System.Drawing.Point(125, 170);
            this.tBSpare.Name = "tBSpare";
            this.tBSpare.Size = new System.Drawing.Size(100, 20);
            this.tBSpare.TabIndex = 8;
            // 
            // tBTemp
            // 
            this.tBTemp.Location = new System.Drawing.Point(125, 196);
            this.tBTemp.Name = "tBTemp";
            this.tBTemp.Size = new System.Drawing.Size(100, 20);
            this.tBTemp.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 637);
            this.Controls.Add(this.tC_Systems);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tC_Systems.ResumeLayout(false);
            this.tabPower.ResumeLayout(false);
            this.tabPower.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tC_Systems;
        private System.Windows.Forms.TabPage tabPower;
        private System.Windows.Forms.TabPage tabFlightControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPowerStopStream;
        private System.Windows.Forms.Button btnPowerStartStream;
        private System.Windows.Forms.Button btnPowerSinglePacket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBNodeList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tBTemp;
        private System.Windows.Forms.MaskedTextBox tBSpare;
        private System.Windows.Forms.MaskedTextBox tBCount;
    }
}

