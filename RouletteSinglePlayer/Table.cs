using System;

namespace RouletteSinglePlayer
{
    class Table
    {
        private Random ball = new();
        public Number ThrowBall()
        {
            return new Number(ball.Next(37));
        }
    }
}
