using Sandbox.UI;

namespace Agency
{
	public partial class AgencyHud : Sandbox.HudEntity<RootPanel>
	{
		public AgencyHud()
		{
			if ( IsClient )
			{
				RootPanel.SetTemplate( "UI/hud.html" );
			}
		}
	}
}
