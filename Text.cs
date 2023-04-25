namespace mis321_pa4
{
    public class Text //An extra used to print string one char at a time during the instructions
    {
        public static void WriteStaggeredText(string textToWrite, int lettersToWriteAtOneTime, int waitTimeInMS, ConsoleColor textColor)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            try
            {
                int count = 0;
                while (count < textToWrite.Length)
                {
                    int letterCount = lettersToWriteAtOneTime;
                    string text = textToWrite.Substring(count, letterCount);
                    Console.Write(text);
                    count += letterCount;
                    Thread.Sleep(waitTimeInMS);
                }
            }
            catch (Exception)
            {

            }

            Console.ForegroundColor = oldColor;
        }

        public static void TextFlow()
        {
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
    }
}