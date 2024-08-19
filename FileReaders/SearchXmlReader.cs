using System;
using System.Xml;

/// <summary>
///  This class reads xml file type
/// </summary>
public class SearchXmlReader{
    
    /// <summary>
    ///     Reads xml file
    /// </summary>
    /// <param name="path">xml file path</param>
    /// <returns>Returns xml file content</returns>\
    public static string? readXml(string path){
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        return doc.InnerXml;
    }
}