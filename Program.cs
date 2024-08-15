using System;
using System.IO; 
using System.Text;
 
 /// <summary>
 /// Entry class to project
 /// </summary>
 public class Program {

        /// <summary>
        /// Entry method for project
        /// </summary>
        public static void Main(string[] args){

            // TODO: The below is for test pending when the UI will e developed.

            var app = new SearchEngineApp();
            List<Document> documents = [];

            // read documents
            string directory = "Repository/Docs"; // directory for all docs

            int docId = 1;

            try{
                
                // add documents
                foreach (string file in Directory.EnumerateFiles(directory))
                {
                    string? content;

                    content = FileTypeCheck.read(file);

                    if(content != null){
                        Document doc = new Document(docId, content);
                        documents.Add(doc);
                    }

                    docId += 1;
                }

            }catch(IOException e){
                Console.WriteLine("Error: " + e);
            }

            // Add documents to the index
            foreach (Document doc in documents)
            {
                app.AddDocument(doc);
            }

            // Perform search queries
            app.Search("representation");
        }
}