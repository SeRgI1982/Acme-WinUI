namespace Acme.Core.Services
{
    public interface IDialogService
    {
        Task ShowMessageAsync(string title, string content);
    }
}
