using LibraryObservable.Interfaces;
using System;

namespace LibraryObservable.Classes
{
    public class SecondReferee : IObserver
    {
        public string Name { get; set; }
        IObservable player;

        public SecondReferee(string name, IObservable player)
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
                    Console.WriteLine($"{Name} says: {player.Name} don`t do Goal, Offside!!!");
                    break;
                case "Offside":
                    Console.WriteLine($"{Name} says: {player.Name} do Goal, not Offside!!!");
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
