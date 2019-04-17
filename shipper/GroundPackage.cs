using System;
namespace shipper
{
    class GroundPackage
    {
        private int _origin,
            _destination;

        private double _length,
            _width,
            _height,
            _weight;

        private const double MIN_DIMENSION = 0,
            DEFAULT_DIMENSION = 1;

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
                const int divider = 10000;
                int larger,
                    smaller,
                    distance;

                larger = Math.Max(OriginZip, DestinationZip);
                smaller = Math.Min(OriginZip, DestinationZip);

                distance = (larger / divider) - (smaller / divider);

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
                const int DEFAULT_ZIP = 40202;

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
                const int DEFAULT_ZIP = 90210;

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

        private bool IsValidZIP(int zip)
        {
            int ZIP_MIN = 0,
            ZIP_MAX = 99999;

            return (zip >= ZIP_MIN && zip <= ZIP_MAX);
        }

        public double CalcCost()
        {
            const double DIMENSION_COST = .25,
                DISTANCE_COST = .45;
            const int MIN_DISTANCE = 1;

            double cost;
            cost = (DIMENSION_COST * (Length + Width + Height)) + (DISTANCE_COST * (ZoneDistance + MIN_DISTANCE) * Weight);

            return cost;
        }

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
