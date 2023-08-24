using Bgg.Net.Common.Models.Bgg;

namespace Bgg.Net.Web.Models
{
    public class LogHistoryViewItem
    {
        public Play Play { get; set; }

        public string? Winner => Play.Players.SingleOrDefault(x => x.Win)?.Name;

        public string? PlayDate => Play.Date;

        public LogHistoryViewItem(Play play)
        {
            Play = play;
        }
        
        public static List<LogHistoryViewItem> FromPlays(IEnumerable<Play> plays)
        {
            var viewItems = new List<LogHistoryViewItem>();

            foreach (var play in plays)
            {
                viewItems.Add(new LogHistoryViewItem(play));
            }

            return viewItems;
        }
    }
}
