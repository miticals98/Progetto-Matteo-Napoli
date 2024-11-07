using Progetto_Matteo_Napoli.Utils;

namespace Progetto_Matteo_Napoli.Services.Interfaces
{
	public interface ICrudServiceBase<TEntity,TDto>
	{ 
		public bool Create(TEntity tEntity);
		public TEntity Read(int id);

		public bool Update(TEntity tEntity);

		public bool Delete(TEntity tEntity);

	}
}
