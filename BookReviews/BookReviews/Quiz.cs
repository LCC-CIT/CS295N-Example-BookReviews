namespace BookReviews
{
    public static class Quiz
    {
        public const string RIGHT = "Right";
        public const string WRONG = "Wrong";
        public const string NAQ = "Not a question";

        public static string CheckAnswer(int questionNumber, string answer)
        {
            string correct;
            switch (questionNumber)
            {
                case 1:
                    correct = answer == "Victor Hugo" ? RIGHT : WRONG;
                    break;
                case 2:
                    correct = answer == "1812" ? RIGHT : WRONG;
                    break;
                case 3:
                    correct = answer == "false" ? RIGHT : WRONG;
                    break;
                default:
                    correct = NAQ;
                    break;
            }
            return correct;
        }
    }
}
