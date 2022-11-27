using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogicCUD.Services;

namespace RestaurantAppTests
{
    internal class MenuFormServiceTest
    {
        [Test]
        public void CalculateCost()
        {
            List<Int32> values = new List<Int32> { 1, 2, 3 };

            Int32 result = MenuFormService.calculateCost(values);

            Assert.AreEqual(6, result);
        }
    }
}
