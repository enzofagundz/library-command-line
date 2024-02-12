using System;
using System.IO;

namespace ConsoleApp1
{
    class ManageFiles
    {
        public static void Create (string filename, string content)
        {
            Console.WriteLine($"Criando arquivo {filename}");

            string filenameWithExtension = filename + ".txt";

            if (File.Exists(filenameWithExtension))
            {
                File.AppendAllText(filenameWithExtension, content);    
            } else
            {
                File.WriteAllText(filenameWithExtension, content);
            }
        
            Console.WriteLine($"Arquivo {filenameWithExtension} criado com sucesso!");
        }

        public static string[] Read (string filename)
        {
            string fileContent = File.ReadAllText($"{filename}.txt");
            string[] lines = fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }
        
        public static void Update (string filename)
        {
            Console.WriteLine("Atualizando arquivo " + filename);
        }

        public static void Delete (string filename)
        {
            File.Delete($"{filename}.txt");
            Console.WriteLine($"Arquivo {filename}.txt deletado com sucesso!");
        }
    }
}