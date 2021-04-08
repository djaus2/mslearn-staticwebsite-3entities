using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public interface IRoundData
    {
        Task<Round> AddRound(Round round);
        Task<bool> DeleteRound(int id);
        Task<IEnumerable<Round>> GetRounds();
        Task<Round> UpdateRound(Round round);
    }

    public class RoundData : IRoundData
    {
        private  List<Round> rounds { get; set; }

        public RoundData()
        {
            rounds = Storage.localStorage.Get<List<Round>>("rounds");
        }

        private int GetRandomInt()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }

        public Task<Round> AddRound(Round round)
        {
            round.Id = GetRandomInt();
            rounds.Add(round);
            return Task.FromResult(round);
        }

        public Task<Round> UpdateRound(Round round)
        {
            var index = rounds.FindIndex(p => p.Id == round.Id);
            rounds[index] = round;
            return Task.FromResult(round);
        }

        public Task<bool> DeleteRound(int id)
        {
            var index = rounds.FindIndex(p => p.Id == id);
            rounds.RemoveAt(index);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Round>> GetRounds()
        {
            return Task.FromResult(rounds.AsEnumerable());
        }
    }
}
