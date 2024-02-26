using System;
namespace DLL.Entities
{
    public class User
    {
        public int _id { get; set; }
        public string _nom { get; set; }
        public string _prenom { get; set; }
        public string _email { get; set; }
        public string _password { get; set; }
        public User(int _id,string _nom, string _prenom, string _email, string _password)
        {
            this._id = _id;
            this._nom = _nom;
            this._prenom = _prenom;
            this._email = _email;
            this._password = _password;
        }
    }
}

