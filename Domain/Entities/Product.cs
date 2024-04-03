using System.ComponentModel.DataAnnotations;

namespace OmicronCase.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public  string Title { get; set; }
        public string Description { get; set; }
        public  Category Category { get; set; }
        public int StockQuantity { get; set; }
        public int LimitStock { get; set; }
        public bool IsActive { get; set; }
        public void SetIsActive()
        {
            IsActive = Category !=null;
            IsActive = StockQuantity >= LimitStock;
        }
    }
}
