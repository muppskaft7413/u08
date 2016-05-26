using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift08 
{
    class postgres
    {
        private NpgsqlConnection _conn;
        private NpgsqlCommand _cmd;
        private NpgsqlDataReader _dr;
        private DataTable _tabell;


        /// <summary>
        /// konstruktor som öppnar en connection mot databasen så fort en instans skapas av klassen.
        /// </summary>
        public postgres()
        {
            _conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["db_g12"].ConnectionString);
            _conn.Open();
            _tabell = new DataTable();
        }

        /// <summary>
        /// Metod för att ställa fråga mot sql.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private DataTable sqlfråga(string sql)
        {
            try
            {
                _cmd = new NpgsqlCommand(sql, _conn);
                _dr = _cmd.ExecuteReader();
                _tabell.Load(_dr);
                return _tabell;
            }
            catch (NpgsqlException ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                DataColumn c1 = new DataColumn("error");
                DataColumn c2 = new DataColumn("errorMessage");


                c1.DataType = System.Type.GetType("System.Boolean");
                c2.DataType = System.Type.GetType("System.String");

                _tabell.Columns.Add(c1);
                _tabell.Columns.Add(c2);

                //skapa rad
                DataRow rad = _tabell.NewRow();
                rad[c1] = true;
                rad[c2] = ex.Message;
                _tabell.Rows.Add(rad);

                return _tabell;
            }

            // Måste det itne gå att stänga?
            //finally
            //{
            //    _conn.Close();
            //}
        }


    }
}
