using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Hanssens.Net;

namespace Api
{
    public interface IStorage
    {
        bool HasInitedActivitys();
        bool HasInitedHelpers();
        bool HasInitedRounds();
        void Init();
        List<Activity> GetActivitys();
        List<Helper> GetHelpers();
        List<Round> GetRounds();
    }
    public class Storage: IStorage
    {
        ILocalStorage localStorage { get; set; }

        private bool _HasInitedActivitys = false;

        public bool HasInitedActivitys()
        {
            bool res = _HasInitedActivitys;
            _HasInitedActivitys = false;
            return res;
        }

        private bool _HasInitedHelpers = false;

        public bool HasInitedHelpers()
        {
            bool res = _HasInitedHelpers;
            _HasInitedHelpers = false;
            return res;
        }

        private bool _HasInitedRounds = false;

        public bool HasInitedRounds()
        {
            bool res = _HasInitedRounds;
            _HasInitedRounds = false;
            return res;
        }


        public Storage()
        {
            localStorage = new LocalStorage();
            Init();
        }
        public void Init()
        {
            localStorage.Clear();
            var activitys = new List<Activity>
            {
                new Activity
                {
                    Id = 10,
                    Name = "ShotPut",
                    Description = "",
                    Quantity = 1,
                    Helper = new Helper {Id = 1, Name ="Fred Nurk" },
                    Round = new Round {Id=1, No=1}
                },
                new Activity
                {
                    Id = 20,
                    Name = "Long Jump",
                    Description = "",
                    Quantity = 1,
                    Helper = null,
                    Round = new Round {Id=2, No=2}
                },
                new Activity
                {
                    Id = 30,
                    Name = "Starter",
                    Description = "",
                    Quantity = 1,
                    Helper = new Helper {Id = 3, Name ="Harry Lime" },
                    Round = new Round {Id=3, No=3}
                }
            };
            localStorage.Clear();
            localStorage.Store<List<Activity>>("activitys", activitys);
            var helpers = (from a in activitys where a.Helper != null select a.Helper).ToList();
            var rounds = (from a in activitys where a.Round != null select a.Round).ToList();
            localStorage.Store<List<Helper>>("helpers", helpers);
            localStorage.Store<List<Round>>("rounds", rounds);
            _HasInitedActivitys = true;
            _HasInitedHelpers = true;
            _HasInitedRounds = true;
        }


        public List<Activity> GetActivitys()
        {
            return localStorage.Get<List<Activity>>("activitys");
        }

        public List<Helper> GetHelpers()
        {
            return localStorage.Get<List<Helper>>("helpers");
        }

        public List<Round> GetRounds()
        {
            return localStorage.Get<List<Round>>("rounds");
        }
    }
}
