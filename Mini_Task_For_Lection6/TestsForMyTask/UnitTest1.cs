using Mini_Task_For_Lection6;

namespace TestsForMyTask
{
    public class UnitTest1
    {
        [Fact]
        public void Ruturn_Required_Number_Of_Spaces()
        {
            MyTask myTask = new MyTask();
            int check = myTask.RequiredNumberOfSpaces("  ������!  ", 20); Assert.Equal(9, check);
        }

        [Fact]
        public void CheckLenght_WhenLenghtTextLessWidth_ReturnTrue()
        {
            MyTask myTask = new MyTask();
            bool check = myTask.CheckingPossibilityOfFormatting("   RandomString   ", 20); Assert.True(check);
        }

        [Fact]
        public void CheckLenght_WhenLenghtTextLessWidth_ReturnFalse()
        {
            MyTask myTask = new MyTask();
            bool check = myTask.CheckingPossibilityOfFormatting("������.", 5); Assert.False(check);
        }

        [Fact]
        public void Return_Right_Format()
        {
            MyTask myTask = new MyTask();
            string check = myTask.FormattingText(["20 3", "  ������!  ", " ������ ���.  ", "    ���� =) "]); Assert.Equal("      ������!       \n    ������ ���.     \n      ���� =)       ", check);
        }
    }
}