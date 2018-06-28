using CSVReader.Handlers;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CSVReader
{
    /// <summary>
    /// Autorzy:
    /// inż. Monika Berendt-Marchel
    /// inż. Tomasz Kucharczyk
    /// inż. Jakub Mańkowski
    /// inż. Łukasz Marchel
    /// </summary>
    public partial class Form1 : Form
    {
        private string loadedFileName;
		private DataTable dataTable;
        private bool dataSourceChanged;

        public Form1()
        {
            InitializeComponent();

            #region fileDialog
            openFileDialog1.Multiselect = false;
            openFileDialog1.DefaultExt = "csv";
            openFileDialog1.Filter = "Pliki .csv (*.csv) |*.csv";
            openFileDialog1.FileName = "";

            saveFileDialog1.Filter = "Pliki .csv (*.csv) |*.csv";
            #endregion

            #region buttons
            saveData.Enabled = false;
            clearData.Enabled = false;
            #endregion

            #region chartType comboBox
            comboBoxChartType.Items.Add(SeriesChartType.Line);
			comboBoxChartType.Items.Add(SeriesChartType.Bar);
			comboBoxChartType.Items.Add(SeriesChartType.Column);
			comboBoxChartType.Items.Add(SeriesChartType.Pie);
			comboBoxChartType.Items.Add(SeriesChartType.Point);
			#endregion

			chart1.Series.Add("Series");
		}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataTable = FileHandler.UploadFile(loadedFileName, saveFileDialog1, openFileDialog1, dataGridView1);
                if (dataTable == null)
                {
                    return;
                }                 
                else
                {
                    loadedFileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    dataSourceChanged = false;
                    clearData.Enabled = true;
                }

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;

				resetChart();

                populateComboBoxes(dataTable);
                saveData.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageHandler.ShowError(ex);
            }
        }

		private void resetChart()
		{
            chart1.Series["Series"].Points.Clear();
			comboBoxX.Items.Clear();
			comboBoxX.Text = "";
			comboBoxY.Items.Clear();
			comboBoxY.Text = "";
		}

		private void populateComboBoxes(DataTable dataTable)
        {
			foreach (DataColumn item in dataTable.Columns)
            {
                comboBoxX.Items.Add(item.ColumnName);
				comboBoxY.Items.Add(item.ColumnName);
            }
		}

        private void saveData_Click(object sender, EventArgs e)
        {
            FileHandler.SaveFile(loadedFileName, saveFileDialog1, dataGridView1);
        }

		private void drawChartButton_Click(object sender, EventArgs e)
		{
			if (dataTable == null)
			{
				MessageHandler.ShowMessage("Błąd!", "Należy otworzyć plik .csv.");
			}
			else if (comboBoxX.SelectedItem == null || comboBoxY.SelectedItem == null)
			{
				MessageHandler.ShowMessage("Błąd!", "Do wykonania wykresu wymagany jest wybór obu kolumn.");
			}
			else if(comboBoxChartType.SelectedItem == null)
			{
				MessageHandler.ShowMessage("Błąd!", "Należy wybrać rodzaj wykresu.");
			}
			else
			{
				chart1.Series["Series"].Points.Clear();

				String xAxisName = comboBoxX.SelectedItem.ToString();
				String yAxisName = comboBoxY.SelectedItem.ToString();

				DataColumn xColumn = dataTable.Columns[xAxisName];
				DataColumn yColumn = dataTable.Columns[yAxisName];

				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					chart1.Series["Series"].Points.AddXY(dataTable.Rows[i][xColumn], dataTable.Rows[i][yColumn]);
					chart1.Series["Series"].ChartType = (SeriesChartType)comboBoxChartType.SelectedItem;
                }
			}
		}

        private void clearData_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataSourceChanged)
                {
                    if (MessageHandler.ShowMessageQuestion("Zapisać zmiany?", "Czy chcesz zapisać zmiany przed otwarciem nowego pliku?"))
                        FileHandler.SaveFile(loadedFileName, saveFileDialog1, dataGridView1);
                }

                saveData.Enabled = false;
                clearData.Enabled = false;
                dataGridView1.DataSource = null;
				resetChart();
			}
            catch (Exception ex)
            {
                MessageHandler.ShowError(ex);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataSourceChanged = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dataSourceChanged)
            {
                if (MessageHandler.ShowMessageQuestion("Zapisać zmiany?", "Czy chcesz zapisać zmiany przed zamknięciem aplikacji?"))
                    FileHandler.SaveFile(loadedFileName, saveFileDialog1, dataGridView1);
            }        
        }
    }
}
