using MelonLoader;
using BTD_Mod_Helper;
using NinjaMonkeyFourthPath;

[assembly: MelonInfo(typeof(NinjaMonkeyFourthPath.NinjaMonkeyFourthPathMain), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace NinjaMonkeyFourthPath;

public class NinjaMonkeyFourthPathMain : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<NinjaMonkeyFourthPathMain>("NinjaMonkeyFourthPath loaded!");
    }
}