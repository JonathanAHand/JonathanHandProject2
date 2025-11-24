using System.Collections.Generic;

namespace JonathanHandProject2.Model
{
    public class GameRound
    {
        public char[] Letters { get; }
        public int TimeLimit { get; }
        public List<WordAttempt> Attempts { get; }

        // NEW: Required by prompts
        public string PlayerName { get; }
        public int FinalScore { get; private set; }
        public int TimeUsed { get; private set; }

        public GameRound(char[] letters, int timeLimit, string playerName)
        {
            Letters = letters;
            TimeLimit = timeLimit;
            PlayerName = playerName;

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

        // NEW: Called when time runs out or New Round is triggered
        public void FinalizeRound(int finalScore, int timeUsed)
        {
            FinalScore = finalScore;
            TimeUsed = timeUsed;
        }
    }
}