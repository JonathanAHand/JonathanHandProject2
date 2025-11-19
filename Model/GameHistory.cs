using System.Collections.Generic;

namespace JonathanHandProject2.Model
{
    internal class GameHistory
    {
        public List<GameRound> Rounds { get; }

        public GameHistory()
        {
            Rounds = new List<GameRound>();
        }

        public void AddRound(GameRound round)
        {
            Rounds.Add(round);
        }

        public bool HasRounds()
        {
            return Rounds.Count > 0;
        }
    }
}