using System.Drawing;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Day03_PerfectlySphericalHousesInAVacuum.Tests")]
namespace Day03_PerfectlySphericalHousesInAVacuum
{
    internal abstract class DeliveryBase
    {
        protected Dictionary<Point, int> _addressCheckList = new();
        protected readonly string _directions;

        private const char _north = '^';
        private const char _south = 'v';
        private const char _east = '>';
        private const char _west = '<';

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
                case _east:
                    location.X++;
                    break;
                case _west:
                    location.X--;
                    break;
                case _north:
                    location.Y++;
                    break;
                case _south:
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
