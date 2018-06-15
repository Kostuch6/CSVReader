using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class DataGridHandler
    {
        public DataTable dataTable = new DataTable();

        public Random rand { get; set; }


        public DataTable FillDataGrid()
        {
            rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                dataTable.Columns.Add("Column " + i);
            }
            for (int i = 0; i < 5; i++)
            {
                dataTable.Rows.Add(new object[] { rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble()});
            }
            return dataTable;
        }

        public void LoadDataGridOnView()
        {

        }

        public void updateDataGrid()
        {

        }
    }
}
