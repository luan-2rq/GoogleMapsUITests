# Google Maps End-to-End Testing with Playwright (NUnit)

This is an E2E testing automation project for Google Maps using the Playwright framework with NUnit. It focuses on testing location search functionalities.

## Technology stack

- UI Testing Technology: Playwright
- Language: C# 
- Test run framework: NUnit 

## Getting Started

### Running Tests

To start running tests locally, follow these steps:

- Make sure to install [.NET 7.0.x](https://dotnet.microsoft.com/download/dotnet/7.0)

- Build project: In the project folder, execute 'dotnet build'
    > **Note:** In this step the bin and obj folders are created.

- Install required browsers: In the project folder, execute 'pwsh bin/Debug/net7.0/playwright.ps1 install'. If [pwsh(PowerShell)](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.4) is not available for your system, you need to install it before installing required browsers.

- Run tests: In the project folder, execute 'dotnet test -s .runsettings' 

<img src="https://github.com/luan-2rq/GoogleMapsUITests/blob/main/images/test_execution.png" width="720" height="470" />

### Test Execution Deliverables [Screenshots]:

The project is organized in a way, that upon test execution every test case generates a screenshot of the test ending. After executing a test suite, the screenshots are saved at 'bin/Debug/net7.0/screenshots/' in a 'Pass' or 'Failure' directory depending on the test result. In the future these screenshots can be configured as artifacts of CI execution.

<img src="https://github.com/luan-2rq/GoogleMapsUITests/blob/main/images/screenshots_folders.png" width="720" height="268" />

> **Note:** You can configure whether screenshots are saved for every test completion or only for failed tests. In the .runsettings file, setting the parameter TakeScreenshotOnTestCompletion to true will generate screenshots for every test case execution, regardless of whether it passed or failed. On the flip side, setting it to false will only capture screenshots for tests that have failed.

## Test Strategy

The test strategy encompasses both functional and compatibility testing. Given the absence of localization files, the tests are designed to be as localization independent as possible. Text-based locators are avoided except for specific cases where the texts are not localized, such as with addresses, where native names are displayed (e.g., country, state, city, and streets).


> **Note:** If the localization files of Google Maps were available, the best approach would be to use text-based locators. 

**Test case documentation**: [link](https://docs.google.com/document/d/1t1CtgRDmnUr6_8r55NW1B9aLyHEeFxFhCeBMC7Qpnbg/edit?usp=sharing).

### Functional Testing

<img src="https://github.com/luan-2rq/GoogleMapsUITests/blob/main/images/test_desktop.gif" width="720" height="400" />

The tests cover the search of over four distinct addresses. Moreover, they incorporate diverse scenarios, such as searching for locations by name or coordinates, as well as handling invalid inputs. The functional testing comprises the following test cases:

- **Search Location by Name:**
    - Search location by country name
    - Search location by state name
    - Search location by city name
    - Search location by street address name
    - Search location with invalid location name
- **Search Location by Coordinates:**
    - Search location by coordinates in DD format
    - Search location by coordinates in DMS format
    - Search location by coordinates in DMM format
    - Search location by invalid coordinates
- **Search Location without Internet**

These test cases are executed utilizing the NUnit `TestCaseSource` attribute, which facilitates the management and execution of a diverse range of test cases using data, enhancing the testing maintainability.

### Compatibility Testing

<img src="https://github.com/luan-2rq/GoogleMapsUITests/blob/main/images/test_mobile.gif" width="400" height="720" />

Additionally, compatibility tests are conducted across various browsers and mobile devices to guarantee compatibility across different platforms. These tests utilize the same suite of test cases already defined for functional testing. To ensure efficient testing execution, only the "Search Location by Name" test cases have been configured to run in every test cycle, as this functionality serves as the primary feature for most users.

- **Desktop Browsers:** Chrome, Firefox, Safari
- **Mobile:** Pixel 7(Chrome), Iphone 12(Safari)

Compatibility tests are run using the NUnit `TestFixtureSource` attribute, which makes it possible to run compatibility tests for already defined test cases more easily.

> **Note:** Adding new devices or browsers for compatibility testing is straightforward. Simply update the test data in the `DeviceData.cs` file to include the new devices or browsers. The test framework is designed to dynamically adapt to the provided test data, making it easy to expand the testing scope without requiring significant changes to the existing codebase.

## Code Documentation

The project is organized in folders as follows:

- **Data:** Contains data classes for test data.
    - **LocationData Class:** Provides methods for returning data for testing location searching. 
    - **DeviceData Class:** Provides methods for returning supported devices for running compatibility tests.
- **Enums:** Enums used in the project.
    - **Browser.cs:** Contains enum with the supported browsers.
- **TestBases:** Base classes for testing. Those classes are inherited by test classes to add aditional test functinality.
    - **CompatibilityTest Class:** This class extends the PlaywrightTest class and serves as a base for running compatibility tests on various devices. It accepts a device in the constructor to configure the browser accordingly. 
    - **BaseTest Class:** It is the base class which most test should be derived from. At the TearDown method it is responsible for capturing a screenshot on test failure. More functionallities could be added to this class in the future.
- **Helpers:** Utility classes.
    - **ScreenshotHelper Class:** Provides utility methods for capturing screenshots during test execution. Organizes screenshots in directories based on the test execution date and time, test fixture, and scenarios.
- **Pages:** Page object classes following the Page Object Model (POM) design pattern, representing different pages of the application.
    - **SearchPage Class:** Contains locators and methods for interacting with the desktop version of the Google Maps search page.
    - **MobileSearchPage Class:** Represents the mobile version of the Google Maps search page. Contains locators for page elements and methods for interacting with them.
- **Tests:** Folder that contains all tests organized by functionality and device type.

> The project uses the Page Object Model (POM) design pattern, prioritizing the maintainability and reusability of test code. Additionaly, in the project, the test data is segrated from test logic, thereby augmenting readability and facilitating maintenance processes.

## CI(Github Actions)

The project uses GitHub Actions for Continuous Integration (CI). This allows for ensuring that tests are working as expected whenever a change is made. The configuration for GitHub Actions is found in the `.github/workflows` directory of the project. The CI pipeline includes steps for setting up the environment, installing dependencies, and running the tests.
