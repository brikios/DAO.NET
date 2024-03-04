using System.Collections.Generic;
using DLL.DAOImp;
using DLL.DBconnection;
using DLL.Entities;
using DLL.IDAO;
namespace Main;
class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=gestionUtilisateur;Uid=root;Pwd=;Port=3306;";
        ConnectionDB con = ConnectionDB.getInstance(connectionString);
        Mutex mutex = new Mutex();
        IUser User = new DAOImpUser(con);
        List<User> user = new List<User>();

        #region Insert Fake Data in DB
        void insertFakeData()
        {
            try
            {
                con.GetConnection().Open();
                for (int i = 0; i <= 50; i++)
                {
                    User u = new User(i, $"mouadh{i}", $"briki{i}", $"mouadh.briki{i}@gmail.com", $"12360{i}");
                    bool UserAdded = User.addUser(u);
                    if (UserAdded)
                    {
                        Console.WriteLine("User added successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add user");
                    }
                    //Thread.Sleep(10000);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con.GetConnection().State == System.Data.ConnectionState.Open)
                {
                    con.GetConnection().Close();
                }
            }
        }
        #endregion

        #region reading data from db
        void read(ConsoleColor color)
        {
            try
            {
                mutex.WaitOne();
                con.GetConnection().Open();
                List<User> uses = User.RecupererUtilisateur();
                foreach (User u in uses)
                {
                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = color;

                    Console.WriteLine($"{u._nom}");
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (con.GetConnection().State == System.Data.ConnectionState.Open)
                {
                    con.GetConnection().Close();
                }
                mutex.ReleaseMutex();
            }

        }
        #endregion

        Thread t1 = new Thread(() => read(ConsoleColor.Green));
        Thread t2 = new Thread(() => read(ConsoleColor.Red));
        t1.Start();
        t2.Start();
    }
}


