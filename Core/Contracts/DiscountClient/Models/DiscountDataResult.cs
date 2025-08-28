namespace Core.Contracts.DiscountClient.Models
{
    /// <summary>
    /// Represents discount data retrieved from the discount service.
    /// </summary>
    public class DiscountDataResult
    {
        /// <summary>
        /// Gets or sets the discount value expressed as a decimal fraction.
        /// </summary>
        /// <remarks>
        /// For example, a value of <c>0.10m</c> represents a 10% discount, and <c>0.025m</c> represents a 2.5% discount.
        /// </remarks>
        public decimal DiscountValue { get; set; } // e.g. 0.10m means 10%
    }
}
