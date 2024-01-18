using System;
using Core.Entities;

namespace Core.Interfaces
{
	//  Base Entity is used because we have inherited other entities from this
	// Reason of creating BaseEntity was to use with Generics
	public interface IGenericRepository<T> where T: BaseEntity
	{
		Task<T> GetByIdAsync(int id);

		Task<IReadOnlyList<T>> ListAllAsync();
	}
}

