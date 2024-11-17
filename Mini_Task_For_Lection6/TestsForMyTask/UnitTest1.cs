using Mini_Task_For_Lection6;

namespace TestsForMyTask
{
    public class UnitTest1
    {
        [Fact]
        public void Ruturn_Required_Number_Of_Spaces()
        {
            MyTask myTask = new MyTask();
            int check = myTask.RequiredNumberOfSpaces("  Привет!  ", 20);
            Assert.Equal(9,check);
        }

        [Fact]
        public void CheckLenght_WhenLenghtTextLessWidth_ReturnTrue()
        {
            MyTask myTask = new MyTask();
            bool check = myTask.CheckingPossibilityOfFormatting("   RandomString   ", 6);
            Assert.True(check);
        }

        [Fact]
        public void Return_Right_Format()
        {
            MyTask myTask = new MyTask();
            string check = myTask.FormattingText([]);
            Assert.Equal("      Привет!       ", check);
        }
    }
}