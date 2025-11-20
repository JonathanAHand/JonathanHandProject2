using System.Collections.Generic;

namespace JonathanHandProject2.Model
{
    public class GameRound
    {
        public char[] Letters { get; }
        public int TimeLimit { get; }
        public List<WordAttempt> Attempts { get; }

        public GameRound(char[] letters, int timeLimit)
        {
            Letters = letters;
            TimeLimit = timeLimit;
            Attempts = new List<WordAttempt>();
        }

        public void AddAttempt(WordAttempt attempt)
        {
            Attempts.Add(attempt);
        }

        public int GetRoundScore()
        {
            int total = 0;

            foreach (var attempt in Attempts)
            {
                if (attempt is ValidWordAttempt v)
                {
                    total += v.Score;
                }
            }

            return total;
        }
    }
}