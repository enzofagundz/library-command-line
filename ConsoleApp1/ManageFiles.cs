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
            Menu.Show(false);
        }

        public static void Read (string filename)
        {
            Console.WriteLine($"Lendo arquivo {filename}.txt");
            string filenameWithExtension = filename + ".txt";
            string fileContent = File.ReadAllText(filenameWithExtension);
            Console.WriteLine(fileContent);
            Menu.Show();
        }

        public static void Update (string filename)
        {
            Console.WriteLine("Atualizando arquivo " + filename);
        }

        public static void Delete (string filename)
        {
            Console.WriteLine($"Deletando arquivo {filename}.txt");
            File.Delete($"{filename}.txt");
            Console.WriteLine($"Arquivo {filename}.txt deletado com sucesso!");
            Menu.Show();
        }
    }
}