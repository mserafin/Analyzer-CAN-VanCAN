namespace Symulator
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPortName = new System.Windows.Forms.TextBox();
            this.txtCanId = new System.Windows.Forms.TextBox();
            this.txtCanData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtResData = new System.Windows.Forms.RichTextBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.labTelemetry = new System.Windows.Forms.RichTextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Połącz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPortName
            // 
            this.txtPortName.Location = new System.Drawing.Point(7, 12);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.Size = new System.Drawing.Size(100, 20);
            this.txtPortName.TabIndex = 2;
            this.txtPortName.Text = "COM10";
            // 
            // txtCanId
            // 
            this.txtCanId.Location = new System.Drawing.Point(8, 89);
            this.txtCanId.Name = "txtCanId";
            this.txtCanId.Size = new System.Drawing.Size(50, 20);
            this.txtCanId.TabIndex = 3;
            this.txtCanId.Text = "0x7FF";
            // 
            // txtCanData
            // 
            this.txtCanData.Location = new System.Drawing.Point(64, 89);
            this.txtCanData.Name = "txtCanData";
            this.txtCanData.Size = new System.Drawing.Size(204, 20);
            this.txtCanData.TabIndex = 4;
            this.txtCanData.Text = "55,55,55,55,55,55,55,55";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "CanId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(193, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtResData
            // 
            this.txtResData.Location = new System.Drawing.Point(331, 12);
            this.txtResData.Name = "txtResData";
            this.txtResData.Size = new System.Drawing.Size(360, 426);
            this.txtResData.TabIndex = 8;
            this.txtResData.Text = "";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(8, 157);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(50, 20);
            this.txtInterval.TabIndex = 9;
            this.txtInterval.Text = "100";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(79, 197);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = ">>";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(193, 10);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Czyść";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(7, 248);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 13;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(193, 155);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "Config";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // labTelemetry
            // 
            this.labTelemetry.Location = new System.Drawing.Point(7, 274);
            this.labTelemetry.Name = "labTelemetry";
            this.labTelemetry.Size = new System.Drawing.Size(318, 164);
            this.labTelemetry.TabIndex = 15;
            this.labTelemetry.Text = "";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(193, 245);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(132, 23);
            this.button8.TabIndex = 16;
            this.button8.Text = "Włącz symulator";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 450);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.labTelemetry);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.txtResData);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCanData);
            this.Controls.Add(this.txtCanId);
            this.Controls.Add(this.txtPortName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPortName;
        private System.Windows.Forms.TextBox txtCanId;
        private System.Windows.Forms.TextBox txtCanData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox txtResData;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.RichTextBox labTelemetry;
        private System.Windows.Forms.Button button8;
    }
}

