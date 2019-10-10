namespace LibraryObservable
{
    public class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Action { get; set; }

        public Player(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }
    }
}
