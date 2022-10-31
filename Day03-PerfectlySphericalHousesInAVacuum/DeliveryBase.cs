using System.Drawing;

namespace Day03_PerfectlySphericalHousesInAVacuum
{
    internal abstract class DeliveryBase
    {
        protected Dictionary<Point, int> _addressCheckList = new();
        protected readonly string _directions;

        internal DeliveryBase(string directions)
        {
            _directions = directions;
        }

        internal abstract void BeginDelivery();

        internal int GetAddressCheckListCount()
        {
            return _addressCheckList.Count;
        }

        protected Point UpdateLocation(char directionChar, Point location)
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

        protected void AddToAddressCheckList(Point currentLocation)
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
