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

    public static IEnumerable<Location> ValidLocationDDCoordinates() {
        
        yield return new Location { name = "23.4322° S, 46.4686° W", outputName = "Aeroporto, Guarulhos - SP"};
        yield return new Location { name = "29.9744° N, 31.1264° E", outputName = "Al Omraneya, Al Haram, Guizé 3512201, Egito" };
        yield return new Location { name = "25.1969° N, 55.2742° E", outputName = "Burj Khalifa - 1 Sheikh Mohammed bin Rashid Blvd - Downtown Dubai - Dubai - Emirados Árabes Unidos" };
        yield return new Location { name = "48.85833° N, 2.28444° E", outputName = "Rue Raynouard 1-3, 75016 Paris, França" };
    }

    public static IEnumerable<Location> ValidLocationDMSCoordinates() {
        
        yield return new Location { name = "23°25'56\"S 46°28'07\"W", outputName = "Aeroporto, Guarulhos - SP"};
        yield return new Location { name = "29°58'28\"N 31°07'35\"E", outputName = "Al Omraneya, Al Haram, Guizé 3512201, Egito" };
        yield return new Location { name = "25°11'49\"N 55°16'27\"E", outputName = "Burj Khalifa - 1 Sheikh Mohammed bin Rashid Blvd - Downtown Dubai - Dubai - Emirados Árabes Unidos" };
        yield return new Location { name = "48°51'30\"N 2°17'4\"E", outputName = "Rue Raynouard 1-3, 75016 Paris, França" };
    }

    public static IEnumerable<Location> ValidLocationDMMCoordinates() {
        
        yield return new Location { name = "23°25.933'S 46°28.117'W", outputName = "Aeroporto, Guarulhos - SP"};
        yield return new Location { name = "29°58.467'N 31°07.583'E", outputName = "Al Omraneya, Al Haram, Guizé 3512201, Egito" };
        yield return new Location { name = "25°11.817'N 55°16.450'E", outputName = "Burj Khalifa - 1 Sheikh Mohammed bin Rashid Blvd - Downtown Dubai - Dubai - Emirados Árabes Unidos" };
        yield return new Location { name = "48°51.500'N 2°17.067'E", outputName = "Rue Raynouard 1-3, 75016 Paris, França" };
    }
}

public struct Location {

    public string name;
    public string outputName;
}