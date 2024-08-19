using System;
using System.IO;

/// <summary>
///  This class reads Txt file type
/// </summary>
public class SearchTxtReader{
    
    /// <summary>
    ///     Reads Text file
    /// </summary>
    /// <param name="path">Text file path</param>
    /// <returns>Returns text file content</returns>
    public static string? readTxt(string path){
        string? content = File.ReadAllText(path);

        return content;
    }
}