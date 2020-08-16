using System;

namespace AmmoRule
{
    class Ammorule
    {

        static void Main(string[] args)
        {
            Launcher l = new Launcher();
            l.start();
            Console.WriteLine("Out of ammo!!");
            Console.ReadKey();
        }
    }
}
