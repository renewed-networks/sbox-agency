using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class Money : Panel
{
	public Label Label;

	public Money()
	{
		Label = Add.Label("100", "value");
	}

	public override void Tick()
	{
		var player = Local.Pawn as Agency.AgencyPlayer;
		if (player == null) return;
		//var money = player?.Money;
		Label.Text = $"{player.Money}$";
	}
}
