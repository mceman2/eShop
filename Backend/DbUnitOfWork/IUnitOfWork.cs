using DbRepositories; // ??!?!?!?!?!?!?
using EfModels;
using System;

public interface IUnitOfWork
{
    UserRepository Users { get; }
    CartRepository Carts { get; }
    ProductRepository Products { get; }
    void Commit();
}
