using System.Diagnostics;
using System.Security.Cryptography;

namespace Day04_TheIdealStockingStuffer
{
    internal class MD5Solver
    {
        private readonly string input;

        internal MD5Solver(string input)
        {
            this.input = input;
        }

        internal (int iterations, long elapsed) Solve(bool secondPart = false)
        {
            int counter = 0;
            string currentKey = input + counter;

            var timer = new Stopwatch();
            timer.Start();

            using (MD5 md5Hash = MD5.Create())
            {
                while (IncrementNeeded(md5Hash, currentKey, secondPart))
                {
                    counter++;
                    currentKey = input + counter;
                }
            }

            timer.Stop();

            return (counter, timer.ElapsedMilliseconds);
        }

        private bool IncrementNeeded(MD5 md5Hash, string currentKey, bool secondPart)
        {
            byte[] hashBytes = md5Hash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(currentKey));

            if (hashBytes[0] != 0x00)
            {
                return true;
            }

            if (hashBytes[1] != 0x00)
            {
                return true;
            }

            if (hashBytes[2] > 0x0F)
            {
                return true;
            }

            if (secondPart && hashBytes[2] > 0x00)
            {
                return true;
            }

            return false;
        }
    }
}
