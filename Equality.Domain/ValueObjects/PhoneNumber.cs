using Equality.Domain.Primitives;

namespace Equality.Domain.ValueObjects
{
    public class PhoneNumber(int countryPrefix, 
        long phoneNo, 
        int? regionPrefix = null) 
        : ValueObject<PhoneNumber>
    {
        public int CountryPrefix { get; set; } = countryPrefix;
        public int? RegionPrefix { get; set; } = regionPrefix;
        public long PhoneNo { get; set; } = phoneNo;

        public override string ToString()
            => '+' + CountryPrefix.ToString()
                + ( (RegionPrefix is null) 
                    ? null 
                    : ('-' + RegionPrefix.ToString()) )
                + '-' + PhoneNo.ToString();
    }
}
