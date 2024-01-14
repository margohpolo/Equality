using Equality.Domain.Entities;
using Equality.Domain.Enums;
using Equality.Domain.ValueObjects;
using Netizine.Enums;

namespace Equality.Tests.EntityTests
{
    public class PersonTests
    {
        private static readonly Person _p1 = new(
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

        private static readonly Person _p1_ref = _p1;

        private static readonly Person _p2 = new(
            id: _p1.Id,
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

        private static readonly PhoneNumber secPhoneNo = new(
            countryPrefix: 65,
            phoneNo: 88888888);

        private static readonly Person _p3 = new(
            id: _p1.Id,
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
            secondaryPhoneNumber: secPhoneNo,
            maritalStatus: MaritalStatusEnum.Single,
            annualIncome: new Money(90_000M),
            highestQualification: HighestQualificationEnum.Bachelors,
            occupation: "Software Engineer"
            );


        [Fact]
        public void EqualityCheck_Should_Return_True_IfEqual()
        {
            Assert.StrictEqual(_p1, _p2);
        }


        [Fact]
        public void EqualityCheck_Should_Return_True_IfRef()
        {
            Assert.StrictEqual(_p1, _p1_ref);
        }

        [Fact]
        public void EqualityCheck_Should_Return_False_IfNotEqual()
        {
            Assert.True(!_p1.Equals(_p3));
            Assert.False(_p1.Equals(_p3));
            Assert.True(_p1 != _p3);
            Assert.False(_p1 == _p3);
        }
    }
}
