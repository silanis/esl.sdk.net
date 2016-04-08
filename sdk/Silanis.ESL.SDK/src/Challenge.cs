using System;

namespace Silanis.ESL.SDK
{
	public class Challenge
	{
		public enum MaskOptions
		{
			MaskInput, None
		}

		private readonly string question;
		private readonly string answer;
		private readonly MaskOptions maskOption;


		public Challenge (string question, string answer) : this(question, answer, MaskOptions.None)
		{
		}

		public Challenge (string question, string answer, MaskOptions maskOption)
		{
			this.question = question;
			this.answer = answer;
			this.maskOption = maskOption;
		}

		public string Question
		{
			get
			{
				return question;
			}
		}

		public string Answer
		{
			get
			{
				return answer;
			}
		}

		public MaskOptions MaskOption
		{
			get
			{
				return maskOption;
			}
		}

		public override bool Equals(object other)
		{
			if (this == other)
			{
				return true;
			}

			if (other == null || other.GetType () != GetType ())
			{
				return false;
			}

			var challenge = (Challenge)other;
			return challenge.Question.Equals (question) && challenge.Answer.Equals (answer);
		}

		public override int GetHashCode()
		{
			var hash = question.GetHashCode ();

			hash = hash * 31 + answer.GetHashCode ();
			return hash;
		}

		public override string ToString ()
		{
			return String.Format ("{0}, {1}", question, answer);
		}
	}
}