using System;

namespace Silanis.ESL.SDK
{
	public class PageRequest
	{
		public static readonly int DefaultPageSize = 10;
		public static readonly int MaxPageSize = 50;

		public PageRequest (int from) : this (from, DefaultPageSize)
		{
		}

		public PageRequest (int from, int pageSize)
		{
			From = from;
		    PageSize = pageSize;
		}

		public int From 
		{
			get;
			private set;
		}

		public int To 
		{
			get
			{
				return From + PageSize - 1;
			}
		}

		public int PageSize 
		{
			get;
			private set;
		}

		public PageRequest Next 
		{
			get
			{
				return new PageRequest (From + PageSize, PageSize);
			}
		}
	}
}