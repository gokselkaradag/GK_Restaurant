namespace SingalRApi.Model
{
    public class ResultBasketListWithProducts
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
    }
}
