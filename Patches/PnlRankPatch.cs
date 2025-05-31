using Il2CppAssets.Scripts.UI.Panels;

namespace BringBackOldScoreboard.Patches
{
    [HarmonyPatch(typeof(PnlRank), nameof(PnlRank.UIRefresh))]
    internal class PnlRankPatch
    {
        private static void Postfix()
        {
            Main.FixScoreboard();
        }
    }
}