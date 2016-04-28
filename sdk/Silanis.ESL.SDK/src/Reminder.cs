using System;

namespace Silanis.ESL.SDK
{
    public class Reminder
    {
		/// <summary>
		/// The date the reminder is slated to be sent.
		/// </summary>
		private DateTime date;
		/// <summary>
		/// The date the reminder was actually sent.  Null until the reminder has been sent.
		/// </summary>
		private Nullable<DateTime> sentDate;

		public Reminder( DateTime date ) : this( date, null )
		{
		}

		public Reminder( DateTime date, DateTime sentDate ) : this( date, new Nullable<DateTime>(sentDate) )
		{
		}

		public Reminder( DateTime date, Nullable<DateTime> sentDate )
        {
			this.date = date;
			this.sentDate = sentDate;
        }

		public DateTime Date
		{
			get
			{
				return date;
			}
		}

		public Nullable<DateTime> SentDate
		{
			get
			{
				if (sentDate == null)
				{
					return null;
				}
				else
				{
					return sentDate.Value;
				}
			}
		}
    }
}

