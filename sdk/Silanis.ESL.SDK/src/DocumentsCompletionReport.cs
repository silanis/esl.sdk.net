using System;

namespace Silanis.ESL.SDK
{
    public class DocumentsCompletionReport
    {
		private Boolean completed;
		private Nullable<DateTime> firstSigned;
		private string id;
		private Nullable<DateTime> lastSigned;
		private string name;

		public DocumentsCompletionReport(String name)
        {
			this.name = name;
        }

		public Boolean Completed
		{
			get
			{
				return completed;
			}
			set
			{
				completed = value;
			}
		}

		public Nullable<DateTime> FirstSigned
		{
			get
			{
				return firstSigned;
			}
			set
			{
				firstSigned = value;
			}
		}

		public string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public Nullable<DateTime> LastSigned
		{
			get
			{
				return lastSigned;
			}
			set
			{
				lastSigned = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
    }
}

