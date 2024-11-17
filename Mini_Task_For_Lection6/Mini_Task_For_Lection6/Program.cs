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

        public void WriteImposibleToTextFile(string text)
        {
            File.WriteAllText("Output.TXT", text);
        }

        public string TextFormation(int spaceBegin, int spaceEnd, string text, int index, int n)
        {
            if (index < n)
                return new string(' ', spaceBegin) + text.Trim() + new string(' ', spaceEnd) + '\n';
            else
                return new string(' ', spaceBegin) + text.Trim() + new string(' ', spaceEnd);
        }

        public string FormattingText(string[] strings)
        {
            string text = "";
            string firstLine = strings[0];
            int k = int.Parse(firstLine.Split(' ')[0]);
            int n = int.Parse(firstLine.Split(' ')[1]);

            for (int i = 1; i < strings.Count(); i++) 
            {
                if (!CheckingPossibilityOfFormatting(strings[i].Trim(), k))
                {
                    text = "Impossible.";
                    break;
                }
                else
                {
                    int numberSpaces = RequiredNumberOfSpaces(strings[i].Trim(), k);
                    int spacesAtBeginning = numberSpaces / 2;
                    int spacesAtEnd = numberSpaces - spacesAtBeginning;
                    text += TextFormation(spacesAtBeginning, spacesAtEnd, strings[i].Trim(), i, n);
                }
            }
            return text;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MyTask myTask = new MyTask();

            string text = myTask.FormattingText(myTask.GetText());
            myTask.WriteImposibleToTextFile(text);
        }
    }
}
