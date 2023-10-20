namespace Medilo.API.Models.DTO
{
    public class AddressDto
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public int HouseNumber { get; set; }

        public int? ApartmentNumber { get; set; }
    }
}
