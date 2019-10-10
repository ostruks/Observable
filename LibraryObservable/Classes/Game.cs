using LibraryObservable.Interfaces;
using System.Collections.Generic;

namespace LibraryObservable.Classes
{
    public class Game : IObservable
    {
        private Player player;
        private List<IObserver> observers;

        public Game()
        {
            player = new Player("Serhii", 46);
            observers = new List<IObserver>();
        }
        
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(player);
            }
        }

        public void GameGoes(string action)
        {
            player.Action = action;
            NotifyObservers();
        }
    }
}
