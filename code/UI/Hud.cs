using Sandbox.UI;

namespace Agency
{
	public partial class AgencyHud : Sandbox.HudEntity<RootPanel>
	{
		public AgencyHud()
		{
			if ( IsClient )
			{
				RootPanel.StyleSheet.Load("UI/hud.scss");
				RootPanel.SetTemplate( "UI/hud.html" );

				RootPanel.AddChild<Team>();
				RootPanel.AddChild<MoneyPanel>();
				RootPanel.AddChild<Money>();
			}
		}
	}
}
