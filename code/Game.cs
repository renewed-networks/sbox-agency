
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

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new AgencyPlayer();
			client.Pawn = player;

			player.Respawn();
		}
	}
}
