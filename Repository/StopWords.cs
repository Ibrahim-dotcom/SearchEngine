/// <summary>
/// This class will hold the stop words and provide a method to check if a word is a stop word.
/// </summary>
public class StopWords
{
    private HashSet<string> stopWords;

    /// <summary>
    /// Construct stop words
    /// </summary>
    public StopWords()
    {
        stopWords = new HashSet<string>
        {
            "a", "an", "the", "and", "or", "but", "to", "from", "in", "on", "at", "by", "with", "about", "against",
            "between", "into", "through", "during", "before", "after", "above", "below", "of", "for", "over", "under",
            "again", "further", "then", "once", "here", "there", "when", "where", "why", "how", "all", "any", "both",
            "each", "few", "more", "most", "other", "some", "such", "no", "nor", "not", "only", "own", "same", "so",
            "than", "too", "very", "s", "t", "can", "will", "just", "don", "should", "now"
        };
    }

    /// <summary>
    /// This method checks if a word is a stop word
    /// </summary>
    /// <param name="word">The word to check if it's a stop word or not</param>
    /// <returns>True if the word is a stop word otherwise False</returns>
    public bool IsStopWord(string word)
    {
        return stopWords.Contains(word.ToLower());
    }
}
