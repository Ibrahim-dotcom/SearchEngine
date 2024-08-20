/// <summary>
///     This class uses the index to find documents that match the parsed query.
/// </summary>
public class MatchingFunction
{
    private InvertedIndex index;

    /// <summary>
    ///     Constructs MatchingFunction
    /// </summary>
    /// <param name="index">The index object</param>
    public MatchingFunction(InvertedIndex index)
    {
        this.index = index;
    }

    /// <summary>
    ///     This method counts the frequency of each keyword with respect to documentId
    /// </summary>
    /// <param name="queryKeywords">The keywords to count its frequency</param>
    /// <returns>Returns ordered List of documentIds</returns>
    public Dictionary<string, float> MatchQuery(List<string> queryKeywords)
    {
        var documentIds = new Dictionary<string, float>();

        foreach (var keyword in queryKeywords)
        {
            var docs = index.Search(keyword); // List of documentId that contains the keyword

            foreach (var docId in docs)
            {
                if (!documentIds.ContainsKey(docId))
                {
                    documentIds[docId] = 0;
                }
                documentIds[docId]++;
            }
        }

        foreach(var docId in documentIds)
        {
            documentIds[docId.Key] = (docId.Value / queryKeywords.Count) * 100;
        }

        // Sort documents by frequency of matched keywords : From high to low using LINQ to Object
        //return documentIds.OrderByDescending(pair => pair.Value).Select(pair => pair.Key).ToList();
        return documentIds.OrderByDescending(pair => pair.Value).ToDictionary<string, float>();

    }
}
