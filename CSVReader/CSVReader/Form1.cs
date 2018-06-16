using CSVReader.Handlers;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            #region saveButton
            saveData.Enabled = false;
            #endregion
        }

        private DataTable uploadFile()
        {
            try
            {
                string[] fileLines;
                string[] fileCells;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(openFileDialog1.FileName).ToLower() != ".csv")
                    {
                        MessageHandler.ShowError("Plik nie posiada rozszerzenia .csv!");
                        return null;
                    }

                    fileLines = File.ReadAllLines(openFileDialog1.FileName);
                    fileCells = fileLines[0].Split(new char[] { ',' });

                    int columns = fileCells.GetLength(0);
                    DataTable dt = new DataTable();
                    for (int i = 0; i < columns; i++)
                    {
                        dt.Columns.Add(fileCells[i].ToLower(), typeof(string));
                    }
                    DataRow dr;

                    for (int i = 1; i < fileLines.GetLength(0); i++)
                    {
                        fileCells = fileLines[i].Split(new char[] { ',' });
                        if (!fileCells.All(x => x == ""))
                        {
                            dr = dt.NewRow();
                            for (int f = 0; f < columns; f++)
                                dr[f] = fileCells[f];
                            dt.Rows.Add(dr);
                        }                       
                    }

                    loadedFileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageHandler.ShowError(ex);
                return null;
            }
        }

        private void saveFile()
        {
            try
            {
                saveFileDialog1.FileName = loadedFileName + "_new.csv";
                var dataSource = dataGridView1;
                StringBuilder sb = new StringBuilder();
                //dodawanie nagłówków kolumn
                foreach (DataGridViewColumn column in dataSource.Columns)
                {
                    sb.Append(column.HeaderText + ",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.AppendLine();

                //dodawanie wartości z rzędów
                foreach (DataGridViewRow row in dataSource.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                            sb.Append(cell.Value.ToString() + ",");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.AppendLine();
                }

                //zapis pliku
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;
                    if (Path.GetExtension(path).ToLower() != ".csv")
                        path = Path.GetFileNameWithoutExtension(path) + ".csv";
                    File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
                    MessageHandler.ShowMessage("Sukces", "Pomyślnie zapisano plik!");
                }
                sb.Clear();
            }
            catch (Exception ex)
            {
                MessageHandler.ShowError(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //DataGridHandler dataGridHandler = new DataGridHandler();
                DataTable dataTable = uploadFile();
                if (dataTable == null)
                    return;

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;

                populateComboBoxX(dataTable);
                saveData.Enabled = true;
            }
            catch (Exception ex)
            {

            }


        }

        private void populateComboBoxX(DataTable dataTable)
        {
            comboBoxX.Items.Add(dataTable.Columns[0].ColumnName);

            foreach (DataColumn item in dataTable.Columns)
            {
                comboBoxX.Items.Add(item.ColumnName);
            }
        }

        private void saveData_Click(object sender, EventArgs e)
        {
            saveFile();
        }
    }
}
