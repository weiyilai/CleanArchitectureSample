using CleanArchitecture.Core.AccountAggregate;
using CleanArchitecture.Core.AccountAggregate.Events;
using CleanArchitecture.Core.AccountAggregate.Handlers;
using CleanArchitecture.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace CleanArchitecture.UnitTests.Handlers;

[TestClass]
public class AccountCompletedEmailNotificationHandlerTest
{
    private AccountCompletedEmailNotificationHandler _handler;
    private Mock<IEmailService> _emailServiceMock;
    private Mock<ILogger<AccountCompletedEmailNotificationHandler>> _loggerMock;

    [TestInitialize]
    public void Initial()
    {
        _emailServiceMock = new Mock<IEmailService>();
        _loggerMock = new Mock<ILogger<AccountCompletedEmailNotificationHandler>>();
        _handler = new AccountCompletedEmailNotificationHandler(
            _loggerMock.Object,
            _emailServiceMock.Object
            );
    }

    /// <summary>
    /// 給定空事件參數引發異常
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task When_GivenNullEventArgument_Expect_THrowsException()
    {
#nullable disable
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(() =>
            _handler.Handle(null, CancellationToken.None)
            );
#nullable enable
    }

    /// <summary>
    /// 發送給定事件實例的電子郵件
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task When_GivenEventInstance_Expect_SendsEmail()
    {
        await _handler.Handle(
            new AccountCompletedEvent(new Account()), 
            CancellationToken.None
            );

        _emailServiceMock.Verify(sender => 
            sender.SendAsync(
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>()
                ), 
            Times.Once
            );
    }
}