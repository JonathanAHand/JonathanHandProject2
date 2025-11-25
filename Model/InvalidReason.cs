namespace JonathanHandProject2.Model
{
    /// <summary>
    /// Enumerates the possible reasons a submitted word may be considered invalid.
    /// These values allow the validation system to clearly communicate why a word
    /// did not qualify as a valid entry.
    ///
    /// Each reason corresponds to a specific rule enforced by WordValidator.
    /// </summary>
    public enum InvalidReason
    {
        /// <summary>
        /// The word is shorter than the minimum allowed length (three letters).
        /// </summary>
        TooShort,

        /// <summary>
        /// The word does not exist in the loaded dictionary data.
        /// </summary>
        NotInDictionary,

        /// <summary>
        /// The player attempted to use letters not present in the current round's
        /// letter pool, or attempted to use a letter more times than available.
        /// </summary>
        LettersNotAvailable,

        /// <summary>
        /// The word has already been accepted as a valid entry earlier in the same round.
        /// </summary>
        AlreadyUsed
    }
}