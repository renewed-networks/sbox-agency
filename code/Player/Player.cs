﻿using Sandbox;
using System;
using System.Linq;

namespace Agency
{
	partial class AgencyPlayer : Player
	{
		[Net, Local] public ModelEntity Ragdoll { get; set; }

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
			Event.Run("PostPlayerRespawned");
		}

		[Event("PostPlayerRespawned")]
		public void PostPlayerRespawned() { }

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );
			SimulateActiveChild( cl, ActiveChild );
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