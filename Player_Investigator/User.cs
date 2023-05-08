using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Investigator
{
    internal class UserInfo
    {
        //Decide which are needed for smurf calculation

        //64-bit Steam ID
        public string steamID { get; set; }
        //Username
        public string username { get; set; }
        //Real name
        public string realname { get; set; }
        //Whether the profile is private or not (1 = private, 3 = public)
        public int visible { get; set; }
        //Current status - 0 = Offline, 1 = Online, 2 = Busy, 3 = Away, 4 = Snooze
        public int onlineState { get; set; }
        //1 indicates the user has set up their profile
        public int profileState { get; set; }
        //Time the account was created
        public ulong timeCreated { get; set; }
        //Primary group ID
        public string primaryGroupID { get; set; }
        //Country
        public string countryCode { get; set; }
        //State
        public string stateCode { get; set; }
        //City ID
        public int cityID { get; set; }

        public int personaStateFlags { get; set; }


        public UserInfo(GetPlayerSummaryInfo gPSI, GetOwnedGamesInfo gOGI) //And others
        {
            //GetPlayerSummaryInfo
            if (gPSI.steamid is null)
            {
                steamID = "";
            }
            else
            {
                steamID = gPSI.steamid;
            }

            if (gPSI.personaname is null)
            {
                username = "";
            }
            else
            {
                username = gPSI.personaname;
            }

            if (gPSI.realname is null)
            {
                realname = "";
            }
            else
            {
                realname = gPSI.realname;
            }

            if (gPSI.communityvisibilitystate is null)
            {
                visible = -1;
            }
            else
            {
                visible = (int)gPSI.communityvisibilitystate;
            }

            if (gPSI.personastate is null)
            {
                onlineState = -1;
            }
            else
            {
                onlineState = (int)gPSI.personastate;
            }

            if (gPSI.profilestate is null)
            {
                profileState = -1;
            }
            else
            {
                profileState = (int)gPSI.profilestate;
            }

            if (gPSI.timecreated is null)
            {
                timeCreated = 0;
            }
            else
            {
                timeCreated = (ulong)gPSI.timecreated;
            }

            if (gPSI.primaryclanid is null)
            {
                primaryGroupID = "";
            }
            else
            {
                primaryGroupID = gPSI.primaryclanid;
            }

            if (gPSI.loccountrycode is null)
            {
                countryCode = "";
            }
            else
            {
                countryCode = gPSI.loccountrycode;
            }

            if (gPSI.locstatecode is null)
            {
                stateCode = "";
            }
            else
            {
                stateCode = gPSI.locstatecode;
            }

            if (gPSI.loccityid is null)
            {
                cityID = -1;
            }
            else
            {
                cityID = (int)gPSI.loccityid;
            }

            if (gPSI.personastateflags is null)
            {
                personaStateFlags = -1;
            }
            else
            {
                personaStateFlags = (int)gPSI.personastateflags;
            }

            //GetOwnedGamesInfo

        }

        public override string ToString()
        {
            string str = "";
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(this);
                str += $"{name}: {value}\n";
            }
            return str;
        }
    }
}