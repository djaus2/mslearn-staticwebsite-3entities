using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace Api
{
    public interface IActivityData
    {
        Task<Activity> AddActivity(Activity activity);
        Task<bool> DeleteActivity(int id);
        Task<IEnumerable<Activity>> GetActivitys();
        Task<Activity> UpdateActivity(Activity activity);
    }

    public class ActivityData : IActivityData
    {
        private List<Activity> activitys = null;
        private IStorage storage;
        public ActivityData(IStorage _storage)
        {
            storage = _storage;
            activitys = storage.GetActivitys();
        }

        private int GetRandomInt()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }

        public Task<Activity> AddActivity(Activity activity)
        {
            activity.Id = GetRandomInt();
            activitys.Add(activity);
            return Task.FromResult(activity);
        }

        public Task<Activity> UpdateActivity(Activity activity)
        {
            var index = activitys.FindIndex(p => p.Id == activity.Id);
            activitys[index] = activity;
            return Task.FromResult(activity);
        }

        public Task<bool> DeleteActivity(int id)
        {
            var index = activitys.FindIndex(p => p.Id == id);
            activitys.RemoveAt(index);
            return Task.FromResult(true);
        }

         public Task<IEnumerable<Activity>> GetActivitys()
        {
            return Task.FromResult(activitys.AsEnumerable());
        }
    }
}
