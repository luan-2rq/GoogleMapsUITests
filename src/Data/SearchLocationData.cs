namespace GoogleMapsUITests.Data;

public static class SearchLocationData {

    public static IEnumerable<Location> ValidCountryLocationNames() {

        yield return new Location { name = "Democratic Republic of the Congo", expectedResult = "République démocratique du Congo"};
        yield return new Location { name = "Côte d'Ivoire", expectedResult = "Côte d'Ivoire" };
        yield return new Location { name = "Fiji", expectedResult = "Fiji" };
        yield return new Location { name = "Kazakhstan", expectedResult = "Қазақстан" };
    }

    public static IEnumerable<Location> ValidStateLocationNames() {

        yield return new Location { name = "New South Wales", expectedResult = "New South Wales"};
        yield return new Location { name = "Queensland", expectedResult = "Queensland" };
        yield return new Location { name = "Goa", expectedResult = "Goa" };
        yield return new Location { name = "West Virginia", expectedResult = "West Virginia" };
    }

    public static IEnumerable<Location> ValidCityLocationNames() {

        yield return new Location { name = "Cape Town, South Africa", expectedResult = "Cape Town"};
        yield return new Location { name = "Marrakech, Morocco", expectedResult = "مراكش" };
        yield return new Location { name = "Kyoto, Japan", expectedResult = "京都市" };
        yield return new Location { name = "Buenos Aires, Argentina", expectedResult = "Buenos Aires" };
    }

    public static IEnumerable<Location> ValidStreetLocationNames() {

        yield return new Location { name = "Abbey Road - London, United Kingdom", expectedResult = "Abbey Rd."};
        yield return new Location { name = "Rodeo Drive - Beverly Hills, California, USA", expectedResult = "Rodeo Dr" };
        yield return new Location { name = "Paseo de la Reforma - Cidade do México, México", expectedResult = "Av. P.º de la Reforma" };
        yield return new Location { name = "Lombard Street - San Francisco, California, USA", expectedResult = "Lombard St" };
    }

    public static IEnumerable<Location> InvalidLocationNames() {
        
        yield return new Location { name = "*", expectedResult = ""};
        yield return new Location { name = "()", expectedResult = "" };
        yield return new Location { name = "{}", expectedResult = "" };
        yield return new Location { name = "/", expectedResult = "" };
    }

    public static IEnumerable<Location> ValidLocationDDCoordinates() {
        
        yield return new Location { name = "23.4322° S, 46.4686° W", expectedResult = "Aeroporto, Guarulhos"};
        yield return new Location { name = "29.9744° N, 31.1264° E", expectedResult = "Al Omraneya, Al Haram" };
        yield return new Location { name = "25.1969° N, 55.2742° E", expectedResult = "Burj Khalifa - 1 Sheikh Mohammed bin Rashid Blvd" };
        yield return new Location { name = "48.85833° N, 2.28444° E", expectedResult = "Rue Raynouard 1-3" };
    }

    public static IEnumerable<Location> ValidLocationDMSCoordinates() {
        
        yield return new Location { name = "23°25'56\"S 46°28'07\"W", expectedResult = "Aeroporto, Guarulhos"};
        yield return new Location { name = "29°58'28\"N 31°07'35\"E", expectedResult = "Al Omraneya, Al Haram" };
        yield return new Location { name = "25°11'49\"N 55°16'27\"E", expectedResult = "Burj Khalifa - 1 Sheikh Mohammed bin Rashid Blvd" };
        yield return new Location { name = "48°51'30\"N 2°17'4\"E", expectedResult = "Rue Raynouard 1-3" };
    }

    public static IEnumerable<Location> ValidLocationDMMCoordinates() {
        
        yield return new Location { name = "23°25.933'S 46°28.117'W", expectedResult = "Aeroporto, Guarulhos"};
        yield return new Location { name = "29°58.467'N 31°07.583'E", expectedResult = "Al Omraneya, Al Haram" };
        yield return new Location { name = "25°11.817'N 55°16.450'E", expectedResult = "Burj Khalifa - 1 Sheikh Mohammed bin Rashid Blvd" };
        yield return new Location { name = "48°51.500'N 2°17.067'E", expectedResult = "Rue Raynouard 1-3" };
    }

    public static IEnumerable<Location> InvalidLocationCoordinates() {
        
        yield return new Location { name = "24°25'56\"S 181°28'07\"W", expectedResult = ""};
        yield return new Location { name = "91°25'56\"S 41°28'07\"W", expectedResult = "" };
        yield return new Location { name = "121°25'56\"S 17°28'07\"W", expectedResult = "" };
        yield return new Location { name = "87°25'56\"S 190°28'07\"W", expectedResult = "" };
    }
}

public struct Location {

    public string name;
    public string expectedResult;
}