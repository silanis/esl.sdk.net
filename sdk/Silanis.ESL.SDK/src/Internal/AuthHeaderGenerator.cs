using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	public abstract class AuthHeaderGenerator
    {
		private string name;
		private string value;

		protected AuthHeaderGenerator(string name, string value){
			this.name = name;
			this.value = value;
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		public string Value
		{
			get
			{
				return value;
			}
		}
    }
}

