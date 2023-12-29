namespace ASPNETCore_Demo_Introduction.Models
{
    public interface ICoolCar
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; } 
    }
}
