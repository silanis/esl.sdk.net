using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class SenderCompletionReport
    {
		private IList<PackageCompletionReport> packages = new List<PackageCompletionReport>();
		private Sender sender;

		public IList<PackageCompletionReport> Packages
		{
			get
			{
				return packages;
			}
			set
			{
				packages = value;
			}
		}

		public void AddPackage(PackageCompletionReport aPackage)
		{
			packages.Add(aPackage);
		}


		public Sender Sender
		{
			get
			{
				return sender;
			}
			set
			{
				sender = value;
			}
		}
    }
}

