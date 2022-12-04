using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExampleMod.Common.Players
{
	public class ExampleMinerSetBonusPlayer : ModPlayer
	{
		private bool _minerSet;

		public override void PostUpdateEquips() {
			_minerSet = (Player.head == ArmorIDs.Head.MiningHelmet || Player.head == ArmorIDs.Head.UltraBrightHelmet) &&
			            Player.body == ArmorIDs.Body.MiningShirt &&
			            Player.legs == ArmorIDs.Legs.MiningPants;
		}

		public override void ModifyHitByOwnProjectile(Projectile proj, ref int damage) {
			if (_minerSet && !proj.trap && !proj.originatedFromActivableTile) {
				damage = damage / 2;
			}
		}
	}
}