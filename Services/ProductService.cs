using Progetto_Matteo_Napoli.Models;
using Progetto_Matteo_Napoli.Services.Interfaces;
using Progetto_Matteo_Napoli.Utils;

namespace Progetto_Matteo_Napoli.Services
{
	public class ProductService : ICrudServiceBase<Product, ProductDTO>
	{
		private List<Product> products = new List<Product>()
		{
			new Product()
			{
				Price=20.52M,
				Name="Libro",
				Id = 1
			}
		};
		public bool Create(Product tEntity)
		{
			try
			{
				//incremento l'id perché non ho implementato un db
				tEntity.Id = products.Any() ? products.MaxBy(x => x.Id).Id + 1 : 1;
				products.Add(tEntity);
				return true;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public bool Delete(Product tEntity)
		{
			try
			{
				if (tEntity is { } && products.Select(x => x.Id).Contains(tEntity.Id))
				{
					products.RemoveAt(products.FindIndex(x=>x.Id == tEntity.Id));
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

		public Product Read(int id)
		{
			try
			{
				return products.Find(x => x.Id == id);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public bool Update(Product tEntity)
		{
			try
			{
				Product user;
				if (tEntity is { } && (user = products.Find(x => x.Id == tEntity.Id)) is { })
				{
					user.Price = tEntity.Price;
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
