using LibraryObservable.Classes;
using System;

namespace ConsoleObservable
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Referee referee = new Referee("Back referee", game);
            SecondReferee referee2 = new SecondReferee("Line referee", game);

            game.GameGoes("Goal");
            referee2.StopWatch();
            game.GameGoes("Offside");

            Console.ReadKey();
        }
    }
}
