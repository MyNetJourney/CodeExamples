using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication29
{
    class Program
    {
        static void Main(string[] args)
        {
            CostAggregator aggregator = new CostAggregator();

            List<MySampleCost> myPartialCostList = new List<MySampleCost>()
            {
                new MySampleCost() {Cost = 10 },
                new MySampleCost() {Cost = 20},
                new MySampleCost() {Cost = 30}
            };

            var totalCost = myPartialCostList.Aggregate(aggregator, (aggr, cost) => aggr.Add(cost));
        }
    }

    public class MySampleCost
    {
        public double Cost;
    }


    public class CostAggregator
    {
        public double TotalCost;

        public CostAggregator Add(MySampleCost cost)
        {
            TotalCost = TotalCost += cost.Cost;
            return this;
        }


    }
}
