using System;
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

        private void chooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                string[] fileLines;
                string[] fileCells;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var x = openFileDialog1.FileName;
                    //StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    fileLines = File.ReadAllLines(openFileDialog1.FileName);
                    fileCells = fileLines[0].Split(new char[] { ',' });
                    int length = fileLines.Length;

                }


            }
            catch (Exception ex)
            {

            }

        }
    }
}
