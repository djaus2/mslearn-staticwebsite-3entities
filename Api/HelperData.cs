using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        internal List<Helper> helpers { get; set; } 
            = new List<Helper>
        {
                new Helper {Id = 1, Name ="Fred Nurk" },
                new Helper {Id = 3, Name ="Harry Lime" },
        };

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

        internal static List<Helper> _helpers;
        private bool hasInited = false;
        private void InitData()
        {
            helpers = _helpers;
        }
    public Task<IEnumerable<Helper>> GetHelpers()
    {
        if (!hasInited)
        {
            InitData();
        }
        return Task.FromResult(helpers.AsEnumerable());
        }
    }
}
