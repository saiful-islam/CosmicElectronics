using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IslamTraders_Accounts.Models
{
    public class DataOperation
    {
        string strConn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public DataTable GetDataTable(string _query)
        {
            SqlConnection _sqlConnection = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            SqlDataAdapter _da = new SqlDataAdapter(_query, _sqlConnection);
            _da.Fill(dt);
            _sqlConnection.Close();
            return dt;
        }
        public bool ExecuteNonQuery(string _query)
        {
            SqlConnection _sqlConnection = new SqlConnection(strConn);
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            SqlCommand _command = new SqlCommand(_query, _sqlConnection);
            try
            {
                _command.ExecuteNonQuery();
                _sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}