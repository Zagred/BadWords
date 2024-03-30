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
        private static Dictionary<string, bool> flagedWords = new Dictionary<string, bool>();
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
        public static void test(string path, List<string> comments)
        {
            List<string> folders = Init_Dict(path);
            foreach (string folder in folders)
            {
                foreach (string filepath in Directory.GetFiles(folder, "*.txt"))// всчики файлове в папката
                {
                    string[] fileContent = File.ReadAllLines(filepath);
                    for (int i = 0; i < fileContent.Length; i++)
                    {
                        try
                        {
                            flagedWords.Add(fileContent[i], true);
                        }
                        catch
                        {
                            // Console.WriteLine("this word already exist:", fileContent[i]);
                        }
                    }
                }
            }

            foreach(string comment in comments)
            {
                string[] wordsInComment = comment.Split(new char[] { ',', ' '});
                foreach (string word in wordsInComment)
                {
                    try
                    {
                        flagedWords.Add(word, true);   
                    }
                    catch
                    {
                        Console.WriteLine(comment);
                        break;
                    }
                }
            }
        }
    }
}
