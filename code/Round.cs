using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency
{
	public class Round
	{
		public int SetRoundState
		{
			get
			{
				return SetRoundState;
			}

			set
			{
				SetRoundState = value;
				Event.Run("OnRoundStateChanged", value);
			}
		}
	}
}
