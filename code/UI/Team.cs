using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class Team : Panel
{
	public Label Label;

	public Team()
	{
		Label = Add.Label("100", "value");
	}

	public override void Tick()
	{
		var player = Local.Pawn as Agency.AgencyPlayer;
		if (player == null) return;
		var team = player.Team;
		Label.Text = team.ToString();
	}
}
