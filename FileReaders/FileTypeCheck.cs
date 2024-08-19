/// <summary>
///     This class checks the type of the file and use the appropriate method to read it
/// </summary>
public class FileTypeCheck {

    /// <summary>
    ///     Checks the file type and use the appropriate reader
    /// </summary>
    /// <param name="path">Path of the file to read</param>
    /// <returns>Returns the content of the file</returns>
    public static string? read(string path){

        Console.WriteLine($"path: {path}");

        if(path.EndsWith(".pdf"))
            return SearchPdfReader.readPdf(path);
        
        else if(path.EndsWith(".txt"))
            return SearchTxtReader.readTxt(path);
        
        else if(path.EndsWith(".xml"))
            return SearchXmlReader.readXml(path);

        else if(path.EndsWith(".html"))
            return SearchHtmlReader.readHTML(path);
        
        else if(path.EndsWith(".xls") || path.EndsWith(".xlsx"))
            return SearchExcelReader.readExcel(path);
        
        else if(path.EndsWith(".docx"))
            return SearchDocReader.readDocx(path);

        else if(path.EndsWith(".pptx"))
            return SearchPowerPointReader.readPowerPoint(path);
            

        return null;
    }
}