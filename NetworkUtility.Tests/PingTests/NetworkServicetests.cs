using System.Net.NetworkInformation;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtitlity.Ping;
using Xunit;
namespace NetworkUtility.Tests;

public class NetworkServicetests
{
    private readonly NetworkService _pingService;

    public NetworkServicetests()
    {
        //SUT - System Under Test
        _pingService = new NetworkService();
    }

    [Fact]
    public void NetworkSevice_SendPing_ReturnsString()
    {
        // Arrange - variables, classes, mocks
        

        //Act
        var result = _pingService.SendPing();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("Success: Ping Sent!");
        result.Should().Contain("Success", Exactly.Once());
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void NetWorkService_PingTimeout_ReturnInt(int a, int b, int expected)
    {
        //Arrange
        var pingService = new NetworkService();
        //Act
       var result = pingService.PingTimeout(a, b);
        //Assert
        result.Should().Be(expected);
        result.Should().BeGreaterThanOrEqualTo(2);
        result.Should().NotBeInRange(-1000, 0);
    }

    [Fact]
    public void NetworkService_LastPingDate_ReturnsDate()
    {
        //Act
        var result = _pingService.LastPingDate();

        //Assert
        result.Should().BeAfter(2.June(2025));
        result.Should().BeBefore(1.January(2026));

    }

    [Fact]
    public void NetworkService_GetPingOptions_ReturnsObject()
    {
        //Arrange
        var expected = new PingOptions()
        {
            DontFragment = true,
            Ttl = 1
        };

        // Act
        var result = _pingService.GetPingOptions();

        // Assert WARNING: "Be" careful, to compare reference types use be equivalent to
        result.Should().BeOfType<PingOptions>();
        result.Should().BeEquivalentTo(expected);
        result.Ttl.Should().Be(1);

    }

    [Fact]
    public void NetworkService_MostREcentPings_ReturnsObject()
    {
        //Arrange
        var expected = new PingOptions()
        {
            DontFragment = true,
            Ttl = 1
        };

        // Act
        var result = _pingService.MostREcentPings();

        // Assert WARNING: "Be" careful, to compare reference types use be equivalent to
        //result.Should().BeOfType<IEnumerable<PingOptions>>(); use this instead: result.Should().BeAssignableTo<IEnumerable<PingOptions>>();
        result.Should().BeOfType<PingOptions[]>();
        result.Should().ContainEquivalentOf(expected);
        result.Should().Contain(x => x.DontFragment == true);

    }
}
