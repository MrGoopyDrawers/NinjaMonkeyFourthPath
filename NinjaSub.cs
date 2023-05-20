using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
internal class NinjaSub
{
    public class NinjaSlicer : ModTower
    {
        protected override int Order => 1;
        public override TowerSet TowerSet => TowerSet.Magic;
        public override string BaseTower => "NinjaMonkey-100";
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "Slicing Shinobi";
        public override bool DontAddToShop => true;
        public override string Description => "Slices bloons in radius";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("NinjaMonkey-100").portrait;
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
            towerModel.GetBehavior<TowerExpireModel>().lifespan = 25;
            towerModel.range *= 0.6f;
            towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("Sauda 7").GetAttackModel().weapons[0].Duplicate());
            towerModel.GetAttackModel().range *= 0.4f;
        }
    }
    public class PsiNinja : ModTower
    {
        protected override int Order => 1;
        public override TowerSet TowerSet => TowerSet.Magic;
        public override string BaseTower => "NinjaMonkey-200";
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "Psychic Ninja";
        public override bool DontAddToShop => true;
        public override string Description => "Slices bloons in radius";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("NinjaMonkey-200").portrait;
            towerModel.GetAttackModel().weapons[0].rate *= 99f;
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
            towerModel.GetBehavior<TowerExpireModel>().lifespan = 25;
            towerModel.range *= 2f;
            towerModel.GetAttackModel().AddWeapon(Game.instance.model.GetTowerFromId("Psi 6").GetAttackModel().weapons[0].Duplicate());
            towerModel.GetAttackModel().range *= 2f;
        }
    }
    public class OverlordNinja : ModTower
    {
        protected override int Order => 1;
        public override TowerSet TowerSet => TowerSet.Magic;
        public override string BaseTower => "NinjaMonkey-041";
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "Shinobi Overlord";
        public override bool DontAddToShop => true;
        public override string Description => "Made for DDT reliability.";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("NinjaMonkey-040").portrait;
            towerModel.GetAttackModel().weapons[0].rate *= 0.3f;
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 50, false, true));
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
            towerModel.GetBehavior<TowerExpireModel>().lifespan = 20;
            towerModel.range *= 2f;
            towerModel.GetAttackModel().range *= 2f;
            towerModel.RemoveBehavior<AbilityModel>();
        }
    }
}