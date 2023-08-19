using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// Represents a user from the BGG XML API2
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("user", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class User : BggBase
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The users name.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// The users first name.
        /// </summary>
        [XmlElement("firstname")]
        public BggString FirstName { get; set; }

        /// <summary>
        /// The users last name.
        /// </summary>
        [XmlElement("lastname")]
        public BggString LastName { get; set; }

        /// <summary>
        /// A link to the users avatar.
        /// </summary>
        [XmlElement("avatarlink")]
        public BggString AvatarLink { get; set; }

        /// <summary>
        /// The year the user registered for bgg.
        /// </summary>
        [XmlElement("yearregistered")]
        public BggInteger YearRegistered { get; set; }

        /// <summary>
        /// The last date the user logged in.
        /// </summary>
        [XmlElement("lastlogin")]
        public BggString LastLogin { get; set; }

        /// <summary>
        /// The state or province the user lives in.
        /// </summary>
        [XmlElement("stateorprovince")]
        public BggString StateOrProvince { get; set; }

        /// <summary>
        /// The country the user lives in.
        /// </summary>
        [XmlElement("country")]
        public BggString Country { get; set; }

        /// <summary>
        /// The users webaddress.
        /// </summary>
        [XmlElement("webaddress")]
        public BggString WebAddress { get; set; }

        /// <summary>
        /// The users xbox account name.
        /// </summary>
        [XmlElement("xboxaccount")]
        public BggString XboxAccount { get; set; }

        /// <summary>
        /// The users wii account name.
        /// </summary>
        [XmlElement("wiiaccount")]
        public BggString WiiAccount { get; set; }

        /// <summary>
        /// The users playstation network account name.
        /// </summary>
        [XmlElement("psnaccount")]
        public BggString PsnNetwork { get; set; }

        /// <summary>
        /// The users Battle.Net account name.
        /// </summary>
        [XmlElement("battlenetaccount")]
        public BggString BattleNetAccount { get; set; }

        /// <summary>
        /// The users steam account.
        /// </summary>
        [XmlElement("steamaccount")]
        public BggString SteamAccount { get; set; }

        /// <summary>
        /// The rating this user has for trading.
        /// </summary>
        [XmlElement("traderating")]
        public BggInteger TradeRating { get; set; }

        /// <summary>
        /// The rating this user has for the market.
        /// </summary>
        [XmlElement("marketrating")]
        public BggInteger MarketRating { get; set; }

        /// <summary>
        /// This users list of buddies.
        /// </summary>
        [XmlElement("buddies")]
        public BuddyList Buddies { get; set; }

        /// <summary>
        /// This users list of guilds.
        /// </summary>
        [XmlElement("guilds")]
        public GuildList Guilds { get; set; }

        /// <summary>
        /// The users top of an item.
        /// </summary>
        [XmlElement("top")]
        public UserItemList Top { get; set; }

        [XmlElement("hot")]
        public UserItemList Hot { get; set; }
    }
}
