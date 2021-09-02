namespace RouletteSinglePlayer
{
    public class Number
    {
        public int num { get; }
        public string dozen { get; }
        public string colour { get; }

        public Number(int n) 
        {
            num = n;
            if (num % 2 == 0)
                colour = "black";

            if (num % 2 == 1)
                colour = "red";

            if (num >= 1 && num <= 12)
                dozen = "dozen1";

            if (num >= 13 && num <= 24)
                dozen = "dozen2";

            if (num >= 25 && num <= 36)
                dozen = "dozen3";

            if (num == 0)
                colour = "green";
        }

        public override string ToString()
        {
            return $"({num}, {colour})";
        }
    }
}