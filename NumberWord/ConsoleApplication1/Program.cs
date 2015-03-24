using System;
namespace ConsoleApplication1
{
    using System.Threading;

    using NumberWord;

    class Program
    {
        private static int start;

        private static int finish;

        private static bool verbose;

        private static int step;

        static void Main(string[] args)
        {
            start = 1;
            finish = 1000;
            verbose = false;
            step = 10;

            var quit = false;

            while (quit == false)
            {
                quit = Menu();
                Console.Clear();
            }
        }

        private static bool Menu()
        {
            Console.WriteLine("KATA: NumberWord");
            Console.WriteLine("From {0} to {1}", start, finish);
            Console.WriteLine("Verbose Mode: {0}", ConvertBoolToOnOff(verbose));
            if (verbose)
            {
                Console.WriteLine("{0} milliseconds between steps", step);
            }
            Console.WriteLine();

            Console.WriteLine("1. Get the Answer");
            Console.WriteLine("2. Change the start");
            Console.WriteLine("3. Change the finish");
            Console.WriteLine("4. Change verbose mode");
            if (verbose)
            {
                Console.WriteLine("5. Change the step duration");
            }
            Console.WriteLine("0. Quit");
            Console.Write(">");
            var consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            if (consoleKeyInfo.KeyChar == '0')
            {
                return true;
            }

            switch (consoleKeyInfo.KeyChar)
            {
                case '1':
                    Console.WriteLine(GetAnswer(start, finish, verbose, step));
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    
                    break;
                case '2':
                    start = GetNumber("Start", start);
                    break;
                case '3':
                    finish = GetNumber("Finish", finish);
                    break;
                case '4':
                    verbose = !verbose;
                    break;
                case '5':
                    if (verbose)
                    {
                        step = GetNumber("Step", step);
                    }
                    break;
            }

            return false;
        }

        private static int GetNumber(string variable, int initial)
        {
            int newValue;

            Console.Write("{0}: ", variable);
            var readLine = Console.ReadLine();
            if (Int32.TryParse(readLine, out newValue))
            {
                return newValue;
            }

            return initial;
        }

        private static string ConvertBoolToOnOff(bool verbose)
        {
            return verbose ? "On" : "Off";
        }

        private static int GetAnswer(int start, int finish, bool verbose, int step)
        {
            var count = 0;

            for (var i = start; i <= finish; i++)
            {
                var words = NumberToWords.Convert(i);
                var letters = LetterCounter.Count(words);
                count += letters;

                if (verbose)
                {
                    Console.WriteLine("{0} : {1} : {2}", words, letters, count);
                    Thread.Sleep(step);
                }
            }

            return count;
        }
    }
}
