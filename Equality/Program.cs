using Equality.Domain.Entities;
using Equality.Domain.Enums;
using Equality.Domain.ValueObjects;
using Netizine.Enums;


Console.WriteLine("hc");



Person p1 = new(
    id: Guid.NewGuid(),
    name: "Michael",
    email: "mich.ael@gmail.com",
    nationality: Country.Spain,
    countryOfBirth: Country.Singapore,
    dateOfBirth: new DateOnly(2022, 1, 1),
    primaryAddress: new Address(
        addressLine1: "65",
        addressLine2: "Jalan Bukit Ho Swee",
        addressLine3: "#08-393",
        country: Country.Singapore,
        postalCode: "777065"),
    primaryPhoneNumber: new PhoneNumber(countryPrefix: 65, phoneNo: 98765432),
    maritalStatus: MaritalStatusEnum.Single,
    annualIncome: new Money(90_000M),
    highestQualification: HighestQualificationEnum.Bachelors,
    occupation: "Software Engineer"
    );

Console.WriteLine(p1.ToString());

Person p2 = new(
    id: Guid.NewGuid(),
    name: "Michael",
    email: "mich.ael@gmail.com",
    nationality: Country.Spain,
    countryOfBirth: Country.Singapore,
    dateOfBirth: new DateOnly(2022, 1, 1),
    primaryAddress: new Address(
        addressLine1: "65 Jalan Bukit Ho Swee #08-393",
        country: Country.Singapore,
        postalCode: "777065"),
    primaryPhoneNumber: new PhoneNumber(countryPrefix: 65, phoneNo: 98765432),
    maritalStatus: MaritalStatusEnum.Single,
    annualIncome: new Money(90_000.01M),
    highestQualification: HighestQualificationEnum.Bachelors,
    occupation: "Software Engineer"
    );

Console.WriteLine(p2.ToString());


////Required keyword + Object Initializer -> would require a parameterless constructor
//Person p2 = new
//{
//    Id = Guid.NewGuid(),
//    Name = "Michael",
//    Email = "mich.ael@gmail.com",
//    Nationality = Country.Spain,
//    CountryOfBirth = Country.Singapore,
//    DateOfBirth = new DateOnly(2022, 1, 1),
//    PrimaryAddress = new Address(
//        addressLine1: "65",
//        addressLine2: "Jalan Bukit Ho Swee",
//        addressLine3: "#08-393",
//        country: Country.Singapore,
//        postalCode: "777065"),
//    PrimaryPhoneNumber = new PhoneNumber(countryPrefix: 65, phoneNo: 98765432),
//    MaritalStatus = MaritalStatus.Single,
//    AnnualIncome = new Money(90_000M),
//    HighestQualification = HighestQualification.Bachelors,
//    Occupation = "Software Engineer"
//};
