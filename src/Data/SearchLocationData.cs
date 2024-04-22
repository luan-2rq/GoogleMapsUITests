using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace GoogleMapsUITests.Data;

public static class SearchLocationData {

    public static IEnumerable<Location> ValidCountryLocationNames() {

        yield return new Location { name = "Democratic Republic of the Congo", outputName = "République démocratique du Congo"};
        yield return new Location { name = "Côte d'Ivoire", outputName = "Côte d'Ivoire" };
        yield return new Location { name = "Fiji", outputName = "Fiji" };
        yield return new Location { name = "Kazakhstan", outputName = "Қазақстан" };
    }

    public static IEnumerable<Location> ValidStateLocationNames() {

        yield return new Location { name = "New South Wales", outputName = "New South Wales"};
        yield return new Location { name = "Hövsgöl", outputName = "Хөвсгөл" };
        yield return new Location { name = "Goa", outputName = "Goa" };
        yield return new Location { name = "West Virginia", outputName = "West Virginia" };
    }

    public static IEnumerable<Location> ValidCityLocationNames() {

        yield return new Location { name = "Cape Town, South Africa", outputName = "Cape Town"};
        yield return new Location { name = "Marrakech, Morocco", outputName = "مراكش" };
        yield return new Location { name = "Kyoto, Japan", outputName = "京都市" };
        yield return new Location { name = "Buenos Aires, Argentina", outputName = "Cidade Autônoma de Buenos Aires" };
    }

    public static IEnumerable<Location> ValidStreetLocationNames() {

        yield return new Location { name = "Abbey Road - London, United Kingdom", outputName = "Abbey Rd."};
        yield return new Location { name = "Rodeo Drive - Beverly Hills, California, USA", outputName = "Rodeo Dr" };
        yield return new Location { name = "Champs-Élysées - Paris, France", outputName = "Av. des Champs-Élysées" };
        yield return new Location { name = "Lombard Street - San Francisco, California, USA", outputName = "Lombard St" };
    }

    public static IEnumerable<Location> InvalidLocationNames() {
        
        yield return new Location { name = "*", outputName = ""};
        yield return new Location { name = "()", outputName = "" };
        yield return new Location { name = "{}", outputName = "" };
        yield return new Location { name = "/", outputName = "" };
    }
}

public struct Location {

    public string name;
    public string outputName;
}