﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Data;

namespace Nop.Data
{
    public class DataOperationForLib
    {
        public DataTable GetDataTable(string _query)
        {
            DataSettingsManager _dataSettingsManager = new DataSettingsManager();
            DataSettings _dataSettings = _dataSettingsManager.LoadSettings();
            SqlConnection _sqlConnection = new SqlConnection(_dataSettings.DataConnectionString + ";Connection Timeout=0");
            DataTable dt = new DataTable();
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            SqlDataAdapter _da = new SqlDataAdapter(_query, _sqlConnection);
            _da.Fill(dt);
            return dt;
        }
        public bool ExecuteNonQuery(string _query)
        {
            DataSettingsManager _dataSettingsManager = new DataSettingsManager();
            DataSettings _dataSettings = _dataSettingsManager.LoadSettings();
            SqlConnection _sqlConnection = new SqlConnection(_dataSettings.DataConnectionString + ";Connection Timeout=0");
            DataTable dt = new DataTable();
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            SqlCommand _command = new SqlCommand(_query, _sqlConnection);
            try
            {
                _command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
