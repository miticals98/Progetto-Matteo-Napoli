using Progetto_Matteo_Napoli.Models;

namespace Progetto_Matteo_Napoli.Utils
{
	public static class Translate
	{
		public static ProductDTO ProductToDTO(Product prod)
		{
			return new ()
			{
				id = prod.Id,
				name = prod.Name,
				price = prod.Price,
			};
		}
		public static Product DTOToProduct(ProductDTO prod)
		{
			return new()
			{
				Id = prod.id,
				Name = prod.name,
				Price = prod.price
			};
		}
		public static UserDTO UserToDTO(User user)
		{
			return new()
			{
				id = user.Id,
				name = user.Name,
				email = user.Email,
			};
		}
		public static User DTOToUser(UserDTO user)
		{
			return new()
			{
				Id = user.id,
				Name = user.name,
				Email = user.email
			};
		}
	}
}
