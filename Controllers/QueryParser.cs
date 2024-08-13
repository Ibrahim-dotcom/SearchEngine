/// <summary>
/// This class processes the input query to filter out stop words and prepare it for matching.
/// </summary>
public class QueryParser
{

    /// <summary>
    ///     This method takes query parameter and stopwords and returns List of words without the stop words
    /// </summary>
    /// <param name="query">The query parameter/word to search</param>
    /// <param name="stopWords">The stop words to be removed from the query</param>
    /// <returns>Returns List of keywords</returns>
    public List<string> ParseQuery(string query, StopWords stopWords)
    {
        var words = query.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var keywords = new List<string>();

        foreach (var word in words)
        {
            string keyword = word.ToLower();

            if (!stopWords.IsStopWord(keyword))
            {
                keywords.Add(keyword);
            }
        }

        return keywords;
    }
}
