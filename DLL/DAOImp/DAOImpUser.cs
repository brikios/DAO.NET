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
                _cmd.Parameters.Clear();
                string request = "INSERT INTO User (id, nom, prenom, email, password) VALUES (@Id,@nom,@prenom,@email,@password)";
                _cmd.Parameters.AddWithValue("@Id", user._id);
                _cmd.Parameters.AddWithValue("@nom", user._nom);
                _cmd.Parameters.AddWithValue("@prenom", user._prenom);
                _cmd.Parameters.AddWithValue("@email", user._email);
                _cmd.Parameters.AddWithValue("@password", user._password);
                _cmd.CommandText=request;
                _cmd.ExecuteNonQuery();
                return true;
            }catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<User> RecupererUtilisateur()
        {
            string request = "SELECT * FROM User";
            _cmd.CommandText = request;
            MySqlDataReader reader = _cmd.ExecuteReader();
            List < User > uses= new List<User>();
            try
            {
                while (reader.Read())
                {
                    User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    uses.Add(user);
                }
            }
            catch(MySqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                reader.Close();
            }
            return uses;
        }
    }
}

