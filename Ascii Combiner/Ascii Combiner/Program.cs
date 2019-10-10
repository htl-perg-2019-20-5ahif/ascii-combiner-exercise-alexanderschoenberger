using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascii_Combiner
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length >= 3 && args[0].Equals("run"))
            {
                var library = new Library.Library();
                List<string[]> files = ReadFile(args.Skip(1).ToArray());
                if (files == null)
                    return 1;
                foreach (string[] test in files)
                {
                    PrintArray(test);
                }
                if (library.CheckFiles(files))
                {
                    string[] combined = library.CombineFiles(files);
                    PrintArray(combined);
                }
                else
                {
                    Console.WriteLine("ERROR: The file have no equals sizes");
                }
            }
            else
            {
                Console.WriteLine("ERROR: To less arguments");
            }
            return 0;
        }

        private static void PrintArray(string[] combined)
        {
            Console.WriteLine();
            foreach (string line in combined)
            {
                Console.WriteLine(line);
            }
        }

        private static List<string[]> ReadFile(string[] fileNames)
        {
            List<string[]> list = new List<string[]>();
            foreach (string file in fileNames)
            {
                try
                {
                    list.Add(System.IO.File.ReadAllLines(file, Encoding.ASCII));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
            return list;
        }
    }
}
