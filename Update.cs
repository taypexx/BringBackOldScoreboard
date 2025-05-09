using UnityEngine;
using HarmonyLib;
using Il2CppAssets.Scripts.UI.Panels;

namespace BringBackOldScoreboard
{
    [HarmonyPatch(typeof(PnlRank), nameof(PnlRank.UIRefresh))]
    internal class Update
    {
        public static void Postfix()
        {
            var selfRank = GameObject.Find("UI/Standerd/PnlPreparation/Panels/PnlRankLocalization/Pc/PnlRank/Mask/ImgBaseDarkP/ImgTittleBaseP/ScvRank/PlayerRankCell_4-3");
            selfRank.transform.localPosition = new Vector3(0, -336, 0);

            //var loaded = GameObject.Find("UI/Standerd/PnlPreparation/Panels/PnlRankLocalization/Pc/PnlRank/Mask/ImgBaseDarkP/ImgTittleBaseP/ScvRank").active;
            var loaded = true;

            var topUI = GameObject.Find("UI/Standerd/PnlPreparation/Panels/PnlRankLocalization/Pc/PnlRank/Mask/ImgBaseDarkP/ImgTittleBaseP/ImgBaseShallowP");
            topUI.SetActive(loaded);

            var topUI2 = GameObject.Find("UI/Standerd/PnlPreparation/Panels/PnlRankLocalization/Pc/PnlRank/Mask/ImgBaseDarkP/ImgTittleBaseP/ImgBaseShrinkAndNotInShankShowText");
            topUI2.SetActive(!loaded);
        }
    }
}