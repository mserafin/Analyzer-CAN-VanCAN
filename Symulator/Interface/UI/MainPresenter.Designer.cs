namespace Symulator
{
    partial class MainPresenter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPortName = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.labTelemetry = new System.Windows.Forms.RichTextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGridMessages = new Symulator.Interface.Control.FastDataGridView();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASCII = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extended = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMonitor = new System.Windows.Forms.TabPage();
            this.tabTrace = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCanData = new System.Windows.Forms.TextBox();
            this.txtCanId = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabSimulator = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMessages)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabSimulator.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(554, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Połącz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPortName
            // 
            this.txtPortName.Location = new System.Drawing.Point(448, 16);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.Size = new System.Drawing.Size(100, 20);
            this.txtPortName.TabIndex = 2;
            this.txtPortName.Text = "COM4";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(790, 7);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Czyść";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(37, 209);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 13;
            // 
            // labTelemetry
            // 
            this.labTelemetry.Location = new System.Drawing.Point(37, 235);
            this.labTelemetry.Name = "labTelemetry";
            this.labTelemetry.Size = new System.Drawing.Size(318, 164);
            this.labTelemetry.TabIndex = 15;
            this.labTelemetry.Text = "";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(223, 206);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(132, 23);
            this.button8.TabIndex = 16;
            this.button8.Text = "Włącz symulator";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGridMessages
            // 
            this.dataGridMessages.AllowUserToAddRows = false;
            this.dataGridMessages.AllowUserToDeleteRows = false;
            this.dataGridMessages.AllowUserToOrderColumns = true;
            this.dataGridMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridMessages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Direction,
            this.canId,
            this.DataLength,
            this.Data,
            this.ASCII,
            this.Extended,
            this.Period,
            this.Count,
            this.TimeStamp});
            this.dataGridMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridMessages.EnableHeadersVisualStyles = false;
            this.dataGridMessages.Location = new System.Drawing.Point(0, 0);
            this.dataGridMessages.MultiSelect = false;
            this.dataGridMessages.Name = "dataGridMessages";
            this.dataGridMessages.ReadOnly = true;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridMessages.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridMessages.RowHeadersVisible = false;
            this.dataGridMessages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridMessages.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridMessages.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridMessages.Size = new System.Drawing.Size(870, 354);
            this.dataGridMessages.TabIndex = 17;
            // 
            // Direction
            // 
            this.Direction.DataPropertyName = "Direction";
            this.Direction.HeaderText = "DIR";
            this.Direction.Name = "Direction";
            this.Direction.ReadOnly = true;
            this.Direction.Width = 51;
            // 
            // canId
            // 
            this.canId.DataPropertyName = "CanId";
            this.canId.HeaderText = "ID";
            this.canId.Name = "canId";
            this.canId.ReadOnly = true;
            this.canId.Width = 43;
            // 
            // DataLength
            // 
            this.DataLength.DataPropertyName = "DataLength";
            this.DataLength.HeaderText = "DLC";
            this.DataLength.Name = "DataLength";
            this.DataLength.ReadOnly = true;
            this.DataLength.Width = 53;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Data.DataPropertyName = "Data";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Data.DefaultCellStyle = dataGridViewCellStyle10;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // ASCII
            // 
            this.ASCII.DataPropertyName = "ASCII";
            this.ASCII.HeaderText = "ASCII";
            this.ASCII.Name = "ASCII";
            this.ASCII.ReadOnly = true;
            this.ASCII.Width = 59;
            // 
            // Extended
            // 
            this.Extended.DataPropertyName = "Extended";
            this.Extended.HeaderText = "EXT";
            this.Extended.Name = "Extended";
            this.Extended.ReadOnly = true;
            this.Extended.Width = 53;
            // 
            // Period
            // 
            this.Period.DataPropertyName = "Period";
            this.Period.HeaderText = "Period";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            this.Period.Width = 62;
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 60;
            // 
            // TimeStamp
            // 
            this.TimeStamp.DataPropertyName = "Time";
            this.TimeStamp.HeaderText = "Time";
            this.TimeStamp.Name = "TimeStamp";
            this.TimeStamp.ReadOnly = true;
            this.TimeStamp.Width = 55;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabMonitor);
            this.tabMain.Controls.Add(this.tabTrace);
            this.tabMain.Controls.Add(this.tabSimulator);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(884, 461);
            this.tabMain.TabIndex = 18;
            // 
            // tabMonitor
            // 
            this.tabMonitor.BackColor = System.Drawing.Color.Transparent;
            this.tabMonitor.Controls.Add(this.splitContainer1);
            this.tabMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabMonitor.Name = "tabMonitor";
            this.tabMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonitor.Size = new System.Drawing.Size(876, 435);
            this.tabMonitor.TabIndex = 0;
            this.tabMonitor.Text = "Monitor";
            // 
            // tabTrace
            // 
            this.tabTrace.Location = new System.Drawing.Point(4, 22);
            this.tabTrace.Name = "tabTrace";
            this.tabTrace.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrace.Size = new System.Drawing.Size(876, 435);
            this.tabTrace.TabIndex = 1;
            this.tabTrace.Text = "Trace";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridMessages);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button7);
            this.splitContainer1.Panel2.Controls.Add(this.button6);
            this.splitContainer1.Panel2.Controls.Add(this.button5);
            this.splitContainer1.Panel2.Controls.Add(this.txtPortName);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.txtInterval);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtCanData);
            this.splitContainer1.Panel2.Controls.Add(this.txtCanId);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Size = new System.Drawing.Size(870, 429);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 18;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(554, 43);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 24;
            this.button7.Text = "Config";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(79, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = ">>";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 78);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(8, 49);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(50, 20);
            this.txtInterval.TabIndex = 21;
            this.txtInterval.Text = "100";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(274, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "CanId";
            // 
            // txtCanData
            // 
            this.txtCanData.Location = new System.Drawing.Point(64, 23);
            this.txtCanData.Name = "txtCanData";
            this.txtCanData.Size = new System.Drawing.Size(204, 20);
            this.txtCanData.TabIndex = 17;
            this.txtCanData.Text = "55,55,55,55,55,55,55,55";
            // 
            // txtCanId
            // 
            this.txtCanId.Location = new System.Drawing.Point(8, 23);
            this.txtCanId.Name = "txtCanId";
            this.txtCanId.Size = new System.Drawing.Size(50, 20);
            this.txtCanId.TabIndex = 16;
            this.txtCanId.Text = "0x7FF";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabSimulator
            // 
            this.tabSimulator.Controls.Add(this.labTelemetry);
            this.tabSimulator.Controls.Add(this.button8);
            this.tabSimulator.Controls.Add(this.maskedTextBox1);
            this.tabSimulator.Location = new System.Drawing.Point(4, 22);
            this.tabSimulator.Name = "tabSimulator";
            this.tabSimulator.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimulator.Size = new System.Drawing.Size(876, 435);
            this.tabSimulator.TabIndex = 2;
            this.tabSimulator.Text = "Simulator";
            this.tabSimulator.UseVisualStyleBackColor = true;
            // 
            // MainPresenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.tabMain);
            this.Name = "MainPresenter";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMessages)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabMonitor.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabSimulator.ResumeLayout(false);
            this.tabSimulator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPortName;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.RichTextBox labTelemetry;
        private System.Windows.Forms.Button button8;
        private Interface.Control.FastDataGridView dataGridMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn canId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASCII;
        private System.Windows.Forms.DataGridViewTextBoxColumn Extended;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabMonitor;
        private System.Windows.Forms.TabPage tabTrace;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCanData;
        private System.Windows.Forms.TextBox txtCanId;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabSimulator;
    }
}

