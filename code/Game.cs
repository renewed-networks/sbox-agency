
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Agency
{
	public partial class Agency : Sandbox.Game
	{
		[Net] public bool RoundStarted { get; private set; }
		public Agency()
		{
			if ( IsServer )
			{
				_ = new AgencyHud();
			}
		}

		public override void ClientJoined( Client cl )
		{
			base.ClientJoined(cl);

			var player = new AgencyPlayer();
			cl.Pawn = player;

			player.Respawn();
			Event.Run("PostClientJoined", cl);
		}

		public override void ClientDisconnect(Client cl, NetworkDisconnectionReason reason) {
			base.ClientDisconnect(cl, reason);
			CheckPlayers();
		}

		public override void PostLevelLoaded()
		{
			RoundStarted = false;
			CheckPlayers();
		}

		private async void CheckPlayers()
		{
			await Task.DelaySeconds(1);
				if (Client.All.Count >= 2) { }
		}

		[Event("PostClientJoined")]

		public async void PostClientJoined(Client cl) {
			CheckPlayers();
		}

		public override void DoPlayerNoclip(Client cl) { }
		//public override void DoPlayerSuicide(Client cl) { }
	}
}
