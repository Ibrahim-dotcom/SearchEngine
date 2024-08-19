using System;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


/// <summary>
///  This class reads word document file type (.Doc and .Docx)
/// </summary>
public class SearchDocReader{

    /// <summary>
    ///     Reads .doc and .docx files
    /// </summary>
    /// <param name="path"> file path</param>
    /// <returns>Returns File content</returns>
    public static string? readDocx(string path){
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, false))
        {
            Body body = wordDoc.MainDocumentPart.Document.Body;
            return body.InnerText;
        }
    }


}