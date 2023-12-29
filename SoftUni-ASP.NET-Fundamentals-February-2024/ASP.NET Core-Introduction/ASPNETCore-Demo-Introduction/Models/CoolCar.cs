namespace ASPNETCore_Demo_Introduction.Models
{
    public class CoolCar : ICoolCar
    {
        public int Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
