using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadWords
{
    public class CheckComments
    {
        private static HashSet<string> flagedWords = new HashSet<string>();
        private static List<string> Init_Dict(string folder)
        {
            List<string> folderContent = new List<string>();
            foreach (var directory in Directory.GetDirectories(folder))
            {
                folderContent.Add(directory);
                folderContent.AddRange(Init_Dict(directory));

            }
            return folderContent;
        }
        public void test(string path, List<string> comments)
        {
            List<string> folders = Init_Dict(path);
            foreach (string folder in folders)
            {
                foreach (string filepath in Directory.GetFiles(folder, "*.txt"))
                {
                    string[] fileContent = File.ReadAllLines(filepath);
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        if (!flagedWords.Contains(fileContent[i]))
                        {
                            flagedWords.Add(fileContent[i]);
                        }              
                       
                    }
                }
            }
            foreach(string comment in comments)
            {
                string[] wordsInComment = comment.Split(new char[] { ',', ' '});
                foreach (string word in wordsInComment)
                {
                    if (flagedWords.Contains(word))
                    {
                        Console.WriteLine(comment);
                        break;
                    }
                }
            }
        }
    }
}
