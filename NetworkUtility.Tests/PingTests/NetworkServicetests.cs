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
}
