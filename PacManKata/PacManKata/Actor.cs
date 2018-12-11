namespace PacManKata
{
    public class Actor : BoardElement
    {
        public char Direction { get; set; }  //w-a-s-d

        public Actor (char c) : base (c)
        {
            Direction = 'w';
        }
    }
}