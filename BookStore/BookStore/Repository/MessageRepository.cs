using BookStore.Models;
using Microsoft.Extensions.Options;

namespace BookStore.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public NewBookAlertConfig _newBookAlertConfiguration;

        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> newBookAlertConfiguration)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.CurrentValue;
            newBookAlertConfiguration.OnChange(config =>
            {
                _newBookAlertConfiguration = config;
            });
        }


        public string GetName()
        {
            return _newBookAlertConfiguration.BookName;
        }
    }
}
