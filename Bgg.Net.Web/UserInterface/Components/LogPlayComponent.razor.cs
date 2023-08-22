using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Models.Bgg;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.UserInterface.Components
{
    public partial class LogPlayComponent
    {
        [Parameter]
        [EditorRequired]
        public long ObjectId { get; set; }

        public LogPlayRequest LogPlayRequest { get; set; }
        private bool Complete 
        { 
            //We invert these since the BGG API refers to it as incomplete, but we want to use the affirmative form for user experience.
            get => !LogPlayRequest.Incomplete.Value;
            set => LogPlayRequest.Incomplete = !value; 
        }

        private bool collapsePlayers = false;
        private string expandText = "+";

        public LogPlayComponent()
        {
            LogPlayRequest = new LogPlayRequest(ObjectId);
        }

        public async Task LogPlay()
        {
            var loginCookie = await _bggLoginService.GetLoginCookie("JusticiarIV", "Godzilla");
            var result = await _playsClient.LogPlay(loginCookie, LogPlayRequest);
        }


        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            if (ObjectId == default)
            {
                throw new ArgumentException(nameof(ObjectId));
            }

            return base.SetParametersAsync(parameters);
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

        protected override void OnInitialized()
        {
            LogPlayRequest.PlayDate = DateTime.Now;
            LogPlayRequest.Date = DateTime.Now;
            LogPlayRequest.Quantity = 1;
            LogPlayRequest.Incomplete = false;
            LogPlayRequest.Ajax = 1;
            LogPlayRequest.ObjectId = ObjectId;

            base.OnInitialized();
        }
    }
}
