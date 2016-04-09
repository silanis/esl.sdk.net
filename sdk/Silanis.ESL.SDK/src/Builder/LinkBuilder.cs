using System;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
	public class LinkBuilder
	{
		private string text;
		private string tooltip;
		private string href;


		private LinkBuilder ( string href )
		{
			this.href = href;
			tooltip = null;
			text = null;
		}

		public static LinkBuilder newLink( String href )
		{
			return new LinkBuilder (href);
		}

		public LinkBuilder withText( string text )
		{
			this.text = text;
			return this;
		}

		public LinkBuilder withTooltip( string tooltip )
		{
			this.tooltip = tooltip;
			return this;
		}

		internal Link build()
		{
			var link = new Link ();
			link.Href = href;
			link.Text = (text == null ? href : text );
			link.Title = (tooltip == null ? href : tooltip);

			return link;
		}

	}
}

