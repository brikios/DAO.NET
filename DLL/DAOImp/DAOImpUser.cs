using System;
using DLL.Entities;
using DLL.IDAO;
using DLL.DBconnection;
using MySql.Data.MySqlClient;

namespace DLL.DAOImp
{
    public class DAOImpUser : IUser
	{
        MySqlConnection _con;
        MySqlCommand _cmd;
		public DAOImpUser(ConnectionDB db)
		{
            _con = db.GetConnection();
            _cmd= new MySqlCommand();
            _cmd.Connection = _con;
		}

        public bool addUser(User user)
        {
            try
            {
                string request = $"INSERT INTO User (id, nom, prenom, email, password) VALUES ({user._id}, '{user._nom}', '{user._prenom}', '{user._email}', '{user._password}')";
                _cmd.CommandText=request;
                _cmd.ExecuteNonQuery();
                return true;
            }catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

