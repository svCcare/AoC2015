using System.Drawing;

namespace Day03_PerfectlySphericalHousesInAVacuum
{
    internal class SantaBotDelivery : DeliveryBase
    {
        private Point _santaCurrentLocation = new();
        private Point _robotCurrentLocation = new();

        internal SantaBotDelivery(string directions) : base(directions)
        {
            _addressCheckList.Add(_santaCurrentLocation, 2);
        }

        internal override void BeginDelivery()
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
    }
}
