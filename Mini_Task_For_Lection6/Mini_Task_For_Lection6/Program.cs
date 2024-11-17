using System;
using System.IO;
using System.Linq;

namespace Mini_Task_For_Lection6
{
    public class MyTask 
    {
        public string[] GetText()
        {
            using (StringReader reader = new StringReader("20 3\n  Привет!  \n Напиши мне.  \n    Пока =) "))
            {
                return reader.ReadToEnd().Split('\n');
            }
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

        public void WriteResult(string text)
        {
            File.AppendAllText("Output.txt", text);
            using (StringWriter writer = new StringWriter())
            {
                writer.Write(text);
                Console.WriteLine(writer.ToString());
            }
        }

        public string TextFormation(int spaceBegin, int spaceEnd, string text, int index, int n)
        {
            if (index < n)
                return new string(' ', spaceBegin) + text + new string(' ', spaceEnd) + '\n';
            else
                return new string(' ', spaceBegin) + text + new string(' ', spaceEnd);
        }

        public int ParseInt(string text)
        {
            if (int.TryParse(text, out var number))
                return number;
            throw new Exception("Нельзя преобразовать в целое число");
        }

        public string FormattingText(string[] strings)
        {
            string text = "";
            string firstLine = strings[0];
            int k = ParseInt(firstLine.Split(' ')[0]);
            int n = ParseInt(firstLine.Split(' ')[1]);

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

            try
            {
                string text = myTask.FormattingText(myTask.GetText());
                myTask.WriteResult(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
