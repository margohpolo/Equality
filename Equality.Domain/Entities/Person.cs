using Equality.Domain.Constants;
using Equality.Domain.Primitives;
using Equality.Domain.ValueObjects;

namespace Equality.Domain.Entities
{
    public sealed class Person(
        Guid id,
        string name,
        string email,
        Enum nationality,
        Enum countryOfBirth,
        DateOnly dateOfBirth,
        Address primaryAddress,
        PhoneNumber primaryPhoneNumber,
        Enum maritalStatus,
        Money annualIncome,
        Enum highestQualification,
        string occupation,
        Money? creditLimit = null,
        Address? secondaryAddress = null,
        PhoneNumber? secondaryPhoneNumber = null) : Entity<Person>(id)
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public Enum Nationality { get; private set; } = nationality;
        public Enum CountryOfBirth { get; private init; } = countryOfBirth;
        public DateOnly DateOfBirth { get; private init; } = dateOfBirth;
        public Address PrimaryAddress { get; private set; } = primaryAddress;
        public Address? SecondaryAddress { get; private set; } = secondaryAddress;
        public PhoneNumber PrimaryPhoneNumber { get; private set; } = primaryPhoneNumber;
        public PhoneNumber? SecondaryPhoneNumber { get; private set; } = secondaryPhoneNumber;
        public Enum MaritalStatus { get; private set; } = maritalStatus;
        public Money AnnualIncome { get; private set; } = annualIncome;
        public Enum HighestQualification { get; private set; } = highestQualification;
        public string Occupation { get; private set; } = occupation;
        public Money CreditLimit { get; private set; } = creditLimit ?? (annualIncome * CalculationConstants.CreditLimitMultiple);

        //***Note: For demo purposes only. Not a good idea to expose too much PII in logs.
        public override string ToString()
            => $"Person -"
                + $"\n Id: {Id}"
                + $"\n | Name: {Name}"
                + $"\n | Email: {Email}"
                + $"\n | Nationality: {Nationality}"
                + $"\n | CountryOfBirth: {CountryOfBirth}"
                + $"\n | DateOfBirth: {DateOfBirth}"
                + $"\n | PrimaryAddress: {PrimaryAddress}"
                + ( (SecondaryAddress is null) 
                    ? null 
                    : $"\n | SecondaryAddress: {SecondaryAddress}" )
                + $"\n | MaritalStatus: {MaritalStatus}"
                + $"\n | AnnualIncome: {AnnualIncome}"
                + $"\n | HighestQualification: {HighestQualification}"
                + $"\n | CreditLimit: {CreditLimit}"
                + $"\n | PrimaryPhoneNumber: {PrimaryPhoneNumber}"
                + ( (SecondaryPhoneNumber is null) 
                    ? null 
                    : $"\n | SecondaryPhoneNumber: {SecondaryPhoneNumber}" )
                + "\n -------------------------------------------------------- \n";
    }
}
