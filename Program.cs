using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Document Management System");
            Console.WriteLine("--------------------------");

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Create a file");
            Console.WriteLine("2. Read a file");
            Console.WriteLine("3. Append to a file");
            Console.WriteLine("4. Delete a file");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the file name: ");
                    string createFileName = Console.ReadLine();

                    Console.Write("Enter the content: ");
                    string content = Console.ReadLine();

                    CreateFile(createFileName, content);
                    Console.WriteLine("File created successfully!");
                    break;
                case 2:
                    Console.Write("Enter the file name to read: ");
                    string readFileName = Console.ReadLine();

                    string fileContent = ReadFile(readFileName);
                    Console.WriteLine("File content:");
                    Console.WriteLine(fileContent);
                    break;
                case 3:
                    Console.Write("Enter the file name to append: ");
                    string appendFileName = Console.ReadLine();

                    Console.Write("Enter the content to append: ");
                    string appendContent = Console.ReadLine();

                    AppendToFile(appendFileName, appendContent);
                    Console.WriteLine("Content appended successfully!");
                    break;
                case 4:
                    Console.Write("Enter the file name to delete: ");
                    string deleteFileName = Console.ReadLine();

                    DeleteFile(deleteFileName);
                    Console.WriteLine("File deleted successfully!");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
            Console.ReadKey();
        }

        static void CreateFile(string fileName, string content)
        {
            string filePath = fileName + ".txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
            Console.ReadKey();
        }


        static string ReadFile(string fileName)
        {
            string filePath = fileName + ".txt";
            string fileContent = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
            }
            Console.ReadKey();
            return fileContent;

        }

        static void AppendToFile(string fileName, string content)
        {
            string filePath = fileName + ".txt";

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(content);
            }
            Console.ReadKey();
        }

        static void DeleteFile(string fileName)
        {
            string filePath = fileName + ".txt";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            Console.ReadKey();
        }
    }
}
