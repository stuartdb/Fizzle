using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzle.Models
{
    public class Number
    {
        private readonly Dictionary<int, string> TransformMap = new Dictionary<int, string> {
            { 3, "Fizz" },
            { 5, "Buzz" }
        };

        public int Id { get; set; }
        public int Initial { get; set; } = 1;
        public string Transform { get; private set; }

        /// <summary>
        /// Fizzle
        /// Checks the Initial value of this Number and populates the Transform property if appropriate
        /// Transform will be untouched if Fizzle has nothing to do        
        /// </summary>
        public void Fizzle()
        {
            foreach (var transform in TransformMap)
            {
                if (InitialIsDivisableBy(transform.Key))
                {
                    Transform += transform.Value;
                }
            }
        }

        private bool InitialIsDivisableBy(int divisable)
        {
            if (Initial == 0) return false;
            return Initial % divisable == 0;
        }

    }
}
