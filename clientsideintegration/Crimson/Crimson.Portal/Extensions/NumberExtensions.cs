using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crimson.Portal.Extensions
{
    public static class NumberExtensions
    {

        public static string ToEuros(this int number)
        {
            var euros = Math.Floor((decimal)number / 100);
            var cents = number % 100;
            return $"{euros},{cents:00} €";
        }
    }
}
