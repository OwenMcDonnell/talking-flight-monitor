using NLog;
using NLog.Common;
using System.IO;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.Properties
{
    public static class TFMDatabase
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static string _databaseLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Talking flight monitor\data\");
        private static  string _databaseFileName = "TFM.db";
        private static string _completeDatabasePath = Path.Combine(_databaseLocation, _databaseFileName);
        private static string _connectionString = $"URI = file:{_completeDatabasePath}";
        private static SQLiteConnection _connection;
        
        // SQLite version number. Used in logs.
        public static string Version
        {
            get
            {
if(Exists() == true)
                {
                    _connection.Open();
                    var version = string.Empty;
                    using(var command = new SQLiteCommand(_connection))
                    {
                        command.CommandText = "select sqlite_version()";
                        version =  command.ExecuteScalar().ToString();
                    }
                    return version;
                }
                    
                else
                {

                    // Return -1 if the database isn't created.
                    Logger.Debug("Database not found. Failed to get SQLite version number.");
                    return "-1";
                }
            }
        }
        public static bool Exists()
        {
            if(File.Exists(_completeDatabasePath) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        } // Exists

        private static bool TableExists(string tableName)
        {
            if(Exists() == true)
            {
if(_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                using (var command = new SQLiteCommand(_connection))
                {
                    command.CommandText = $"SELECT name FROM sqlite_master WHERE type = 'table' AND name = @table_name";
                    command.Parameters.AddWithValue("@table_name", tableName);
                    command.Prepare();
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {

                        // Requesting the table name failed.
                        return false;
                    }
                    reader.Close();
                }
            }  // Database exists.
            else
            {
                
                // The database doesn't exist yet.
                return false;
            }
        }  // TableExists.

public static  void Initialize()
        {
                        if(Exists()== true)
            {
                Logger.Info("TFM database exists. Skipping install.");
                _connection = new SQLiteConnection(_connectionString);
                                return;
            }
            else
            {
                Logger.Info("Starting TFM database install...");
                if(Directory.Exists(_databaseLocation) == false)
                {
                    Logger.Info($"Creating {_databaseLocation}");
                    Directory.CreateDirectory(_databaseLocation);
                }
                else
                {
                    Logger.Info("TFM database location already present... skipping.");
                }
                                                
                SQLiteConnection.CreateFile(_completeDatabasePath);
                _connection = new SQLiteConnection(_connectionString);
                if(_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                CreateSpeechHistoryTable();
                Logger.Info("TFM database created.");
                                            } // is initialized
                   } // Initialize

                                    private static void CreateSpeechHistoryTable(bool overWrite = false)
            {
var sql                 = "create table SpeechHistory(" +
         "ID integer primary key," +
         "Message varchar(1024) not null," +
         "Date datetime default current_timestamp not null)";


if(overWrite == true)
            {
                Logger.Info("SpeechHistory table is present... Deleting and recreating it.");
                if (_connection.State == System.Data.ConnectionState.Closed) _connection.Open();
                using (var command = new SQLiteCommand(_connection))
                {
                    command.CommandText = "if exists drop table SpeechHistory";
                    command.ExecuteNonQuery();
                                    }
                _connection.Close();
            }
else if(overWrite == false && TableExists("SpeechHistory") == true)
            {
                Logger.Info("Speech history table is present... Skipping.");
                return;
            }
            else
            {
                                if (_connection.State == System.Data.ConnectionState.Closed) _connection.Open();
                using(var command = new SQLiteCommand(_connection))
                {
                    Logger.Info("Creating Speech history table.");
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                                    }
                _connection.Close();
            }
            } // CreateHistoryTable
        public static  bool InsertSpeechHistoryItem(string item)
        {
                        using(var command = new SQLiteCommand(_connection))
            {
                if (_connection.State == System.Data.ConnectionState.Closed) _connection.Open();
                command.CommandText = "insert into SpeechHistory (Message) values(@message)";
                command.Parameters.AddWithValue("@message", item);
                command.Prepare();
                var rowCount = command.ExecuteNonQuery();
                   if(rowCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                           }
        } // InsertSpeechItem

        public static List<string> GetAllSpeechHistoryItems()
        {
            List<string> SpeechHistoryItems = new List<string>();
            using(var command = new SQLiteCommand(_connection))
            {
                if (_connection.State == System.Data.ConnectionState.Closed) _connection.Open();
                command.CommandText = "select * from SpeechHistory";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Properties.Settings.Default.SpeechHistoryTimestamps)
                    {
                        SpeechHistoryItems.Add($"{reader.GetString(1)}({reader.GetDateTime(2)})");
                    }
                    else
                    {
                        SpeechHistoryItems.Add($"{reader.GetString(1)}");
                    }
                }
                return SpeechHistoryItems;
            }
        }// GetAllSpeechHistoryItems

        public static  int DeleteAllSpeechHistoryItems()
        {
            using(var command = new SQLiteCommand(_connection))
            {
                if (_connection.State == System.Data.ConnectionState.Closed) _connection.Open();
                                command.CommandText = "delete  from SpeechHistory";
                var recordCount = command.ExecuteNonQuery();
                return recordCount;
            }
        } // DeleteAllSpeechHistoryItems
            } // TFMDatabase
}