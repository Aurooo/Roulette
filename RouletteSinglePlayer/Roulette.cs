using System;
using System.Collections.Generic;

namespace RouletteSinglePlayer
{
    class Roulette
    {
        public readonly int minTable = 1;
        public readonly int maxTable = 250;
        public Bet bet;
        private Table table;
        public Number ball;

        public int Budget { get; set; }
        private Dictionary<Number, Bet> Rounds { get; }


        public Roulette(int budget)
        {
            this.Budget = budget;
            Rounds = new();
            table = new();
        }

        public void getBet(int amount, string guess)
        {
            bet = new(amount, guess);
            Budget -= amount;
        }

        public void PlayRound()
        {
            ball = table.ThrowBall();
            if (bet.guess == ball.colour)
            {
                Budget += bet.amount * 2;
                bet.win = true;
            }
            if(bet.guess == ball.dozen)
            {
                Budget += bet.amount * 3;
                bet.win = true;
            }
            if (int.TryParse(bet.guess, out int n) && n == ball.num)
            {
                Budget += bet.amount * 36;
                bet.win = true;
            }
            Rounds.Add(ball, bet);
        }

        public void WriteRound()
        {
            Console.WriteLine($"{ball} - {bet}"); 
        }

        public void WriteHistory()
        {
            // displays all rounds (outcome and bet)
            foreach (var round in Rounds)
                Console.WriteLine($"{round.Key.num}, {round.Key.colour} -> {round.Value}");

            Console.WriteLine("---------------------------------------");
        }

        



    }
}
