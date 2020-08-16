using System;
using System.IO;

namespace AmmoRule
{
    class Launcher
    {
        protected bool low { get; set; }
        protected bool high { get; set; }
        public static int rockets { get; set; }
        protected int reload { get; set; }
        public void start()
        {

            // Define initial ammo level and initial reload quantity
            rockets = 23;
            reload = 5;

            int rocketsfired;
            int reloadcr;

            Random random = new Random();
            using (StreamWriter writer = new StreamWriter("data1.csv"))
            {

                writer.WriteLine("Crisp, Fuzzy");
                while (rockets > 0)
                {
                    CrispRocket cr = new CrispRocket();
                    FuzzyRocket fr = new FuzzyRocket();

                    Console.WriteLine("Rockets remaining: " + rockets);
                    Console.WriteLine("Fuzzy Reloading with: " + fr.rules());
                    Console.WriteLine("Crisp Reloading with: " + cr.rules());
                    rockets += reload;

                    rocketsfired = random.Next(2, 10);
                    if (rocketsfired > rockets)
                        rocketsfired = rockets;
                    rockets -= rocketsfired;
                    Console.WriteLine("Rockets fired: " + rocketsfired);

                    reloadcr = cr.rules();

                    reload = fr.rules();
                    writer.WriteLine("" + reloadcr + ", " + reload + "");
                    System.Threading.Thread.Sleep(1000);
                }
                writer.Close();
            }
        }
       
    }
        
    class CrispRocket : Launcher
    {

        public int rules()
        {
            int ammo = rockets;
            if (ammo < 7) //Rule 1
            {
                low = true;
            }

            if (ammo >= 12) // Rule 2
            {
                high = true;
            }

            if (low == true)
               return reload = 7;
            else
               return reload = 1;

        }
    }

    class FuzzyRocket : Launcher
    {
        double low = 0, high = 0;
        //int ammo = rockets;
        public int rules()
        {
            double max = 7;
            double min = 1;

            if (rockets < 40) //Rule 1
            {
                low = (1 - (Convert.ToDouble(rockets) / 40));
            }

            if (rockets > 10) // Rule 2
            {
                high = ((Convert.ToDouble(rockets) - 10) / 40);
            }

            reload = Convert.ToInt32(Math.Round((low * max) + (high * min)));

            return reload;
        }
    }
}
