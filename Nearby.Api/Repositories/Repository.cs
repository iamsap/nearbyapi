using System;
using System.Threading.Tasks;
using Nearby.Api.Data;

namespace Nearby.Api.Repositories
{
    public class Repository : IRepository
    {
        public Repository()
        {
        }

        public async Task<Subscription> Save(Subscription sub)
        {
            return await Task.FromResult(sub);
        }
    }
}
