using Eventify.Platform.API.Profiles.Domain.Model.Commands;
using Eventify.Platform.API.Profiles.Domain.Model.ValueObjects;

namespace Eventify.Platform.API.Profiles.Domain.Model.Aggregates;

public class Profile
{
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public StreetAddress Address { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public WebSiteAddress WebSite { get; private set; }
    public Biography Biography { get; private set; }
    public TypeProfile Role { get; private set; }

    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string StreetAddress => Address.FullAddress;
    public string PhoneNumberValue => PhoneNumber.Number;
    public string WebSiteUrl => WebSite.Url;
    public string BiographyText => Biography.Text;
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
        PhoneNumber = new PhoneNumber();
        WebSite = new WebSiteAddress();
        Biography = new Biography();
        Role = TypeProfile.Organizer;
    }

    public Profile(string firstName, string lastName, string email, string street, string number, string city,
        string postalCode, string country, string phoneNumber, string webSite, string biography, TypeProfile role)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, number, city, postalCode, country);
        PhoneNumber = new PhoneNumber(phoneNumber);
        WebSite = new WebSiteAddress(webSite);
        Biography = new Biography(biography);
        Role = role;
    }

    public Profile(CreateProfileCommand command) : this(command.FirstName, command.LastName, command.Email,
        command.Street, command.Number, command.City, command.PostalCode, command.Country,
        command.PhoneNumber, command.WebSite, command.Biography, command.Role)
    {
    }
}