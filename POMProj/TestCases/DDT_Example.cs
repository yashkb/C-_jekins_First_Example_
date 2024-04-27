using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POMProj.TestCases
{
    internal class DDT_Example
    {
        [TestCaseSource(nameof(data))]
        public void TC_001_A(string name)
        {
            string expected = "Yash";
            Assert.That(expected, Does.Contain(name));
        }

        public static IEnumerable<string> data()
        {
            yield return "Yash";
            yield return "Alex";
        }
    }
}
