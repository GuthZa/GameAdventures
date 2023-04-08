using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Engine
{
    public static class RandomNumberGenerator
    {
        /*
        //Complex version to randomize a number
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];
            _generator.GetBytes(randomNumber);
            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
            //Using Math.max and subtraction 0.00000000001
            //this ensure the number is between 0.0 and 0.999999999
            //Otherwise it's possible the number to be "1", which causes problems in our rounding
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            //We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;
            double randomValueInRange = Math.Floor(multiplier * range);
            return (int)(minimumValue + randomValueInRange);
        }
        */

        //Simple version to randomize a number
        private static readonly Random _random = new Random();
        public static int SimpleNumberBetween(int minimumValue, int maximumValue)
        {
            return _random.Next(minimumValue, maximumValue + 1);
        }
    }
}
