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

    }
}
