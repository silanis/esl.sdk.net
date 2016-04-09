using System.Collections;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	public class Page<T> : IEnumerable<T>
	{
		private readonly PageRequest request;

		public Page (IList<T> results, int totalElements, PageRequest request)
		{
			Results = results;
			TotalElements = totalElements;
			this.request = request;
		}

		public IList<T> Results {
			get;
			private set;
		}

		public int Size 
		{
			get
			{
				return request.PageSize;
			}
		}

		public int NumberOfElements {
			get
			{
				return Results.Count;
			}
		}

		public int TotalElements {
			get;
			private set;
		}

		public bool HasNextPage ()
		{
			return (request.From + request.PageSize) <= TotalElements;
		}

		public PageRequest NextRequest {
			get
			{
				return HasNextPage () ? request.Next : null;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return Results.GetEnumerator ();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator ();
		}
	}
}