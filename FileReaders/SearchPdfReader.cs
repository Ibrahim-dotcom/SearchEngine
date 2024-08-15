using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

/// <summary>
///  This class reads pdf file type
/// </summary>
public class SearchPdfReader{
    
    /// <summary>
    ///     Reads pdf
    /// </summary>
    /// <param name="path">Pdf path</param>
    /// <returns>Returns pdf content</returns>
    public static string? readPdf(string path){

        string? content = null;
        
        using (var pdf = PdfDocument.Open(path))
        {
            foreach (var page in pdf.GetPages())
            {
                // Either extract based on order in the underlying document with newlines and spaces.
                var text = ContentOrderTextExtractor.GetText(page);

                content = content! + "\n\n" + text;
            }

        }

        return content;
    }
}