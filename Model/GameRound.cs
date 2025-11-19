using System.Collections.Generic;

namespace JonathanHandProject2.Model
{
    internal class GameRound
    {
        public char[] Letters { get; }
        public int DurationSeconds { get; }
        public List<WordAttempt> Attempts { get; }

        public GameRound(char[] letters, int durationSeconds)
        {
            Letters = letters;
            DurationSeconds = durationSeconds;
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
                if (attempt is ValidWordAttempt valid)
                {
                    total += valid.Score;
                }
            }

            return total;
        }
    }
}