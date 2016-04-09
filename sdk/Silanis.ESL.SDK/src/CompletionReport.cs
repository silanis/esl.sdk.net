using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class CompletionReport
    {
		private Nullable<DateTime> from;
		private Nullable<DateTime> to;
		private IList<SenderCompletionReport> senders = new List<SenderCompletionReport>();

		public CompletionReport()
        {
        }

		public Nullable<DateTime> From
		{
			get
			{
				return from;
			}
			set
			{
				from = value;
			}
		}

		public Nullable<DateTime> To
		{
			get
			{
				return to;
			}
			set
			{
				to = value;
			}
		}

		public IList<SenderCompletionReport> Senders
		{
			get
			{
				return senders;
			}
			set
			{
				senders = value;
			}
		}

		public void AddSender(SenderCompletionReport sender)
		{
			senders.Add(sender);
		}
    }
}

