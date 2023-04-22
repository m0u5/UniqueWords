using System.Text.RegularExpressions;

namespace UniqueWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath;
            Console.Write("Введите путь к файлу: ");
            filePath = Console.ReadLine();
            string resultPath;
            Console.Write("Введите путь к резульату: ");
            resultPath = Console.ReadLine();
            var wf = new WordsFinder(filePath, resultPath);
            wf.ReadFromFile();
            wf.SortWordsList();
            wf.WriteToFile();

        }
    }
}