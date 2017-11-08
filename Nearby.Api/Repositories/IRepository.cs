using System;
using System.Threading.Tasks;
using Nearby.Api.Data;

namespace Nearby.Api.Repositories
{
    public interface IRepository
    {
        Task<Subscription> Save(Subscription sub);
    }
}
