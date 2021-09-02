using System;

namespace RouletteSinglePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget;
            do
            {
                Console.WriteLine("Starting budget? (int)");
            } while (!(int.TryParse(Console.ReadLine(), out budget) && budget > 0));
            Console.Clear();
            Roulette roulette = new(budget);

            do
            {
                int amount;
                string guess;

                // input a valid guess according to format
                do
                {
                    Console.WriteLine("your guess? -> (number OR black/red OR dozen1/2/3)");
                    guess = Console.ReadLine().ToLower().Trim();
                } while (CheckGuess(guess));

                //input a valid amount according to format, budget and min/max of the table
                do
                {
                    Console.WriteLine("how much? -> (int)");
                } while (!(int.TryParse(Console.ReadLine(), out amount) && amount <= roulette.Budget && amount >= roulette.minTable && amount <= roulette.maxTable));
                Console.Clear();

                //places the bet and updates the budget
                roulette.getBet(amount, guess);

                //throws the ball, checks the bet and updates the budget accordingly
                //saves the round
                roulette.PlayRound();

                roulette.WriteRound();


                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"you have {roulette.Budget}$");
                Console.WriteLine("---------------------------------------");
            } while (roulette.Budget != 0);

            roulette.WriteHistory();
        }

        static bool CheckGuess(string s)
        {
            if (int.TryParse(s, out int n) && n >= 0 && n < 37)
                return false;
            if (s == "black" || s == "red" || s == "dozen1" || s == "dozen2" || s == "dozen3")
                return false;
            return true;

        }
    }
}
