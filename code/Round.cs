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
		public bool RoundStarted
		{
			get
			{
				return RoundStarted;
			}

			set
			{
				RoundStarted = value;
				Event.Run("OnRoundStateChanged", value);
			}
		}
	}
}
