namespace Progetto_Matteo_Napoli.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
	public class ProductDTO
	{
		public int id { get; set; }
		public string name { get; set; }
		public decimal price { get; set; }
	}
}
