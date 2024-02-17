using System;
using System.IO;

namespace Service
{
    class ManageFiles
    {
        public static void Create(string filename, string content)
        {
            Console.WriteLine($"Criando arquivo {filename}");

            string filenameWithExtension = filename + ".txt";

            if (File.Exists(filenameWithExtension))
            {
                File.AppendAllText(filenameWithExtension, content);
            }
            else
            {
                File.WriteAllText(filenameWithExtension, content);
            }

            Console.WriteLine($"Arquivo {filenameWithExtension} criado com sucesso!");
        }

        public static string[] Read(string filename)
        {
            if (!File.Exists($"{filename}.txt"))
            {
                Console.WriteLine($"Arquivo {filename}.txt não encontrado");
                return [];
            }

            string fileContent = File.ReadAllText($"{filename}.txt");
            string[] lines = fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }

        public static string[] Update(string filename, string field, int position)
        {
            Console.WriteLine("Atualizando arquivo " + filename);
            string[] registers = Read(filename);
            string[] registerReturn = [];
            foreach (string register in registers)
            {
                string[] registerData = register.Split(" - ");

                if (registerData[position] == field)
                {
                    registerReturn = registerData;
                }
            }

            return registerReturn;
        }

        public static void Delete(string filename, string field, int position)
        {
            // receive the filename and the id of the register
            // read the file, find the register with the id, and remove it from the file
            // save the file

            Console.WriteLine("Deletando arquivo " + filename);

            if (!File.Exists($"{filename}.txt"))
            {
                Console.WriteLine($"Arquivo {filename}.txt não encontrado");
                return;
            }

            string fileContent = File.ReadAllText($"{filename}.txt");
            string[] lines = fileContent.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string newFileContent = "";
            foreach (string line in lines)
            {
                string[] lineData = line.Split(" - ");
                if (lineData[position] != field)
                {
                    newFileContent += line + ";";
                }
            }


        }
    }
}