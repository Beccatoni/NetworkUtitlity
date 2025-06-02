using FluentAssertions;
using NetworkUtitlity.Ping;
using Xunit;
namespace NetworkUtility.Tests;

public class NetworkServicetests
{
   
    //public  NetworkServicetests()
    //{
    //}

    [Fact]
    public void NetworkSevice_SendPing_ReturnsString()
    {
        // Arrange - variables, classes, mocks
        var pingService = new NetworkService();

        //Act
        var result = pingService.SendPing();

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
        result.Should().BeGreaterThanOrEqualTo(3);
        result.Should().NotBeInRange(-1000, 0);
    }
}
