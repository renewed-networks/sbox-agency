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
		var player = Local.Pawn;
		if (player == null) return;
		Label.Text = "Test";
	}
}
