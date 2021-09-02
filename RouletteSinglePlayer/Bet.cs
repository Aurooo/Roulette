

namespace RouletteSinglePlayer
{
    class Bet
    {
        public int amount;
        public string guess;
        public bool win;

        public Bet(int amount, string guess)
        {
            this.amount = amount;
            this.guess = guess;
            win = false;
        }

        public override string ToString()
        {
            return win ? $"{amount}$ on {guess} - WIN" : $"{amount}$ on {guess} - LOSS";
        }
    }
}
