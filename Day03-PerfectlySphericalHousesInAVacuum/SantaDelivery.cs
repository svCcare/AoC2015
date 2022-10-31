﻿using System.Drawing;

namespace Day03_PerfectlySphericalHousesInAVacuum
{
    internal class SantaDelivery
    {
        private Dictionary<Point, int> _addressCheckList = new();
        private readonly string _directions;
        private Point _currentLocation = new Point(0, 0);

        internal SantaDelivery(string directions)
        {
            _directions = directions;
            _addressCheckList.Add(_currentLocation, 1);
        }

        internal void BeginDelivery()
        {
            foreach (var directionChar in _directions)
            {
                UpdateLocation(directionChar);
                AddToAddressCheckList(_currentLocation);
            }
        }

        private void UpdateLocation(char directionChar)
        {
            switch (directionChar)
            {
                case '>':
                    _currentLocation.X++;
                    break;
                case '<':
                    _currentLocation.X--;
                    break;
                case '^':
                    _currentLocation.Y++;
                    break;
                case 'v':
                    _currentLocation.Y--;
                    break;
            }
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
