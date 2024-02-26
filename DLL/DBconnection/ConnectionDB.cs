using System;
using MySql.Data.MySqlClient;
namespace DLL.DBconnection
{
	public class ConnectionDB
	{
		private static ConnectionDB _Instance;
		private  static MySqlConnection _con;

		private ConnectionDB(string connectionString)
		{
			_con = new MySqlConnection(connectionString);
        }

        public static ConnectionDB getInstance(string connectionString)
			{
				if (_Instance == null)
				{
					_Instance = new ConnectionDB(connectionString);
				}
			return _Instance;
			}
        public MySqlConnection GetConnection() => _con;

    }
}

