using Microsoft.Azure.Mobile.Server;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Web.UI.WebControls;

namespace ZUMOAPPNAMEService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public string Major {get; set;}

        public string Department {get; set;}

        public string Faculty {get; set;}

        public string Rez {get; set;}

        public int Year {get; set;}

        public int Gradyear {get; set;}

        public string Birthday {get; set;}

        public bool Oncampus {get; set;}

        public string Hometown {get; set;}

        public string Location {get; set;}

        public string Email {get; set;}

        public string Insta {get; set;}

        public string Facebook {get; set;}

        public string Linkedin {get; set;}

        public string Snap {get; set;}

        public string Phone {get; set;}

        public byte[] Profilepic {get; set;}

        public bool Complete { get; set; }

        public string Courselist { get; set; }

        // V ======================= NEW ======================== V
        public string Profilepicurl { get; set; }

        public string University { get; set; }

        public string Privacypolicy { get; set; }

        private int Privacyinteger { get; set; }

        private int Age { get; set; }
        private string Toughcourse { get; set; }






        //TODO: Add varbinary or blob for profile pic, date for bday, xml for[university, major, year], [xml for social media: instagram, facebook, snapchat, linkedin, email], xml for class list

    }
}