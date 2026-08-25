using C_AQA.DTO.UsersDataDTOs;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Text.Json;

namespace C_AQA.Tests;

public class UsersJsonTests
{
    private List<UserDTO> users = new();
    private const double SwedenMinLatitude = 55.0;
    private const double SwedenMaxLatitude = 69.1;
    private const double SwedenMinLongitude = 10.9;
    private const double SwedenMaxLongitude = 24.2;

    [OneTimeSetUp]
    public void Setup()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "UsersData.json");
        string json = File.ReadAllText(path);

        var root = JsonSerializer.Deserialize<UsersRootDTO>(json);
        users = root!.Data;
    }

    [Test]
    public void Test1_CheckUsersCount()
    {
        users.Should().HaveCount(10);
    }

    [Test]
    public void Test2_CheckFirstUserIsAliceJohnson()
    {
        users.First().Profile.FullName.Should().Be("Alice Johnson");
    }

    [Test]
    public void Test3_CheckAllIdsAreUnique()
    {
        var ids = users.Select(user => user.Id).ToList();

        ids.Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void Test4_CheckAtLeastOnePremiumUser()
    {
        users.Should().Contain(user => user.Profile.Tags.Contains("premium"));
    }

    [Test]
    public void Test5_CheckAllUsersHaveCity()
    {
        users.Should().OnlyContain(user => !string.IsNullOrWhiteSpace(user.Profile.Address.City));
    }

    [Test]
    public void Test6_CheckAtLeastOneUserFromStockholm()
    {
        var stockholmUsers = users.Where(user => user.Profile.Address.City == "Stockholm").ToList();

        stockholmUsers.Should().NotBeEmpty();
    }

    [Test]
    public void Test7_CheckAllAgesAreInRange()
    {
        var ages = users.Select(user => user.Profile.Age).ToList();

        using (new AssertionScope())
        {
            ages.Should().OnlyContain(age => age >= 18 && age <= 60);
            ages.Min().Should().BeGreaterThanOrEqualTo(18);
            ages.Max().Should().BeLessThanOrEqualTo(60);
        }
    }

    [Test]
    public void Test8_CheckAtLeastOneAdmin()
    {
        users.Should().Contain(user => user.Roles.Contains("admin"));
    }

    [Test]
    public void Test9_CheckAllUsersAreLocatedInSweden()
    {
        var locations = users.Select(user => (user.Profile.FullName, user.Profile.Address.Geo)).ToList();

        using (new AssertionScope())
        {
            locations.Should().AllSatisfy(location =>
            {
                location.Geo.Lat.Should().BeInRange(SwedenMinLatitude, SwedenMaxLatitude,
                    $"широта {location.FullName} должна быть в границах Швеции");
                location.Geo.Lng.Should().BeInRange(SwedenMinLongitude, SwedenMaxLongitude,
                    $"долгота {location.FullName} должна быть в границах Швеции");
            });
        }
    }
}
