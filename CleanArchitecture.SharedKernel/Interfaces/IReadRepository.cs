using Ardalis.Specification;

namespace CleanArchitecture.SharedKernel.Interfaces;

/// <summary>
/// IReadRepositoryBase from Ardalis.Specification
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}