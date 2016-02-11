using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string InputFileName = args[0];
            string Outputfolder = args[1];
            int OutputCount = int.Parse(args[2]);
            StreamReader reader = new StreamReader(InputFileName);


            //Count number of lines
            Console.WriteLine("Compute Lines..");
            int count = 0;
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                count++;
            }

            Console.WriteLine("Total lines: " + count);
            int chunkSize = count / OutputCount;
            StreamReader reader2 = new StreamReader(InputFileName);

            for (int i = 0; i < OutputCount && !reader2.EndOfStream ; ++i)
            {
                Console.WriteLine("Write {0} document...", i);
                StreamWriter writer = new StreamWriter(Outputfolder + "\\out" + i + ".tsv");
                for(int j = chunkSize * i; j < chunkSize*(i + 1) && !reader2.EndOfStream; j++)
                {
                    writer.WriteLine(reader2.ReadLine());
                }
                writer.Flush();
            }
            Console.Read();
           
        }
    }
}
