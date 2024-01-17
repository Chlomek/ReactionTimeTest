using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HumanBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tries = 5;
            int TotalReactionTime = 0;
            int bonusTry = 0;
            while (tries > 0)
            {
                int reactionTime = GetReactionTime();
                if (reactionTime == -1)
                {
                    tries++;
                    bonusTry++;
                    if (bonusTry == 3)
                    {
                        Console.WriteLine("You have failed too many times.");
                        Console.ReadLine();
                        tries = 5;
                    }
                }
                else
                {
                    TotalReactionTime += reactionTime;
                }
                tries--;
            }
            TotalReactionTime /= 5;

            Console.WriteLine($"Your average reaction time was {TotalReactionTime} ms");
            Console.ReadLine();
        }

        static int GetReactionTime()
        {
            try
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Press any key to start the reaction test...");
                Console.ReadKey();
                Console.Clear();

                Thread.Sleep(new Random().Next(1, 5) * 1000);

                if (Console.KeyAvailable)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.WriteLine("You pressed too early!");
                    Console.ReadLine();
                    Console.ReadKey(true);

                    return -1;
                }

                DateTime startTime = DateTime.Now;

                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("Press");
                Console.ReadKey();

                DateTime endTime = DateTime.Now;

                // Calculate the reaction time in seconds
                TimeSpan reactionTime = endTime - startTime;
                int seconds = (int)reactionTime.TotalMilliseconds;

                Console.WriteLine($"Your reaction time was {seconds} ms");
                Console.ReadKey();

                return seconds;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}

