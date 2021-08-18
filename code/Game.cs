
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Agency
{
	public partial class Agency : Sandbox.Game
	{
		public Agency()
		{
			if ( IsServer )
			{
				new AgencyHud();
			}
		}

		public override void ClientJoined( Client cl )
		{
			base.ClientJoined(cl);

			var player = new AgencyPlayer();
			cl.Pawn = player;

			Event.Run("PreClientJoined", cl);
			player.Respawn();
			Event.Run("PostClientJoined", cl);
		}

		[Event("PreClientJoined")]
		public async void PreClientJoined(Client cl) { }

		public override void DoPlayerNoclip(Client cl) { }
	}
}
