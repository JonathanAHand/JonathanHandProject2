using System.Text.Json;
using JonathanHandProject2.Model;

namespace JonathanHandProject2.Utility
{
    public static class StatsExportUtility
    {
        /// <summary>
        /// Exports full game history including rounds, letters, time limits,
        /// and all attempts (valid + invalid) with clean formatting.
        /// </summary>
        public static void Export(GameHistory history, string filePath)
        {
            var exportRounds = new List<object>();

            for (int i = 0; i < history.Rounds.Count; i++)
            {
                GameRound round = history.Rounds[i];

                List<object> attemptsList = new List<object>();

                foreach (var attempt in round.Attempts)
                {
                    if (attempt is ValidWordAttempt v)
                    {
                        attemptsList.Add(new
                        {
                            WordText = v.WordText,
                            TimeEntered = v.TimeEntered,
                            Score = v.Score
                        });
                    }
                    else if (attempt is InvalidWordAttempt inv)
                    {
                        attemptsList.Add(new
                        {
                            WordText = inv.WordText,
                            TimeEntered = inv.TimeEntered,
                            Score = 0,
                            Reason = inv.Reason.ToString()
                        });
                    }
                }

                var roundBlock = new
                {
                    RoundNumber = i + 1,
                    Letters = round.Letters,
                    TimeLimit = round.TimeLimit,
                    Attempts = attemptsList
                };

                exportRounds.Add(roundBlock);
            }

            var exportObject = new
            {
                Rounds = exportRounds
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(exportObject, options);

            File.WriteAllText(filePath, json);
        }
    }
}
