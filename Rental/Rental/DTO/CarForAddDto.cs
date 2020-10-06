namespace Rental.DTO
{

    public class CarForAddDto
    {
        public string Company { get; set; }
        public string Model { get; set; }
        public int Distance { get; set; }
        public int Seats { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public bool Available { get; set; }

        public int price { get; set; }

    }
}
