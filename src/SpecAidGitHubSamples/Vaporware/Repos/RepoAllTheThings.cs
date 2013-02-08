using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecAidGitHubSamples.Vaporware.Entities;

namespace SpecAidGitHubSamples.Vaporware.Repos
{
    public class PeopleRepo : BaseRepo<Person> { }
    public class StoreRepo : BaseRepo<Store> { }

    public class BaseRepo<TClass> where TClass : IVaporEntity
    {
        private readonly Dictionary<string, TClass> _data = new Dictionary<string, TClass>();

        public TClass GetById(string id)
        {
            TClass item;
            _data.TryGetValue(id, out item);

            return item;
        }

        public void Save(TClass oClass)
        {
            if (_data.ContainsKey(oClass.Id))
            {
                _data[oClass.Id] = oClass;
                return;
            }

            _data.Add(oClass.Id, oClass);
        }

        public IQueryable<TClass> GetQueryible()
        {
            return _data.Values.AsQueryable();
        }
    }
}
