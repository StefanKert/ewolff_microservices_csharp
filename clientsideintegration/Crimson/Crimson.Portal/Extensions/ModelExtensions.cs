using Crimson.Portal.Contracts.Backend;
using Crimson.Portal.Models;
using System;
using System.Linq;
using Partner = Crimson.Portal.Models.Partner;

namespace Crimson.Portal.Extensions
{
    public static class ModelExtensions
    {
        public static Offer ToOffer(this Angebot x)
        {
            return new Offer
            {
                Id = x.AngebotId,
                Agency = x.Agentur,
                Branch = x.Sparte,
                Claims = x.Schaeden,
                Expire = x.Ablauf,
                Fee = x.BeitragZent,
                FormattedFee = x.BeitragZent.ToString("C"),
                Icon = Branch.Branches.FirstOrDefault(b => b.Label == x.Sparte)?.Icon,
                Incident = x.Versichertist,
                PaymentInterval = x.Zahlungsweise,
                Role = x.Rolle,
                OfferUri = $"/partners/{x.PartnerId}/offers/{x.AngebotId}",
                OfferCopyUri = $"/partners/{x.PartnerId}/offers/{x.AngebotId}/copy",
                OfferEditUri = $"/partners/{x.PartnerId}/offers/{x.AngebotId}/edit",
                VehicleData = new VehicleData
                {
                    VehicleType = x.Fahrzeugdaten.Fahrzeugart,
                    LicensePlate = x.Fahrzeugdaten.Kennzeichen,
                    ManufacturerNo = x.Fahrzeugdaten.Hsn,
                    TypeKey = x.Fahrzeugdaten.Typschl,
                    RegistrationDate = x.Fahrzeugdaten.Erstzulassung,
                    IdentificationNumber = x.Fahrzeugdaten.Fahrgestell,
                    Horsepower = x.Fahrzeugdaten.FahrzeugstaerkePS,
                    ChangeableEngine = x.Fahrzeugdaten.Austauschmotor ? "Ja" : "Nein",
                    LicensePlateType = x.Fahrzeugdaten.Kennzeichenart,
                    ChangeableLicensePlate = x.Fahrzeugdaten.Wechselkennzeichen ? "Ja" : "Nein"
                },
                Usage = {
                    AnyDriver= x.Nutzung.BeliebigeFahrer,
                    NightlyPound= x.Nutzung.NachtAbstellplatz,
                    DrivingPerformance= x.Nutzung.FahrleistungKm,
                    Mileage= x.Nutzung.Kilometerstand,
                    DifferentVehicleOwner= x.Nutzung.AbweichenderFahrzeughalter ? "Ja" : "Nein",
                    usage= x.Nutzung.AreaOfUsage,
                    OwnerOccupiedHome= x.Nutzung.SelbstGenEigentum ? "Ja" : "Nein",
                    HomeOwnershipType= x.Nutzung.Wohneigentumart
                },
                InsuranceCover = {
                    LiabilityDiscount= x.VersSchutz.HaftpflichSFR,
                    ComprehensiveCoverDiscount= x.VersSchutz.VolkaskoSFR,
                    WageGroup= x.VersSchutz.Tarifgruppe,
                    BasicAgreement= x.VersSchutz.Rahmenvertrag,
                    Start= x.VersSchutz.VersBeginn,
                    PaymentMethod= x.VersSchutz.Zahlungsweise
                }
            };
        }


        public static SimplifiedPartner ToSimplifiedPartner(this Crimson.Portal.Contracts.Backend.Partner partner)
        {
            return new SimplifiedPartner
            {
                Address = $"{partner.Anschrift.Strasse}, {partner.Anschrift.Plz} {partner.Anschrift.Ort} {partner.Anschrift.Stadtteil}",
                Age = DateTime.Today.Year - partner.Geburtsdatum.Year,
                DateOfBirth = partner.Geburtsdatum,
                Honorific = partner.Anrede,
                Firstname = partner.Vorname,
                Name = partner.Name,
                Url = $"/partners/{partner.PartnerId}"
            };
        }

        public static Partner ToPartner(this Crimson.Portal.Contracts.Backend.Partner partner)
        {
            return new Partner
            {
                Address = new Address
                {
                    Street = partner.Anschrift.Strasse,
                    PostCode = partner.Anschrift.Plz,
                    City = partner.Anschrift.Ort,
                    District = partner.Anschrift.Stadtteil
                },
                Age = DateTime.Today.Year - partner.Geburtsdatum.Year, //TODO this is pretty unsafe
                ChildrenCount = partner.AnzahlKinder,
                DateOfBirth = partner.Geburtsdatum,
                Firstname = partner.Vorname,
                Honorific = partner.Anrede,
                Job = partner.Beruf,
                Name = partner.Name,
                Phone = partner.Telnummer,
                Nationality = partner.Staatsang,
                PersonalStatus = partner.Familienstand,
                Links = new Links
                {
                    Self = $"/partners/{partner.PartnerId}",
                    Offers = $"/partners/{partner.PartnerId}/offers",
                    Proposals = $"/partners/{partner.PartnerId}/proposals",
                    Contracts = $"/partners/{partner.PartnerId}/contracts",
                }
            };
        }

        public static Contact ToContact(this Kontakthistorie kontakt)
        {
            return new Contact
            {
                Advisor = kontakt.Sachbearbeiter,
                Date = DateTime.Parse(kontakt.Zeit),
                FormattedDate = DateTime.Parse(kontakt.Zeit).ToString("LLLL"),
                Icon = Contact.ContactTypes[kontakt.Kontaktart],
                Title = kontakt.Titel,
                Type = kontakt.Kontaktart
            };
        }
    }
}
