using System.Reflection;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using NLog;
using NLog.Common;
using NLog.Config;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace tfm.Properties.Data
{
    public class NavigraphDataProvider
    {

        // Private fields
        #region
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private string _databaseFile = "e_dfd.s3db";
        private string _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"tfm\Navdata\");
        private string _targetDatabase = string.Empty;
        private string _sourceDatabase = string.Empty;
        private string _connectionString = string.Empty;
                        private SQLiteConnection _connection;
        #endregion

        // Private properties
        #region
        private string ConnectionString { get => _connectionString; set => _connectionString = value; }
        #endregion

        // Public properties.
        #region
        public string Version
        {
            get
            {
                string version = string.Empty;

                try
                {
                    using (var _command = new SQLiteCommand(_connection))
                    {
                        if (_connection.State == ConnectionState.Closed)
                            _connection.Open();

                        _command.CommandText = "SELECT current_airac, revision, effective_fromto, previous_fromto FROM tbl_header";
                        using (var reader = _command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string currentAirac = reader.GetString(0);
                                string revision = reader.GetString(1);
                                DateTime fromDate = DateTime.ParseExact(reader.GetString(2), "yyMMddHHmm", null);
                                DateTime toDate = DateTime.ParseExact(reader.GetString(3), "yyMMddHHmm", null);
                                version = $"{currentAirac} rev. {revision} ({fromDate.ToShortDateString()} to {toDate.ToShortDateString()})";
                            }
                            else
                            {
                                _logger.Warn("No rows found in the tbl_header table.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to read Navdata version: {ex.Message}");
                }

                return version;
            } // Get
        } // Version.
        #endregion
        
        // Public methods
        #region
        public void Initialize()
        {
            _sourceDatabase = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data\e_dfd_2205.s3db");
            _targetDatabase = Path.Combine(_databasePath, _databaseFile);
            _connectionString = $"URI = file: {_targetDatabase}";

            _connection = new SQLiteConnection(_connectionString);
            // Install default database if needed.
            #region
            if (!Directory.Exists(_databasePath))
            {
                _logger.Warn("Navigraph database folder does not exist... Creating it.");
                Directory.CreateDirectory(_databasePath);
            }

            if (!File.Exists(_targetDatabase))
            {
                try
                {
                    File.Copy(_sourceDatabase, _targetDatabase);
                    _logger.Info("Default Navigraph database installed.");
                }
                catch(Exception ex)
                {
                    _logger.Error($"Failed to install default database: {ex.Message}");
                }
            }
            #endregion
        
        
        } //Initialize
        
        public NavigraphDataProvider()
        {
            _targetDatabase = Path.Combine(_databasePath, _databaseFile);
            _connectionString = _connectionString = $"Data Source={_targetDatabase};Version=3;";
            _connection = new SQLiteConnection(ConnectionString);
        } // Constructor
        #endregion
    } // NavigraphDataProvider
} // tfm.Properties.Data namespace.
