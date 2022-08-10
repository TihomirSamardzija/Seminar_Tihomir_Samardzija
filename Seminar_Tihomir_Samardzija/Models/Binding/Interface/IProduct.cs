namespace Seminar_Tihomir_Samardzija.Models.Binding.Interface
{
    public interface IProduct
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
