using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CSVReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region fileDialog
            openFileDialog1.Multiselect = false;
            openFileDialog1.DefaultExt = "csv";
            openFileDialog1.Filter = "Pliki .csv (*.csv) |*.csv";
            openFileDialog1.FileName = "";
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
                        dr = dt.NewRow();
                        for (int f = 0; f < columns; f++)
                            dr[f] = fileCells[f];
                        dt.Rows.Add(dr);
                    }

                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
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
    }
}
