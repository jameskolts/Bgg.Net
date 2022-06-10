using Bgg.Net.Client.Models;

namespace Bgg.Net.Client.Infrastructure.Commands
{
    public class CollectionItemTappedCommand : ICollectionItemTapped
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();

            if (parameter is CollectionPageItem)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
