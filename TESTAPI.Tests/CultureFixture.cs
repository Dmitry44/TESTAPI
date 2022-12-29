using System.Globalization;

namespace TESTAPI.Tests;

public class CultureFixture : ICollectionFixture<CultureFixture>, IDisposable
{
    public CultureFixture()
    {
        // Set the culture for the entire test assembly
        CultureInfo cultureInfo = new CultureInfo("de-DE");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }

    public void Dispose()
    {
        // Reset the culture after all of the tests have completed
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
    }
}

[CollectionDefinition("SetCultureInfo")]
public class CultureCollection : ICollectionFixture<CultureFixture> { }
