using Il2Cpp;

namespace BringBackOldScoreboard.Patches
{
    [HarmonyPatch(typeof(PnlPreparation), nameof(PnlPreparation.OnDiffTglChanged))]
    internal class PnlPreparationPatch
    {
        private static void Postfix()
        {
            Main.FixScoreboard();
        }
    }
}
