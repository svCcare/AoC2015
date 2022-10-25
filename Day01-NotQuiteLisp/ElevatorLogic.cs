namespace Day01_NotQuiteLisp
{
    internal class ElevatorLogic
    {
        readonly string _input;
        readonly char _characterUp;
        readonly char _characterDown;

        public ElevatorLogic(string input, char characterUp, char characterDown)
        {
            _input = input;
            _characterUp = characterUp;
            _characterDown = characterDown;

            var resultOne = SolveOne();
            var resultTwo = SolveTwo();
        }

        private int SolveOne()
        {
            Dictionary<char, int> dictionary = new();
            foreach (var item in _input)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 1);
                }

                dictionary[item]++;
            }

            return dictionary[_characterUp] - dictionary[_characterDown];
        }

        private int SolveTwo()
        {
            var result = 1;
            var currentLevel = 0;
            foreach (var item in _input)
            {
                currentLevel = item == '('
                    ? currentLevel + 1
                    : currentLevel - 1;

                if (currentLevel < 0)
                {
                    return result;
                }

                result++;
            }

            return 0;
        }
    }
}
