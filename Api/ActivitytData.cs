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
        private readonly List<Activity> activitys = new List<Activity>
        {
            new Activity
            {
                Id = 10,
                Name = "Strawberries",
                Description = "16oz package of fresh organic strawberries",
                Quantity = 1,
                Helper = new Helper {Id = 1, Name ="Fred Nurk" },
                Round = new Round {Id=1, No=1}
            },
            new Activity
            {
                Id = 20,
                Name = "Sliced bread",
                Description = "Load of fresh sliced wheat bread",
                Quantity = 1,
                Helper = null,
                Round = new Round {Id=2, No=2}
            },
            new Activity
            {
                Id = 30,
                Name = "Apples",
                Description = "Bag of 7 fresh McIntosh apples",
                Quantity = 1,
                Helper = new Helper {Id = 3, Name ="Harry Lime" },
                Round = new Round {Id=3, No=3}
            }
        };

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
