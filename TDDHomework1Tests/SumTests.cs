using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDHomework1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHomework1.Models;
namespace TDDHomework1.Tests
{
    [TestClass()]
    public class SumTests
    {
        [TestMethod()]
        public void FieldSumInGroupByRowCountTest_3筆一組取Cost總和()
        {
            //arrange
            var target = new Sum();
            var groupFirst = new List<Order>()
            {
                new Order() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 },
                new Order() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 },
                new Order() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 }
            };
            var groupSecond = new List<Order>()
            {
                new Order() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 },
                new Order() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 },
                new Order() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 }
            };
            var groupThird = new List<Order>()
            {
                new Order() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 },
                new Order() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 },
                new Order() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 }
            };
            var groupFourth = new List<Order>()
            {
                new Order() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 },
                new Order() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 }
            };
            
            var expected = new int[] { 
                groupFirst.Select(o=>o.Cost).Sum(),
                groupSecond.Select(o=>o.Cost).Sum(),
                groupThird.Select(o=>o.Cost).Sum(),
                groupFourth.Select(o=>o.Cost).Sum()
            };

            //act
            var actual = target.FieldSumInGroupByRowCount<Order>(3, "Cost", groupFirst.Concat(groupSecond).Concat(groupThird).Concat(groupFourth));

            //assert            
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FieldSumInGroupByRowCountTest_4筆一組取Revenue總和()
        {
            //arrange
            var target = new Sum();
            var groupFirst = new List<Order>()
            {
                new Order() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 },
                new Order() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 },
                new Order() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 },
                new Order() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 }
            };
            var groupSecond = new List<Order>()
            {                
                new Order() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 },
                new Order() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 },
                new Order() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 },
                new Order() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 }
            };
            var groupThird = new List<Order>()
            {               
                new Order() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 },
                new Order() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 },
                new Order() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 }
            };
            
            var expected = new int[] { 
                groupFirst.Select(o=>o.Revenue).Sum(),
                groupSecond.Select(o=>o.Revenue).Sum(),
                groupThird.Select(o=>o.Revenue).Sum()
            };

            //act
            var actual = target.FieldSumInGroupByRowCount<Order>(4, "Revenue", groupFirst.Concat(groupSecond).Concat(groupThird));

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
