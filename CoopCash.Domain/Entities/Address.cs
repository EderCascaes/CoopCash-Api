
namespace CoopCash.Domain.Entities
{
    public class Address : EntityBase
    {
        public string Street { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string? Complement { get; set; }
        public string Neighborhood { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
        public string Country { get; set; } = "Brasil";

        // 🔗 Relacionamento
        public Guid AssociateId { get; set; }
        public Associate Associate { get; set; } = default!;

        // ✅ Construtor sem parâmetros (necessário pro EF)
        protected Address() { }

        // Construtor customizado para uso no domínio
        public Address(string street, string number, string? complement,
                       string neighborhood, string city, string state, string zipCode, Guid associateId)
        {
            Id = Guid.NewGuid();
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            AssociateId = associateId;
        }

    }
}
