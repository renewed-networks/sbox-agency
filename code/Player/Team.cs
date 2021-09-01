namespace Agency
{
	public class AgencyTeam
	{
		public enum Teams
		{
			Civilian,
			VIP,
			Agent,
			Spectator
		}

		public static void SetAsSpectator(AgencyPlayer pl)
		{
			Teams team = Teams.Spectator;
			pl.Team = team;
			pl.Money = 0;
		}

		public static void SetAsVIP(AgencyPlayer pl)
		{
			Teams team = Teams.VIP;
			pl.Team = team;
			pl.Money = 700;
		}

		public static void SetAsAgent(AgencyPlayer pl)
		{
			Teams team = Teams.Agent;
			pl.Team = team;
			pl.Money = 500;
		}

		public static void SetAsCivil(AgencyPlayer pl)
		{
			Teams team = Teams.Civilian;
			pl.Team = team;
			pl.Money = 50;
		}
	}
}
