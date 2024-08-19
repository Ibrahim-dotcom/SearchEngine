using System.Windows.Forms;
/// <summary>
/// This shows the content of a file in a new window.
/// </summary>
public class DocumentViewer : Form
{
    private TextBox contentTextBox;

    public DocumentViewer(string title, string content)
    {
        // Set the title of the form to the document title
        Text = title;

        // Set up the TextBox to display the content
        contentTextBox = new TextBox
        {
            Multiline = true,
            Dock = DockStyle.Fill,
            Font = new System.Drawing.Font("Segoe UI", 10F),
            Text = content,
            ScrollBars = ScrollBars.Both,
            ReadOnly = true,
        };

        // Add the TextBox to the form
        Controls.Add(contentTextBox);

        // Set the size of the form
        Size = new System.Drawing.Size(600, 400);
    }
}
