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

            // Sample documents
            var doc1 = new Document(1, "C# is a modern programming language developed by Microsoft.");
            var doc2 = new Document(2, "Java is a popular language used for building web applications.");
            var doc3 = new Document(3, "Python is an interpreted, high-level language used for data analysis.");

            // Add documents to the index
            app.AddDocument(doc1);
            app.AddDocument(doc2);
            app.AddDocument(doc3);

            // Perform search queries
            app.Search("modern");
            app.Search("web");
        }
}