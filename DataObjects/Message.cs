using System;

namespace OctoContacts
{
    class Message
    {
        public DateTime Date { get; set; }
        public string To { get; set; }
        public string Text { get; set; }

        public Message(DateTime date, string to, string text)
        {
            Date = date;
            To   = to;
            Text = text;
        }
    }
}
