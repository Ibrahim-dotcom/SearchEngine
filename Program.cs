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
                   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
}