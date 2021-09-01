using Sandbox;
using System;
using System.Linq;

namespace Agency
{
	partial class AgencyPlayer : Player
	{
		[Net, Predicted, Local]
		public ModelEntity Ragdoll { get; set; }

		[Net]
		public int Money { get; private set; }

		[Net]
		public Teams Team { get; private set; }

		public enum Teams
		{
			Civilian,
			VIP,
			Agent,
			Spectator
		}

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
			Ragdoll = null;

			base.Respawn();
			Event.Run("PostPlayerRespawned");
			Dress();
		}

		private void SetAsSpectator()
		{
			Teams team = Teams.Spectator;
			Team = team;
		}

		private void SetAsVIP()
		{
			Teams team = Teams.VIP;
			Team = team;
		}

		private void SetAsAgent()
		{
			Teams team = Teams.Agent;
			Team = team;
		}

		private void SetAsCivil()
		{
			Teams team = Teams.Civilian;
			Team = team;
		}

		[Event("PostPlayerRespawned")]
		public async void PostPlayerRespawned() 
		{
			await Task.DelaySeconds(1);

			SetAsAgent();

			if (Team is Teams.VIP)
			{
				Money = 700;
			} else if (Team is Teams.Agent)
			{
				Money = 500;
			} else if (Team is Teams.Civilian)
			{
				Money = 50;
			} else
			{
				Money = 0;
			}
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );
			SimulateActiveChild( cl, ActiveChild );

			if (Input.Pressed(InputButton.View))
			{
				if (Camera is not FirstPersonCamera)
				{
					Camera = new FirstPersonCamera();
				}
				else
				{
					Camera = new ThirdPersonCamera();
				}
			}
		}

		public override void OnKilled()
		{
			base.OnKilled();

			if (GetModelName() != null)
			{
				var ragdoll = new ModelEntity();
				ragdoll.SetModel(GetModelName());
				ragdoll.Position = this.Position;
				ragdoll.SetupPhysicsFromModel(PhysicsMotionType.Dynamic, false);

				ragdoll.CopyBonesFrom(this);
				ragdoll.SetRagdollVelocityFrom(this);

				foreach (Entity child in this.Children)
				{
					if (child is ModelEntity e)
					{
						string model = e.GetModelName();
						if (model == null || !model.Contains("clothes"))
							continue;

						ModelEntity clothing = new ModelEntity();
						clothing.SetModel(model);
						clothing.SetParent(ragdoll, true);
						clothing.RenderColor = e.RenderColor;
					}
				}

				Ragdoll = ragdoll;
			}

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
