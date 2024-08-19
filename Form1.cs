using System;
using System.Windows.Forms;


    public partial class Form1 : Form
    {
        private TextBox searchTextBox;
        private Button searchButton;
        private ListView resultsListView;
        private TextBox detailsTextBox;
        private TableLayoutPanel mainLayout;
        private SearchEngineApp app = new SearchEngineApp();
        List<Document> documents = [];

            
        /// <summary>
        /// This class Creates the UI.
        /// </summary>
        public Form1()
        {
        

            // read documents
            string directory = "Repository/Docs"; // directory for all docs


            try{
                
                // add documents
                foreach (string file in Directory.EnumerateFiles(directory))
                {
                    string? content;

                    content = FileTypeCheck.read(file);
                    // split filepath to get the file name
                    string filename = file.Split(new string[]{"\\", "/"}, StringSplitOptions.None)[2];

                    if(content != null){
                        Document doc = new Document(filename, content);
                        documents.Add(doc);
                    }

                }

            }catch(IOException e){
                Console.WriteLine("Error: " + e);
            }

            // Add documents to the index
            foreach (Document doc in documents)
            {
                app.AddDocument(doc);
            }

            // InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
        {


  
            // Initialize components
            searchTextBox = new TextBox();
            searchButton = new Button();
            resultsListView = new ListView();
            detailsTextBox = new TextBox();
            mainLayout = new TableLayoutPanel();

            // Set up the form
            Text = "Document Search Engine";
            Size = new System.Drawing.Size(800, 600);

            // Set up searchTextBox
            searchTextBox.Dock = DockStyle.Fill;
            searchTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);

            // Set up searchButton
            searchButton.Text = "Search";
            searchButton.Dock = DockStyle.Fill;
            searchButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            searchButton.Click += new EventHandler(searchButton_Click);

            // Set up resultsListView
            resultsListView.View = View.Details;
            resultsListView.FullRowSelect = true;
            resultsListView.Columns.Add("Document Title",-2, HorizontalAlignment.Left);
            resultsListView.Columns.Add("Relevance", -2, HorizontalAlignment.Right);
            resultsListView.Dock = DockStyle.Fill;
            resultsListView.Font = new System.Drawing.Font("Segoe UI", 10F);
            resultsListView.SelectedIndexChanged += new EventHandler(resultsListView_SelectedIndexChanged);

            // Set up detailsTextBox
            detailsTextBox.Multiline = true;
            detailsTextBox.ReadOnly = true;
            detailsTextBox.Dock = DockStyle.Fill;
            detailsTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Set up mainLayout
            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 2;
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Add controls to mainLayout
            mainLayout.Controls.Add(searchTextBox, 0, 0);
            mainLayout.Controls.Add(searchButton, 1, 0);
            mainLayout.Controls.Add(resultsListView, 0, 1);
            mainLayout.Controls.Add(detailsTextBox, 1, 1);

            // Set up row span for resultsListView
            mainLayout.SetColumnSpan(resultsListView, 2);

            // Add mainLayout to the form
            Controls.Add(mainLayout);
            resultsListView.Resize += new EventHandler(AdjustColumnWidths);
        }

        private void AdjustColumnWidths(object sender, EventArgs e)
        {
            int totalWidth = resultsListView.Width;
            resultsListView.Columns[0].Width = (int)(totalWidth * 0.7); // 70% for Document Title
            resultsListView.Columns[1].Width = (int)(totalWidth * 0.3); // 30% for Relevance
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            
            string query = searchTextBox.Text;
            List<string> result = app.Search(query);

            // Example search results (replace with your search logic)
            resultsListView.Items.Clear();
            foreach(var item in result)
            {
                resultsListView.Items.Add(new ListViewItem([$"{item}"]));
            }
            // resultsListView.Items.Add(new ListViewItem(["Document 1", "85%"]));
            // resultsListView.Items.Add(new ListViewItem(new[] { "Document 2", "78%" }));
            // resultsListView.Items.Add(new ListViewItem(new[] { "Document 3", "65%" }));
        }

    private void resultsListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (resultsListView.SelectedItems.Count > 0)
        {
            var selectedItem = resultsListView.SelectedItems[0];
            string documentTitle = selectedItem.Text;

            Document? documentContent = documents.Find(doc => doc.Id == documentTitle); // to get the content og the document by title

            // Create a new instance of the DocumentViewer form
            DocumentViewer viewer = new DocumentViewer(documentTitle, documentContent!.Content);

            // Show the form
            viewer.Show();
        }
}


        
    }
