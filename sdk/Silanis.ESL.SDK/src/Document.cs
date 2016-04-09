using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	public class Document
	{
		private List<Signature> signatures = new List<Signature>();
		private List<Field> fields = new List<Field> ();
        private List<Field> qrCodes = new List<Field> ();

		public string Name {
			get;
			set;
		}

		public string Id {
			get;
			set;
		}

		public string FileName {
			get;
			set;
		}

		public byte[] Content {
			get;
			set;
		}

		public int Index {
			get;
			set;
		}

		public bool Extract {
			get;
			set;
		}

        public string Description
        {
            get;
            set;
        }

        public List<Signature> Signatures
        {
            get
            {
                return signatures;
            }
        }       

        public External External
        {
            get;
            set;
        }

        public List<Field> Fields
        {
            get
            {
                return fields;
            }
        }  

        public List<Field> QRCodes
        {
            get
            {
                return qrCodes;
            }
        }

		public void AddSignatures (IList<Signature> signatures)
		{
			this.signatures.AddRange (signatures);
		}
            
		public void AddFields (IList<Field> fields)
		{
			this.fields.AddRange (fields);
		}

        public void AddQRCodes (IList<Field> fields)
        {
            qrCodes.AddRange(fields);
        }
	}
}