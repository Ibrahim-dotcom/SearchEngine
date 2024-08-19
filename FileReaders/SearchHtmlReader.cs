using HtmlAgilityPack;

/// <summary>
///  This class reads HTML file type
/// </summary>
public class SearchHtmlReader{
    
    /// <summary>
    ///     Reads HTML file
    /// </summary>
    /// <param name="path">HTML file path</param>
    /// <returns>Returns HTML file content</returns>\
    public static string? readHTML(string path){
       HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.Load(path);
        return doc.DocumentNode.InnerText;
    }
}