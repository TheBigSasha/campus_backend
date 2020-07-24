using Microsoft.Azure.Mobile.Server;

namespace ZUMOAPPNAMEService.DataObjects
{
    public class TodoItem : EntityData
    { 
        public string Name { get; set; }
   
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}