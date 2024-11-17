using System;
using System.IO;
using System.Linq;

namespace Mini_Task_For_Lection6
{
    public class MyTask 
    {
        public string[] GetText()
        {
            return File.ReadAllLines("Input.txt");
        }

        public bool CheckingPossibilityOfFormatting(string text, int k)
        {
            if (text.Length > k)
                return false;
            return true;
        }

        public int RequiredNumberOfSpaces(string text, int k)
        {
            return k - text.Length;
        }

        public void FormattingText(string[] strings)
        {
            string firstLine = strings[0];
            int k = int.Parse(firstLine.Split(' ')[0]);
            int n = int.Parse(firstLine.Split(' ')[1]);

            foreach (string text in strings.Skip(1)) 
            {
                if (!CheckingPossibilityOfFormatting(text.Trim(), k))
                {
                    File.WriteAllText("Output.TXT", "Impossible.");
                    break;
                }
                else
                {
                    int numberSpaces = RequiredNumberOfSpaces(text.Trim(), k);
                    int spacesAtBeginning = numberSpaces / 2;
                    int spacesAtEnd = numberSpaces - spacesAtBeginning;

                    File.AppendAllText("Output.txt", new string('+', spacesAtBeginning) + text.Trim() + new string('+', spacesAtEnd) + '\n');
                }
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MyTask myTask = new MyTask();

            myTask.FormattingText(myTask.GetText());

            Console.WriteLine(13 / 2);
        }
    }
}
