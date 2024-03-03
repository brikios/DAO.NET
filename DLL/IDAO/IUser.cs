using System;
using DLL.Entities;
namespace DLL.IDAO
{
	public interface IUser
	{
		public bool addUser(User user);
		public List<User> RecupererUtilisateur();
	}
}

