using System.Reflection.Metadata.Ecma335;

namespace GoogleMapsUITests.Data;

public static class SearchLocationData {

    public static Location[] validLocations = new Location[] {
        
        new Location { name = "Germany", outputName = "Deutschland"},
        new Location { name = "Nova Yorque", outputName = "New York" },
        new Location { name = "Londres", outputName = "London" },
        new Location { name = "França", outputName = "France" }
    };
}

public struct Location {

    public string name;
    public string outputName;
}