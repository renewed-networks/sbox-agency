using Sandbox;
using System;
using System.Linq;

namespace Agency
{
	partial class AgencyPlayer : Player
	{
		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			Controller = new WalkController();
			Animator = new StandardPlayerAnimator();
			Camera = new ThirdPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			SimulateActiveChild( cl, ActiveChild );
		}

		public override void OnKilled()
		{
			base.OnKilled();

			EnableDrawing = false;
		}

		public override void TakeDamage(DamageInfo info)
		{
			if (GetHitboxGroup(info.HitboxIndex) == 1)
			{
				info.Damage *= 10.0f;
			}

			base.TakeDamage(info);
		}
	}
}
