using NLog;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace tfm.Properties.Data.Navigraph
{
    public class NavigraphContext: DbContext
    {

        // Private fields.
        #region
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private string _databaseFile = "e_dfd.s3db";
        private string _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"tfm\Navdata\");
        private string _targetDatabase = string.Empty;
        private string _sourceDatabase = string.Empty;
        private string _connectionString = string.Empty;

        #endregion
        
        // Table sets
        #region
        public DbSet<NavigraphHeader> navigraphHeaders { get; set; }
        public DbSet<VhfNavaid> vhfNavaids { get; set; }
        public DbSet<EnrouteNDB> enrouteNDBs { get; set; }
        #endregion
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            _targetDatabase = Path.Combine(_databasePath, _databaseFile);
            optionsBuilder.UseSqlite($"Data Source = {_targetDatabase}");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public void InstallDefaultDatabase()
        {
            _sourceDatabase = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data\e_dfd_2205.s3db");
            _targetDatabase = Path.Combine(_databasePath, _databaseFile);
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
                catch (Exception ex)
                {
                    _logger.Error($"Failed to install default database: {ex.Message}");
                }
            }
            #endregion


        } //InstallDefaultDatabase.

    }
}
