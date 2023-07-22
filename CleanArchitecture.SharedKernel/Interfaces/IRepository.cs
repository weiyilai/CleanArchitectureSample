using Ardalis.Specification;

namespace CleanArchitecture.SharedKernel.Interfaces;

/// <summary>
/// IRepositoryBase from Ardalis.Specification
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
