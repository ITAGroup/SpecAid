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
        private readonly Dictionary<int, TClass> _data = new Dictionary<int, TClass>();

        public TClass GetById(int id)
        {
            TClass item;
            _data.TryGetValue(id, out item);

            return item;
        }
        
        /// <param name="idAsText">Must be Int Convertable</param>
        public TClass GetById(string idAsText)
        {
            var id = Convert.ToInt32(idAsText);

            TClass item;
            _data.TryGetValue(id, out item);

            return item;
        }

        public List<TClass> GetAll()
        {
            return _data.Values.AsQueryable().ToList();
        }

        public void Save(TClass oClass)
        {
            if (oClass.Id == 0)
            {
                oClass.Id = NewId();
            }

            if (_data.ContainsKey(oClass.Id))
            {
                _data[oClass.Id] = oClass;
                return;
            }

            _data.Add(oClass.Id, oClass);
        }

        private int NewId()
        {
            if (!_data.Any())
                return 1;

            var lastId = GetQueryible().Max(x => x.Id);
            return lastId + 1;
        }

        public IQueryable<TClass> GetQueryible()
        {
            return _data.Values.AsQueryable();
        }
    }
}
