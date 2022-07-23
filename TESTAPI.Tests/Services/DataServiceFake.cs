using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPI.Core;
using TESTAPI.Services;

namespace TESTAPI.Tests.Services
{
    public class DataServiceFake : IDataService
    {
        private Dictionary<string, IEnumerable<Beer>> dictBeers;
        
        public DataServiceFake()
        {
            dictBeers = new Dictionary<string, IEnumerable<Beer>>();

            dictBeers.Add("one", new List<Beer>()
            {
                new Beer()
                {
                    Name = "One",
                }
            });
        }

        public DataServiceFake(Dictionary<string, IEnumerable<Beer>> dict)
        {
            dictBeers = dict;
        }

        public async Task<IEnumerable<Beer>> Load(string url)
        {
            if (dictBeers.ContainsKey(url))
            {
                return await Task.FromResult(dictBeers[url]);
            };
            return await Task.FromResult(new List<Beer>());
        }
    }
}
