using System.Drawing;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Day03-PerfectlySphericalHousesInAVacuum.Tests")]
namespace Day03_PerfectlySphericalHousesInAVacuum
{
    internal class SantaDelivery : DeliveryBase
    {
        private Point _currentLocation = new();

        internal SantaDelivery(string directions) : base(directions)
        {
            _addressCheckList.Add(_currentLocation, 1);
        }

        internal override void BeginDelivery()
        {
            foreach (var directionChar in _directions)
            {
                _currentLocation = UpdateLocation(directionChar, _currentLocation);
                AddToAddressCheckList(_currentLocation);
            }
        }
    }
}
