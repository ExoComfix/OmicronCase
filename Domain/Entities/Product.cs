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
        [Range(1, int.MaxValue, ErrorMessage = "LimitStock must be greater than 0.")]
        public int LimitStock { get; set; }
        public bool IsActive { get; set; }
        public void SetIsActive()
        {
            IsActive = Category != null && StockQuantity > LimitStock;
        }
    }
}
