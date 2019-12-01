using System.Collections.Generic;
using System.Linq;

namespace DonutDelight
{
    public class OrderSizes
    {
        public static readonly List<int> BoxSizeList = new List<int>() {20, 9, 6, 4};

        public class Order
        {
            public int Size { get; }

            public Order(int size) => this.Size = size;

            public List<int> Boxes { get; set; }
        }

        /// <summary>
        /// Function to return a memo list that contains solution for all order size from 1 to orderSize
        /// </summary>
        /// <remarks>
        /// Store the computed result for reuse
        /// For example if we already computed the result for order size 80 and stored it in memo[80]
        /// when we compute result for order size 100, assuming we first pick box size 20 for the solution
        /// we then need to pick boxes to make up for 100-20 = 80, memo[100] = 20 + memo[80](already computed)
        /// </remarks>
        public static List<Order> GetMemoForderSize(int orderSize)
        {
            List<Order> memo = new List<Order>();

            // Pre populate memo
            for (var i = 0; i <= orderSize; i++) memo.Add(new Order(i));
            memo[0].Boxes = new List<int>() {0};

            // Build the solution memo from bottom up
            for (var i = 1; i <= orderSize; i++)
            {
                var cOrderSize = i;
                foreach (var cBoxSize in BoxSizeList)
                {
                    if (cBoxSize > cOrderSize) continue;

                    // If solution should include cBoxSize, check the solution for the remaining order sizes form the memo
                    var remain = memo[cOrderSize - cBoxSize];
                    if (remain.Boxes == null) continue;
                    memo[cOrderSize].Boxes = new List<int>(remain.Boxes) {cBoxSize};
                    break;
                }
            }

            memo[0].Boxes = null;

            return memo;
        }

        // Return null if invalid
        public static List<int> GetOrderForSize(int orderSize)
        {
            var memo = GetMemoForderSize(orderSize);

            var result = memo[orderSize].Boxes;

            return result?.FindAll(x => x!=0);
        }

        public static List<int> GetInvalidOrders(int n)
        {
            return GetMemoForderSize(n).FindAll(o => o.Boxes == null).Select(x => x.Size).ToList();
        }
    }
}
