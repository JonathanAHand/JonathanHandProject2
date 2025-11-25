using System.Text.Json;
using JonathanHandProject2.Model;

namespace JonathanHandProject2.Utility;

/// <summary>
/// Provides functionality for exporting the complete game history
/// to a JSON file. This includes every round played, the letters
/// used, the time limit, and all word attempts (valid and invalid).
///
/// The exported format is structured for readability and easy
/// external review, using anonymous objects and indented JSON.
/// </summary>
public static class StatsExportUtility
{
    /// <summary>
    /// Serializes the entire GameHistory object—including all rounds,
    /// letters, time limits, valid attempts, invalid attempts, and
    /// corresponding details—into a JSON file.
    ///
    /// The JSON output contains:
    ///  - A list of rounds
    ///  - Round number
    ///  - Letters used that round
    ///  - Time limit for the round
    ///  - A list of attempts (valid & invalid)
    ///
    /// ValidWordAttempt includes:
    ///     WordText, TimeEntered, Score
    ///
    /// InvalidWordAttempt includes:
    ///     WordText, TimeEntered, Score=0, Reason
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