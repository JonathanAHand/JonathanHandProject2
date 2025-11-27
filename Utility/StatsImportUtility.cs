using System.Text.Json;
using JonathanHandProject2.Model;

namespace JonathanHandProject2.Utility
{
    /// <summary>
    /// Utility class that imports a previously exported stats file
    /// and rebuilds a GameHistory instance plus the last used time limit.
    /// </summary>
    public static class StatsImportUtility
    {
        // DTOs matching the JSON structure produced by StatsExportUtility
        private class AttemptDto
        {
            public string? WordText { get; set; }
            public int TimeEntered { get; set; }
            public int Score { get; set; }
            public string? Reason { get; set; }
        }

        private class RoundDto
        {
            public int RoundNumber { get; set; }
            public char[]? Letters { get; set; }
            public int TimeLimit { get; set; }
            public List<AttemptDto>? Attempts { get; set; }
        }

        private class ExportRootDto
        {
            public List<RoundDto>? Rounds { get; set; }
        }

        /// <summary>
        /// Attempts to import a previously exported stats file.
        /// Returns a rebuilt GameHistory and the last used time limit
        /// or (null, null) if anything goes wrong.
        /// </summary>
        /// <param name="filePath">Path to the exported stats file.</param>
        /// <param name="playerName">
        /// Player name to assign to imported rounds (current player).
        /// </param>
        public static (GameHistory? history, int? restoredTime) Import(
            string filePath,
            string playerName)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return (null, null);
                }

                string json = File.ReadAllText(filePath);

                ExportRootDto? root =
                    JsonSerializer.Deserialize<ExportRootDto>(json);

                if (root?.Rounds == null || root.Rounds.Count == 0)
                {
                    return (null, null);
                }

                GameHistory history = new GameHistory();
                int lastTimeLimit = 60;

                foreach (RoundDto roundDto in root.Rounds)
                {
                    if (roundDto.Letters == null ||
                        roundDto.Letters.Length == 0)
                    {
                        continue;
                    }

                    int timeLimit = roundDto.TimeLimit;
                    if (timeLimit <= 0)
                    {
                        timeLimit = 60;
                    }

                    GameRound round =
                        new GameRound(roundDto.Letters, timeLimit, playerName);

                    lastTimeLimit = timeLimit;

                    if (roundDto.Attempts != null)
                    {
                        foreach (AttemptDto attemptDto in roundDto.Attempts)
                        {
                            if (string.IsNullOrWhiteSpace(attemptDto.WordText))
                            {
                                continue;
                            }

                            string word = attemptDto.WordText;
                            int timeEntered = attemptDto.TimeEntered;

                            if (attemptDto.Score > 0)
                            {
                                ValidWordAttempt valid =
                                    new ValidWordAttempt(
                                        word,
                                        timeEntered,
                                        attemptDto.Score);
                                round.AddAttempt(valid);
                            }
                            else
                            {
                                InvalidReason reason = InvalidReason.TooShort;

                                if (!string.IsNullOrWhiteSpace(attemptDto.Reason) &&
                                    Enum.TryParse(attemptDto.Reason,
                                                  out InvalidReason parsed))
                                {
                                    reason = parsed;
                                }

                                InvalidWordAttempt invalid =
                                    new InvalidWordAttempt(
                                        word,
                                        timeEntered,
                                        reason);
                                round.AddAttempt(invalid);
                            }
                        }
                    }

                    history.AddRound(round);
                }

                if (!history.HasRounds())
                {
                    return (null, null);
                }

                return (history, lastTimeLimit);
            }
            catch
            {
                return (null, null);
            }
        }
    }
}
