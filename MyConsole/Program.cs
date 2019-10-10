using Library;
using System;

namespace MyConsole
{
    class Program
    {
        public delegate double Circle(double r);
        public delegate double Funck<in T1, in T2, out TResult>(double a, double b);
        public delegate void ProgramStateHandler(string message);
        public static event ProgramStateHandler GetMessage;

        static void Main(string[] args)
        {
            WorkWithDelegate();

            Console.ReadKey();
        }

        private static void WorkWithDelegate()
        {
            Circle circuit = new Circle(Circuit);
            GetMessage += Show;

            Console.Write($"Circuit: {circuit(22.5)}");
            Console.WriteLine();

            circuit = new Circle(Area);
            Console.Write($"Area: {circuit(22.5)}");
            Console.WriteLine();

            circuit = new Circle(Volume);
            Console.Write($"Volume: {circuit(22.5)}\n");
            Console.WriteLine("==============================");

            Funck<double, double, double> numbers = OnePlusTwo;
            Console.Write("Addition: ");
            double numb = WorkWithNumbers(22.5, 12.2, numbers);
            
            Console.WriteLine();

            Console.Write("Subtraction: ");
            numb = WorkWithNumbers(22.5, 12.2, (a, b) => a - b);
            Console.WriteLine();

            Console.Write("Multi: ");
            numb = WorkWithNumbers(22.5, 12.2, (a, b) => a * b);
            Console.WriteLine();

            ClassCounter classCounter = new ClassCounter();
            classCounter.Handler += Message;
            classCounter.Count();
        }

        private static double Circuit(double r)
        {
            return Math.Round((2 * Math.PI * r), 2);
        }

        private static double Area(double r)
        {
            return Math.Round((Math.PI * Math.Pow(r, 2)), 2);
        }

        private static double Volume(double r)
        {
            return Math.Round(((4/3) * Math.PI * Math.Pow(r, 3)), 2);
        }

        private static double WorkWithNumbers(double a, double b, Funck<double, double, double> numbers)
        {
            double result = numbers(a, b);
            if (GetMessage != null)
                GetMessage($"{result}");
            return result;
        }

        private static double OnePlusTwo(double a, double b)
        {
            return a + b;
        }

        public static void Show(string message)
        {
            Console.Write(message);
        }

        public static void Message()
        {
            Handler_I handler_I = new Handler_I();
            handler_I.Message();
            Handler_II handler_II = new Handler_II();
            handler_II.Message();
        }
    }
}
