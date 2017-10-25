using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _17Tot
{
    class Program
    {
        public static int Result { get; set; }

        static void Main()
        {
            Console.WriteLine("How many people are playing?");
            int player_count = PlayerNumber();

            List<string> names = new List<string>(PlayerNames(player_count));
            int length = names.Count;

            Console.WriteLine("Press enter to roll the dice");

            var res = 0;
            int count = 0;

            while (res < 17)
            {
                if(count >= length)
                {
                    count = 0;
                }
                Console.WriteLine($"{names[count]} is playing:");
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Enter)
                {
                    res += RollDice();
                    Console.WriteLine($"Result = {res}, do you want to roll again?");
                }
                else
                {
                    Console.WriteLine("Loose life!");
                }
                count++;
            }            
            Console.WriteLine($"{res} You drink!");
            Console.ReadLine();
        }



        static int PlayerNumber()
        {
            string input;
            int numberOfPlayers;
            bool try_input;
            do
            {
                input = Console.ReadLine();
                try_input = Int32.TryParse(input, out numberOfPlayers);
                if (!try_input)
                {
                    Console.WriteLine("Please enter a number!");
                }
            } while (!try_input);
            return numberOfPlayers;

        }



        static List<string> PlayerNames(int players)
        {
            List<string> playerlist = new List<string>();
            for (int count = 0; count < players; count++)
            {
                Console.Write($"Player {count + 1} name: ");
                playerlist.Add(Console.ReadLine());
            }

            Console.WriteLine("The following players are playing:");
            foreach (string name in playerlist)
            {
                Console.WriteLine($"{name} ");
            }
            Console.Write("\n");

            return playerlist;
        }



        static int RollDice()
        {
            Random rnd = new Random();
            var diceRoll = rnd.Next(1, 6);
            Console.WriteLine($"You rolled {diceRoll}!");
            if (diceRoll == 3)
            {
                diceRoll = 0;
            }
            return diceRoll;
            
        }
    }
}
