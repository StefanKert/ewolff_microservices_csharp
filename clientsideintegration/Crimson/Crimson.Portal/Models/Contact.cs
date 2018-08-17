using System;
using System.Collections.Generic;

namespace Crimson.Portal.Models
{
    public class Contact
    {
        public string Advisor { get; set; }
        public DateTime Date { get; set; }
        public string FormattedDate { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public static Dictionary<string, string> ContactTypes = new Dictionary<string, string>
        {
            { "Email", "icon-mail-2-filled" },
            { "Telefon", "icon-call-1-filled" },
        };
    }
}
