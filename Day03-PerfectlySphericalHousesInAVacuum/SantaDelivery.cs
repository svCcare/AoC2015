using System.Drawing;

namespace Day03_PerfectlySphericalHousesInAVacuum
{
    internal class SantaDelivery : DeliveryBase
    {
        private Point _currentLocation = new();

        public SantaDelivery(string directions) : base(directions)
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
