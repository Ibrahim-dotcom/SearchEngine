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

        if(path.EndsWith(".pdf")){
            return SearchPdfReader.readPdf(path);
        }

        return null;
    }
}