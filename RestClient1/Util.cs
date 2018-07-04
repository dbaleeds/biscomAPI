using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class Util
    {
        public static int GetBytesToRead(int size, int offset, int chunkSize)
        {            
            int bytesToRead = 0;
            if ((size - offset) < chunkSize)
            {
                Console.Out.WriteLine("*");
                chunkSize = (size - offset);
            }
            bytesToRead = chunkSize;            
            return bytesToRead;
        }

        public static byte[] getBytesFromStream(Stream stream, int offset, int chunkSize) 
        {
            BufferedStream bs = new BufferedStream(stream, chunkSize);
            bs.Seek(offset, SeekOrigin.Begin);
            byte[] bytes = new byte[chunkSize];
            int rc = bs.Read(bytes, 0, bytes.Length);

            return bytes;
        }

        public static void log(string contextName, string message)
        {
            string path = Resources.LOG_FILE_PATH;
            System.IO.File.AppendAllText(path, Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + contextName + Environment.NewLine + message + Environment.NewLine);
        }
    }
}
