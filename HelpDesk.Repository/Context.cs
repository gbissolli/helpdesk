using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Repository
{
    public class Context : IDisposable
    {
        private IDbConnection _conn { get; set; }

        /// <summary>
        /// Return open connection
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                return _conn;
            }
        }

        /// <summary>
        /// Create a new Sql database connection
        /// </summary>
        /// <param name="connString">The name of the connection string</param>
        public Context(string connStringName)
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connStringName].ConnectionString);
        }

        /// <summary>
        /// Create a new Sql database connection
        /// </summary>
        public Context()
        {
            _conn = new SqlConnection(this.GetConnectionString());
        }

        /// <summary>
        /// Get connection string from app settings
        /// </summary>
        public string GetConnectionString()
        {
            var connStringName = "HelpDesk";

            //if (string.Equals(ConfigurationManager.AppSettings["mgm.environment"], "production"))
            //    connStringName = "Prod";

            return ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
        }

        /// <summary>
        /// Close and dispose of the database connection
        /// </summary>
        public void Dispose()
        {
            if (_conn != null)
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                    _conn.Dispose();
                }
                _conn = null;
            }
        }
    }
}
