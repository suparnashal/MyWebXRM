using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Framework.Helpers
{
   public class GlobalHelpers
    {

        public bool DownloadFilePresent(string filename)
        {
            string downloadpath = @"C:\Users\sshaligram\Downloads" ;                       

            IEnumerable<string> filenames = Directory.EnumerateFiles(downloadpath, filename);

            string path = $"{downloadpath}\\{filenames}";
            DateTime t = filenames.Max(f => Directory.GetCreationTime(f));
            
            IEnumerable<string> filenames2 = filenames.OrderByDescending(f => Directory.GetCreationTime(f));
            string _file = filenames2.First(); 
            return true;
           
        }

        public void DeleteFilesFromDirectory(string filename)
        {
            string downloadpath = @"C:\Users\sshaligram\Downloads";

            Directory.EnumerateFiles(downloadpath, filename)
                     .ToList().ForEach(f => File.Delete(f));
        }
    }
}
