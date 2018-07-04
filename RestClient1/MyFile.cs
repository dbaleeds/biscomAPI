using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    /**
     * This class helps to handle file upload      
     */
    class MyFile
    {
        public string fileName {get; set;}
        public string filePath { get; set; }

        // Constructs a file object with the filename and the path of the file
        public MyFile(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;
        }
    }
}
