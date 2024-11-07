using Progetto_Matteo_Napoli.Models;
using Progetto_Matteo_Napoli.Services.Interfaces;
using Progetto_Matteo_Napoli.Utils;

namespace Progetto_Matteo_Napoli.Services
{
	public class UserService : ICrudServiceBase<User, UserDTO>
	{
		private List<User> users = new List<User>()
		{
			new User()
			{
				Email="matteo.napoli721@gmail.com",
				Name="Matteo Napoli",
				Id = 1
			}
		};
		public bool Create(User tEntity)
		{
			try
			{
				//incremento l'id perché non ho implementato un db
				tEntity.Id = users.Any() ? users.MaxBy(x => x.Id).Id + 1 : 1;
				users.Add(tEntity);
				return true;
			}catch (Exception)
			{
				throw;
			}
		}

		public bool Delete(User tEntity)
		{
			try
			{
				if (tEntity is { } && users.Select(x => x.Id).Contains(tEntity.Id))
				{
					users.RemoveAt(users.FindIndex(x => x.Id == tEntity.Id));					
					return true;
				}
				else
				{
					return false;
				}
				
			}
			catch (Exception)
			{
				throw;
			}
		}

		public User Read(int id)
		{
			try
			{
				return users.Find(x => x.Id == id);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public bool Update(User tEntity)
		{
			try
			{
				User user;
				if (tEntity is { } && (user = users.Find(x => x.Id == tEntity.Id)) is { })
				{
					user.Email = tEntity.Email;
					user.Name = tEntity.Name;
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
