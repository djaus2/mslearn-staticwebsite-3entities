using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hanssens.Net;

namespace Api
{
    public interface IHelperData
    {
        Task<Helper> AddHelper(Helper helper);
        Task<bool> DeleteHelper(int id);
        Task<IEnumerable<Helper>> GetHelpers();
        Task<Helper> UpdateHelper(Helper helper);
    }

    public class HelperData : IHelperData
    {
        private List<Helper> helpers { get; set; }


        public HelperData()
        { 
            helpers = Storage.localStorage.Get<List<Helper>>("helpers");
        }

        private int GetRandomInt()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }

        public Task<Helper> AddHelper(Helper helper)
        {
            helper.Id = GetRandomInt();
            helpers.Add(helper);
            return Task.FromResult(helper);
        }

        public Task<Helper> UpdateHelper(Helper helper)
        {
            var index = helpers.FindIndex(p => p.Id == helper.Id);
            helpers[index] = helper;
            return Task.FromResult(helper);
        }

        public Task<bool> DeleteHelper(int id)
        {
            var index = helpers.FindIndex(p => p.Id == id);
            helpers.RemoveAt(index);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Helper>> GetHelpers()
        {
            return Task.FromResult(helpers.AsEnumerable());
        }
    }
}
