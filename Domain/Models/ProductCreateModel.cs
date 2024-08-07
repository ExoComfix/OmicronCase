using OmicronCase.Domain.Entities;

namespace OmicronCase.Domain.Models
{
    public class ProductCreateModel
    {
        
        public  string Title { get; set; }
        public string Description { get; set; }
        public  required Category Category { get; set; }
        public int StockQuantity { get; set; }
        public int LimitStock { get; set; }
    }
}
