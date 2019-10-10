using LibraryObservable.Interfaces;
using System;

namespace LibraryObservable.Classes
{
    public class Referee : IObserver
    {
        public string Name { get; set; }
        IObservable player;

        public Referee(string name, IObservable player)
        {
            this.Name = name;
            this.player = player;
            player.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            Player player = (Player)ob;
            switch (player.Action)
            {
                case "Goal":
                    Console.WriteLine($"{Name} says: {player.Name} do Goal, not Offside!!!");
                    break;
                case "Offside":
                    Console.WriteLine($"{Name} says: {player.Name} do Offside, not Goal!!!");
                    break;
            }
        }

        public void StopWatch()
        {
            player.RemoveObserver(this);
            player = null;
        }
    }
}
