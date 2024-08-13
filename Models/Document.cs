/// <summary>
/// This class will represent a document model for holding documents
/// </summary>
public class Document
{
    public int Id { get; set; }
    public string Content { get; set; }

    /// <summary>
    /// This method constructs document
    /// </summary>
    /// <param name="id">The id of the document</param>
    /// <param name="content">The content of the document</param>
    public Document(int id, string content)
    {
        Id = id;
        Content = content;
    }
}
