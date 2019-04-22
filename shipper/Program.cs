/*
 * Grading ID: M5477
 * Program: 4
 * Due Date: April 23 2019
 * Course Section: 01
 * Description: Estimates shipping costs based on dimensions, weight, and distance.
 */

using System;

namespace shipper
{
    class Program
    {
        static void Main(string[] args)
        {
            GroundPackage[] packages = new GroundPackage[] {
            new GroundPackage(41005, 13495, 6.7, 3.2, 4.4, 4.3),
            new GroundPackage(40208, 41005, 2.0, 3.0, 2.0, 4.0),
            new GroundPackage(80123, 54302, 3.7, 2.4, 7.54, 8.99),
            new GroundPackage(91504, 60606, 11.2, 13.4, 15, 11),
            new GroundPackage(05401, 41048, 0.5, 1, 0.6, 0.45),
            new GroundPackage(-1, -1, -1, -1, -1, -1) // Tests getters and setters
            };

            DisplayPackages(packages);

            // Changing one value each to make sure each set works
            packages[0].OriginZip = 45202;
            packages[1].DestinationZip = 00606;
            packages[2].Length = 4.4;
            packages[3].Width = 5;
            packages[4].Height = 2.3;
            packages[5].Weight = 69;

            DisplayPackages(packages); 
        }

        /*
         * Preconditions: GroundPackage array
         * Postconditions: None
         */

        public static void DisplayPackages(GroundPackage[] packages)
        {
            foreach (GroundPackage package in packages)
            {
                Console.WriteLine(package.ToString());
                Console.WriteLine($"Cost: {package.CalcCost():C}{Environment.NewLine}");
            }
        }
    }
}
