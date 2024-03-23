﻿using Npgsql;
using System.Data;

namespace PercobaanAPI.Helpers
{
    public class SqlDBHelper
    {
        private NpgsqlConnection connection;
        private string __constr;
        public SqlDBHelper(string pC0nstr)
        {
            __constr = pC0nstr;
            connection = new NpgsqlConnection();
            connection.ConnectionString = __constr;
        }

        public NpgsqlCommand GetNpgsqlCommand(string query)
        {
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        public void closeConnections()
        {
            connection.Close();
        }
    }
}