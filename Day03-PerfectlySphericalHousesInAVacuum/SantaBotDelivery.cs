using System.Drawing;

namespace Day03_PerfectlySphericalHousesInAVacuum
{
    internal class SantaBotDelivery
    {
        private Dictionary<Point, int> _addressCheckList = new();

        private readonly string _directions;
        private Point _santaCurrentLocation = new Point(0, 0);
        private Point _robotCurrentLocation = new Point(0, 0);

        internal SantaBotDelivery(string directions)
        {
            _directions = directions;
            _addressCheckList.Add(_santaCurrentLocation, 2);
        }

        internal void BeginDelivery()
        {
            for (int i = 0; i < _directions.Length; i++)
            {
                var moveRobot = i % 2 != 0;
                if (moveRobot)
                {
                    _robotCurrentLocation = UpdateLocation(_directions[i], _robotCurrentLocation);
                    AddToAddressCheckList(_robotCurrentLocation);
                }
                else
                {
                    _santaCurrentLocation = UpdateLocation(_directions[i], _santaCurrentLocation);
                    AddToAddressCheckList(_santaCurrentLocation);
                }
            }
        }

        private Point UpdateLocation(char directionChar, Point location)
        {
            switch (directionChar)
            {
                case '>':
                    location.X++;
                    break;
                case '<':
                    location.X--;
                    break;
                case '^':
                    location.Y++;
                    break;
                case 'v':
                    location.Y--;
                    break;
            }

            return location;
        }

        internal int GetAddressCheckListCount()
        {
            return _addressCheckList.Count;
        }

        private void AddToAddressCheckList(Point currentLocation)
        {
            if (!_addressCheckList.ContainsKey(currentLocation))
            {
                _addressCheckList.Add(currentLocation, 1);
                return;
            }

            _addressCheckList[currentLocation]++;
        }
    }
}
