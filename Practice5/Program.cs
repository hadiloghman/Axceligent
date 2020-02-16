using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
        }

        public async static void test()
        {
            var (averageSalary, numberOfEmployee) = await SomeCalculation(0L, 10, 0L == 10L);
        }
        public static async Task<(float avg, int employeeNum)> SomeCalculation(long l, int i, bool equal)
        {
            return (0f, 10);
        }
    }
}
