namespace CSVReader
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.chooseFile = new System.Windows.Forms.Button();
			this.saveData = new System.Windows.Forms.Button();
			this.clearData = new System.Windows.Forms.Button();
			this.comboBoxX = new System.Windows.Forms.ComboBox();
			this.comboBoxY = new System.Windows.Forms.ComboBox();
			this.labelX = new System.Windows.Forms.Label();
			this.labelY = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.drawChartButton = new System.Windows.Forms.Button();
			this.comboBoxChartType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(784, 12);
			this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chart1.Name = "chart1";
			this.chart1.Size = new System.Drawing.Size(556, 441);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(764, 441);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
			// 
			// chooseFile
			// 
			this.chooseFile.Location = new System.Drawing.Point(15, 501);
			this.chooseFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chooseFile.Name = "chooseFile";
			this.chooseFile.Size = new System.Drawing.Size(75, 42);
			this.chooseFile.TabIndex = 2;
			this.chooseFile.Text = "Wybierz plik";
			this.chooseFile.UseVisualStyleBackColor = true;
			this.chooseFile.Click += new System.EventHandler(this.button1_Click);
			// 
			// saveData
			// 
			this.saveData.Location = new System.Drawing.Point(95, 501);
			this.saveData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.saveData.Name = "saveData";
			this.saveData.Size = new System.Drawing.Size(81, 42);
			this.saveData.TabIndex = 3;
			this.saveData.Text = "Zapisz";
			this.saveData.UseVisualStyleBackColor = true;
			this.saveData.Click += new System.EventHandler(this.saveData_Click);
			// 
			// clearData
			// 
			this.clearData.Location = new System.Drawing.Point(181, 501);
			this.clearData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.clearData.Name = "clearData";
			this.clearData.Size = new System.Drawing.Size(83, 42);
			this.clearData.TabIndex = 4;
			this.clearData.Text = "Wyczyść dane";
			this.clearData.UseVisualStyleBackColor = true;
			this.clearData.Click += new System.EventHandler(this.clearData_Click);
			// 
			// comboBoxX
			// 
			this.comboBoxX.FormattingEnabled = true;
			this.comboBoxX.Location = new System.Drawing.Point(781, 501);
			this.comboBoxX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxX.Name = "comboBoxX";
			this.comboBoxX.Size = new System.Drawing.Size(121, 24);
			this.comboBoxX.TabIndex = 5;
			// 
			// comboBoxY
			// 
			this.comboBoxY.FormattingEnabled = true;
			this.comboBoxY.Location = new System.Drawing.Point(935, 501);
			this.comboBoxY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxY.Name = "comboBoxY";
			this.comboBoxY.Size = new System.Drawing.Size(121, 24);
			this.comboBoxY.TabIndex = 6;
			// 
			// labelX
			// 
			this.labelX.AutoSize = true;
			this.labelX.Location = new System.Drawing.Point(781, 478);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(91, 17);
			this.labelX.TabIndex = 7;
			this.labelX.Text = "Wybierz oś X";
			// 
			// labelY
			// 
			this.labelY.AutoSize = true;
			this.labelY.Location = new System.Drawing.Point(932, 478);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(91, 17);
			this.labelY.TabIndex = 8;
			this.labelY.Text = "Wybierz oś Y";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// drawChartButton
			// 
			this.drawChartButton.Location = new System.Drawing.Point(1085, 501);
			this.drawChartButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.drawChartButton.Name = "drawChartButton";
			this.drawChartButton.Size = new System.Drawing.Size(75, 24);
			this.drawChartButton.TabIndex = 9;
			this.drawChartButton.Text = "Rysuj";
			this.drawChartButton.UseVisualStyleBackColor = true;
			this.drawChartButton.Click += new System.EventHandler(this.drawChartButton_Click);
			// 
			// comboBoxChartType
			// 
			this.comboBoxChartType.FormattingEnabled = true;
			this.comboBoxChartType.Location = new System.Drawing.Point(781, 583);
			this.comboBoxChartType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxChartType.Name = "comboBoxChartType";
			this.comboBoxChartType.Size = new System.Drawing.Size(121, 24);
			this.comboBoxChartType.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(780, 558);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 17);
			this.label1.TabIndex = 11;
			this.label1.Text = "Wybierz rodzaj wykresu";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1351, 626);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxChartType);
			this.Controls.Add(this.drawChartButton);
			this.Controls.Add(this.labelY);
			this.Controls.Add(this.labelX);
			this.Controls.Add(this.comboBoxY);
			this.Controls.Add(this.comboBoxX);
			this.Controls.Add(this.clearData);
			this.Controls.Add(this.saveData);
			this.Controls.Add(this.chooseFile);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.chart1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "Form1";
			this.Text = "CSVReader";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button chooseFile;
        private System.Windows.Forms.Button saveData;
        private System.Windows.Forms.Button clearData;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button drawChartButton;
		private System.Windows.Forms.ComboBox comboBoxChartType;
		private System.Windows.Forms.Label label1;
	}
}

