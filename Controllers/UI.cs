using System;

/// <summary>
/// UI FOR THE APP GOES HERE
/// </summary>
public class SearchEngineApp
{
    private InvertedIndex index;
    private QueryParser queryParser;
    private MatchingFunction matchingFunction;
    private StopWords stopWords;

    public SearchEngineApp()
    {
        index = new InvertedIndex();
        queryParser = new QueryParser();
        stopWords = new StopWords();
        matchingFunction = new MatchingFunction(index);
    }

    /// <summary>
    ///  Add document to index
    /// </summary>
    /// <param name="doc">The document to index</param>
    public void AddDocument(Document doc)
    {
        index.AddDocument(doc, stopWords);
    }

    /// <summary>
    ///     Method to perform search
    /// </summary>
    /// <param name="query"></param>
    public void Search(string query)
    {
        var queryKeywords = queryParser.ParseQuery(query, stopWords);
        var matchingDocuments = matchingFunction.MatchQuery(queryKeywords);

        // TODO: Redirects to new screen to display the below result

        Console.WriteLine($"Search results for '{query}':");
        foreach (var docId in matchingDocuments)
        {
            Console.WriteLine($"Document ID: {docId}");
        }
    }
}
