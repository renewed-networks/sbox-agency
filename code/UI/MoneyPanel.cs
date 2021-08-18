using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class MoneyPanel : Panel
{
	public Label Label;

	public MoneyPanel()
	{
		Label = Add.Label("100", "value");
	}

	public override void Tick()
	{
		var player = Local.Pawn;
		if (player == null) return;
		Label.Text = $"Money";
	}
}
