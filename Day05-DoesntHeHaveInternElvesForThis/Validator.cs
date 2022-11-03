using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Day05-DoesntHeHaveInternElvesForThis.Tests")]
namespace Day05_DoesntHeHaveInternElvesForThis
{
    internal class Validator
    {
        private readonly string[] _input;

        internal Validator() { }

        internal Validator(string[] input)
        {
            _input = input;
        }

        internal void Solve()
        {
            var counter = 0;

            foreach (var line in _input)
            {
                if (IsNiceLineV2(line))
                {
                    counter++;
                }
            }
        }

        internal bool IsNiceLineV1(string line)
        {
            // rule 1 - 3 or more vowels
            var vowelsFound = 0;

            // rule 2 - letter repetition
            var letterRepeated = false;

            // rule 3 - does not contain ab, cd, pq, or xy
            var illegalCombo = false;

            var possibleVowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i < line.Length; i++)
            {
                if (possibleVowels.Contains(line[i]))
                {
                    vowelsFound++;
                }

                if (i < line.Length - 1)
                {
                    if (!letterRepeated && line[i] == line[i + 1])
                    {
                        letterRepeated = true;
                    }

                    var combo = line[i].ToString() + line[i + 1].ToString();
                    if (combo == "ab" || combo == "cd" || combo == "pq" || combo == "xy")
                    {
                        illegalCombo = true;
                    }
                }
            }

            var result = vowelsFound >= 3 && letterRepeated && !illegalCombo;
            return result;
        }

        internal bool IsNiceLineV2(string line)
        {
            var repearRule = false;
            var pairRule = false;

            for (int i = 0; i < line.Length; i++)
            {
                if (i < line.Length - 1)
                {
                    var pair = line.Substring(i, 2);
                    if (line.IndexOf(pair, i + 2) != -1)
                    {
                        pairRule = true;
                    }
                }

                if (i < line.Length - 2)
                {
                    if (line[i] == line[i + 2])
                    {
                        repearRule = true;
                    }
                }
            }

            return repearRule && pairRule;
        }
    }
}
