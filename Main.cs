using MelonLoader;
using BTD_Mod_Helper;
using NinjaMonkeyFourthPath;
using PathsPlusPlus;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Enums;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using JetBrains.Annotations;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppSystem.IO;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Utils;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using UnityEngine;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System.Runtime.CompilerServices;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using static NinjaSub;
namespace NinjaMonkeyPathMain;

public class NinjaFourthMain : BloonsTD6Mod
{
    public class FourthPath2 : PathPlusPlus
    {
        public override string Tower => TowerType.NinjaMonkey;
        public override int UpgradeCount => 5;

    }
    public class DurableShurikens : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 250;
        public override int Tier => 1;
        public override string Icon => VanillaSprites.SharpShurikensUpgradeIcon;

        public override string Description => "Shurikens double in pierce";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackmodel = towerModel.GetAttackModel();
            attackmodel.weapons[0].projectile.pierce *= 2;
        }
    }
    public class ShurikenSlicer : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 650;
        public override int Tier => 2;
        public override string Icon => VanillaSprites.RazorRotorsUpgradeIcon;

        public override string Description => "Shurikens slice through bloons, dealing more damage.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackmodel = towerModel.GetAttackModel();
            attackmodel.weapons[0].projectile.GetDamageModel().damage += 2;
        }
    }
    public class CounterTactician : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 2000;
        public override int Tier => 3;
        public override string Icon => VanillaSprites.AdvancedTargetingUpgradeIcon;

        public override string Description => "Can call in temporary ninjas that have a short range slice attack.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackmodel = towerModel.GetAttackModel();
            AttackModel[] Avatarspawner = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner[0].weapons[0].rate = 15;
            Avatarspawner[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<NinjaSlicer>(), 0, true, false, false, true, false));
            Avatarspawner[0].weapons[0].projectile.display = new() { guidRef = "" };
            towerModel.AddBehavior(Avatarspawner[0]);
        }
    }
    public class BigBloonShredding : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 8000;
        public override int Tier => 4;
        public override string Icon => VanillaSprites.MOABSHREDRUpgradeIcon;

        public override string Description => "Ninja Monkeys gain +8 MOAB damage nearby. Can now call additional ninjas that use there power to destroy the bloons from the inside.";
        
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackmodel = towerModel.GetAttackModel();
            towerModel.AddBehavior(new DamageModifierSupportModel("NinjaMOABIncrease", true, "NinjaMOABincrease", new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[]
                {
                    new FilterInBaseTowerIdModel("FilterInBaseTowerIdModel_",
                        new Il2CppStringArray(new[] { TowerType.NinjaMonkey }))
                }), true, new DamageModifierForTagModel("Ddt", "Ddt", 1, 8, false, true)));
            towerModel.AddBehavior(new DamageModifierSupportModel("NinjaMOABIncrease22", true, "NinjaMOABincrease22", new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[]
                {
                    new FilterInBaseTowerIdModel("FilterInBaseTowerIdModel_",
                        new Il2CppStringArray(new[] { TowerType.NinjaMonkey }))
                }), true, new DamageModifierForTagModel("Moabs", "Moabs", 1, 8, false, true)));
            AttackModel[] Avatarspawner = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner[0].weapons[0].rate = 15;
            Avatarspawner[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<PsiNinja>(), 0, true, false, false, true, false));
            Avatarspawner[0].weapons[0].projectile.display = new() { guidRef = "" };
            towerModel.AddBehavior(Avatarspawner[0]);
            towerModel.range *= 1.1f;
            towerModel.GetAttackModel().range *= 1.1f;
        }
    }
    public class OverseerOfNinjas : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 65000;
        public override int Tier => 5;
        public override string Icon => VanillaSprites.MonkeySenseUpgradeIcon;

        public override string Description => "Calls a overlord ninja every few seconds, they can destroy DDTS easily. All ninja monkeys can damage lead. Increased range and gains a blade attack in a arc.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackmodel = towerModel.GetAttackModel();
            towerModel.AddBehavior(new DamageTypeSupportModel("NinjaDamageSupport", true, "NinjaDamageSupport_", BloonProperties.None, new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[]
                {
                    new FilterInBaseTowerIdModel("FilterInBaseTowerIdModel_",
                        new Il2CppStringArray(new[] { TowerType.NinjaMonkey }))
                }), "NinjaMonkeySupportDamage", null));
            AttackModel[] Avatarspawner = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner[0].weapons[0].rate = 15;
            Avatarspawner[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<OverlordNinja>(), 0, true, false, false, true, false));
            Avatarspawner[0].weapons[0].projectile.display = new() { guidRef = "" };
            towerModel.AddBehavior(Avatarspawner[0]);
            towerModel.range *= 1.4f;
            towerModel.GetAttackModel().range *= 1.4f;
            var bladeProjDisplay = Game.instance.model.GetTowerFromId("TackShooter-030").GetAttackModel().weapons[0].projectile.display;
            var bladeProj = attackmodel.weapons[0].Duplicate();
            bladeProj.projectile.display = bladeProjDisplay;
            bladeProj.emission = new ArcEmissionModel("ArcEmissionModel_", 6, 0, 40, null, false);
            bladeProj.projectile.pierce = 12f;
            bladeProj.rate *= 0.5f;
            bladeProj.projectile.GetDamageModel().damage *= 3f;
            bladeProj.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifier_Moabs", "Moabs", 1, 10, false, true));
            attackmodel.AddWeapon(bladeProj);
        }
    }
}