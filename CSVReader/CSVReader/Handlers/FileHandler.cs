using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVReader.Handlers
{
    public static class FileHandler
    {
        public static void SaveFile(string fileName, SaveFileDialog saveFileDialog, DataGridView dataGridView)
        {
            try
            {
                saveFileDialog.FileName = fileName + "_new.csv";
                var dataSource = dataGridView;
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
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;
                    if (Path.GetExtension(path).ToLower() != ".csv")
                        path = Path.GetFileNameWithoutExtension(path) + ".csv";
                    File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                    MessageHandler.ShowMessage("Sukces", "Pomyślnie zapisano plik!");
                }
                sb.Clear();
            }
            catch (Exception ex)
            {
                MessageHandler.ShowError(ex);
            }
        }

        public static DataTable UploadFile(string fileName, SaveFileDialog saveFileDialog, OpenFileDialog openFileDialog, DataGridView dataGridView)
        {
            try
            {
                if (dataGridView.DataSource != null)
                {
                    if (MessageHandler.ShowMessageQuestion("Zapisać zmiany?", "Czy chcesz zapisać zmiany przed otwarciem nowego pliku?"))
                        FileHandler.SaveFile(fileName, saveFileDialog, dataGridView);
                }

                openFileDialog.FileName = "";
                string[] fileLines;
                string[] fileCells;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(openFileDialog.FileName).ToLower() != ".csv")
                    {
                        MessageHandler.ShowError("Plik nie posiada rozszerzenia .csv!");
                        return null;
                    }

                    fileLines = File.ReadAllLines(openFileDialog.FileName);
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
                    //loadedFileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    //dataSourceChanged = false;
                    //clearData.Enabled = true;
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
    }
}
