using Microsoft.Azure.Mobile.Server;
using System.Web.UI.WebControls;

namespace ZUMOAPPNAMEService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public bool Complete { get; set; }

        //TODO: Add varbinary or blob for profile pic, date for bday, xml for[university, major, year], [xml for social media: instagram, facebook, snapchat, linkedin, email], xml for class list

    }
}