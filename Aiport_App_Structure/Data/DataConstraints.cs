namespace Aiport_App_Structure.Data
{
    public class DataConstraints
    {
        public class Airport
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 200;

            public const int CodeLength = 3;
        }

        public class City
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 120;
        }

        public class Country
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 70;
        }

        public class Flight
        {
            public const int NumberLength = 6;
        }

        public class  Passenger
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 150;
        }

        public class Aicraft
        {
            public const int ModelMinLength = 3;
            public const int ModelMaxLength = 100;
        }

        public class Manufacturer
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;
        }

    }
}
