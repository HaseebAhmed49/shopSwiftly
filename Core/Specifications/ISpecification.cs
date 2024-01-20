using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
	public interface ISpecification<T>
	{
		// Criteria
		Expression<Func<T, bool>> Criteria { get; }

		// Includes
		List<Expression<Func<T, object>>> Includes { get; }
	}
}

