using System;
// ok
namespace ShippingCalculator
{
    public class ShippingCalculator
    {
        /// <summary>
        /// This function evaluates the order price passed as an input parameter and returns the shipping price following the exercise's logic
        /// </summary>
        /// <param name="orderPrice"> A value of type double, the order price </param>
        /// <returns>The shipping price value (integer type), following the exercise logic </returns>
        /// <exception cref="ArgumentException">If the order price be equal to or less than zero</exception>
        public int CalculateShipping(double orderPrice) 
        {
            if (orderPrice <= 0.0)
            {
                throw new ArgumentException("The order price cannot be equal to or less than zero");
            } else if (orderPrice <= 50.0)
            {
                return 25;
            } else if (orderPrice <= 100.0)
            {
                return 20;
            } else if (orderPrice < 200.0)
            {
                return 15;
            } else
            {
                return 0;
            }
        }
    }
}
