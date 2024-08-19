using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;

/// <summary>
///  This class reads PowerPoint file type
/// </summary>
public class SearchPowerPointReader{
    
    /// <summary>
    ///     Reads PowerPoint files (.ppt and .pptx)
    /// </summary>
    /// <param name="path">PowerPoint file path</param>
    /// <returns>Returns PowerPoint file content</returns>
    public static string? readPowerPoint(string path){

        StringBuilder content = new StringBuilder();

        // Open the presentation
        using (PresentationDocument presentationDocument = PresentationDocument.Open(path, false))
        {
            // Get the presentation part
            PresentationPart presentationPart = presentationDocument.PresentationPart;

            // Loop through the slides
            foreach (SlidePart slidePart in presentationPart.SlideParts)
            {
                // Get the slide content
                foreach (var text in slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>())
                {
                    content.AppendLine(text.Text);
                }
            }
        }

        return content.ToString();
    }
}