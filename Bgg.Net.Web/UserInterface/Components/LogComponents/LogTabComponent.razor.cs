using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Web.Models;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.UserInterface.Components.LogComponents
{
    public partial class LogTabComponent
    {
        [Parameter, EditorRequired]
        public long GameId { get; set; }
        public LogPlayRequest LogPlayRequest { get; set; }
        public List<LogHistoryViewItem> PlayViews { get; private set; } = new();

        private bool Complete
        {
            //We invert these since the BGG API refers to it as incomplete, but we want to use the affirmative form for user experience.
            get => !LogPlayRequest.Incomplete.Value;
            set => LogPlayRequest.Incomplete = !value;
        }

        private string expandText = "+";
        private bool collapsePlayers = false;
        private Color alertColor = Color.Success;
        private bool displayAlert = false;
        private string? alertMessage;

        public LogTabComponent() 
        {
            LogPlayRequest = new LogPlayRequest(GameId);
        }

        public async Task LogPlay()
        {
            var loginCookie = await _bggLoginService.GetLoginCookie("JusticiarIV", "Godzilla");
            var result = await _playsClient.LogPlay(loginCookie, LogPlayRequest);

            if (result.IsSuccessful)
            {
                alertMessage = "Play Logged Successfully";
                alertColor = Color.Success;
                displayAlert = true;
                await InitializePlayViews();
            }
            else
            {
                alertMessage = "Unable to log play";
                alertColor = Color.Danger;
                displayAlert = true;
            }
        }

        public void AccordionToggle()
        {
            if (collapsePlayers)
            {
                collapsePlayers = false;
                expandText = "+";
            }
            else
            {
                collapsePlayers = true;
                expandText = "-";
            }

            if (!LogPlayRequest.Players.Any())
            {
                LogPlayRequest.Players.Add(new Player());
            }
        }

        public void AddPlayer()
        {
            LogPlayRequest.Players.Add(new Player());
        }

        public void RemovePlayer(int index)
        {
            LogPlayRequest.Players.RemoveAt(index);
        }

        protected override async Task OnInitializedAsync()
        {
            InitializeForm();
            await InitializePlayViews();            

            await base.OnInitializedAsync();
        }       

        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            if (GameId == default)
            {
                throw new ArgumentException(nameof(GameId));
            }

            return base.SetParametersAsync(parameters);
        }

        private void InitializeForm()
        {
            LogPlayRequest.PlayDate = DateTime.Now;
            LogPlayRequest.Date = DateTime.Now;
            LogPlayRequest.Quantity = 1;
            LogPlayRequest.Incomplete = false;
            LogPlayRequest.Ajax = 1;
            LogPlayRequest.ObjectId = GameId;
        }

        private async Task InitializePlayViews()
        {
            //TODO: remove hardcoded value
            var playResponse = await _playsClient.GetPlays(new PlaysRequest("JusticiarIV"));

            if (playResponse.IsSuccessful)
            {
                PlayViews = LogHistoryViewItem.FromPlays(playResponse.Item.Play.Where(x => x.Item.Id == GameId));
            }
        }
    }
}
