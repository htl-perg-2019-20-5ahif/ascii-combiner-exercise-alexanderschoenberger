using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Library
    {
        public bool CheckFiles(List<string[]> files)
        {
            int length = files[0].Length;
            int height = files[0][0].Length;
            foreach (string[] file in files)
            {
                if (file.Length != length)
                {
                    return false;
                }
                foreach (string line in file)
                {
                    if (line.Length != height)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public string[] CombineFiles(List<string[]> files)
        {
            string[] combined = files[0];
            foreach (string[] file in files.Skip(1))
            {
                for (int i = 0; i < combined.Length; i++)
                {
                    char[] newLine = file[i].ToCharArray();
                    char[] oldLine = combined[i].ToCharArray();
                    for (int j = 0; j < newLine.Length; j++)
                    {
                        if (' ' != newLine[j])
                        {
                            oldLine[j] = newLine[j];
                        }
                    }
                    combined[i] = new String(oldLine);
                }
            }
            return combined;
        }
    }
}
