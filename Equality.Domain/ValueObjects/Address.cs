using Equality.Domain.Primitives;

namespace Equality.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public Enum Country { get; set; }

        public Address(string addressLine1, 
            string postalCode,
            Enum country,
            string? addressLine2 = null,
            string? addressLine3 = null)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2 ?? String.Empty;
            AddressLine3 = addressLine3 ?? String.Empty;
            PostalCode = postalCode;
            Country = country;
        }

        //public override string ToString()
        //    => "\n        Address - \n"
        //        + $"        AddressLine1: {AddressLine1}"
        //        + ((String.IsNullOrEmpty(AddressLine2)) ? null : $"\n        AddressLine2: {AddressLine2}")
        //        + ((String.IsNullOrEmpty(AddressLine3)) ? null : $"\n        AddressLine3: {AddressLine3}")
        //        + $"\n        PostalCode: {PostalCode}"
        //        + $"\n        Country: {Country}";
    }
}
