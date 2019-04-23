/*
 * Grading ID: M5477
 * Program: 4
 * Due Date: April 23 2019
 * Course Section: 01
 * Description: Creates a GroundPackage class to estimate shipping costs.
 */

using System;
namespace shipper
{
    class GroundPackage
    {
        private int _origin, // Origin ZIP code
            _destination;    // Destination ZIP code

        private double _length, // Package length
            _width,             // Package width
            _height,            // Package height
            _weight;            // Package weight

        private const double MIN_DIMENSION = 0, // Minimum dimension possible
            DEFAULT_DIMENSION = 1;              // Default dimension when an invalid value is provided

        /*
         * Preconditions: Origin ZIP code, destination ZIP code,
         * package length, package width, package height, package weight
         * Postconditions: None
         */

        public GroundPackage(int origin, int destination, double length, double width, double height, double weight)
        {
            OriginZip = origin;
            DestinationZip = destination;
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        public int ZoneDistance
        {
            get
            {
                const int DIVIDER = 10000; // Cheat to get us a whole number
                int larger,   // The larger number
                    smaller,  // The smaller number
                    distance; // The distance (based on ZIP) between destinations

                larger = Math.Max(OriginZip, DestinationZip);
                smaller = Math.Min(OriginZip, DestinationZip);

                distance = (larger / DIVIDER) - (smaller / DIVIDER);

                return distance;
            }
        }

        public int OriginZip
        {
            get
            {
                return _origin;
            }
            set
            {
                const int DEFAULT_ZIP = 40202; // A default ZIP code

                if (IsValidZIP(value))
                    _origin = value;
                else
                    _origin = DEFAULT_ZIP;
            }
        }

        public int DestinationZip
        {
            get
            {
                return _destination;
            }
            set
            {
                const int DEFAULT_ZIP = 90210; // A default ZIP code

                if (IsValidZIP(value))
                    _destination = value;
                else
                    _destination = DEFAULT_ZIP;
            }
        }

        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value > MIN_DIMENSION)
                    _length = value;
                else
                    _length = DEFAULT_DIMENSION;
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value > MIN_DIMENSION)
                    _width = value;
                else
                    _width = DEFAULT_DIMENSION;
            }
        }

        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value > MIN_DIMENSION)
                    _height = value;
                else
                    _height = DEFAULT_DIMENSION;
            }
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value > MIN_DIMENSION)
                    _weight = value;
                else
                    _weight = DEFAULT_DIMENSION;
            }
        }

        /* 
         * Preconditions: ZIP code
         * Postconditions: true/false
         */

        private bool IsValidZIP(int zip)
        {
            int ZIP_MIN = 0, // Lowest ZIP possible
            ZIP_MAX = 99999; // Highest ZIP possible

            return (zip >= ZIP_MIN && zip <= ZIP_MAX);
        }

        /*
         * Preconditions: None
         * Postconditons: Double with cost of shipping
         */

        public double CalcCost()
        {
            const double DIMENSION_COST = .25, // Cost per inch
                DISTANCE_COST = .45;           // Cost factor for distance
            const int MIN_DISTANCE = 1;        // Shortest distance possible

            double cost;
            cost = (DIMENSION_COST * (Length + Width + Height)) + (DISTANCE_COST * (ZoneDistance + MIN_DISTANCE) * Weight);

            return cost;
        }

        /*
         * Preconditions: None
         * Postconditions: String presenting  all variables in the class
         */

        public override string ToString()
        {
            return $"Origin ZIP: {OriginZip:D5}{Environment.NewLine}" +
                $"Destination ZIP: {DestinationZip:D5}{Environment.NewLine}" +
                $"Zone Distance: {ZoneDistance}{Environment.NewLine}" +
                $"Length: {Length}{Environment.NewLine}" +
                $"Width: {Width}{Environment.NewLine}" +
                $"Height: {Height}{Environment.NewLine}" +
                $"Weight: {Weight}";
        }
    }
}
