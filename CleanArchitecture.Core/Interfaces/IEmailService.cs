namespace CleanArchitecture.Core.Interfaces;

public interface IEmailService
{
    Task SendAsync(
        string to,
        string from,
        string subject,
        string body
        );
}