using System.ComponentModel.DataAnnotations;

namespace cptc_price_quotation_app.Models
{
    public class PriceQuoteModel
    {
        // track Subtotal, Discount percent, Discount amount, and Total
        [Required(ErrorMessage = "Subtotal is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Subtotal must be greater than 0")]
        [DataType(DataType.Currency)]
        [Display(Name = "Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Subtotal { get; set; }



        [Required(ErrorMessage = "Discount percent is required")]
        [Display(Name = "Discount Percent:")]
        [DisplayFormat(DataFormatString = "0:F2")]

        [Range(0, 100, ErrorMessage = "Discount must be between 0.00% to 100.00%")]

        public double DiscountPercent { get; set; }
        
        
        [DataType(DataType.Currency)]
        [Display(Name = "Discount Amount:")]

        public double DiscountAmount { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total:")]
        public double Total { get; set; }
        public PriceQuoteModel()
        {
            Subtotal = 0;
            DiscountPercent = 0;
            DiscountAmount = 0;
            Total = 0;
        }
    }
}
