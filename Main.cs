global using UnityEngine;
global using UnityEngine.UI;
global using MelonLoader;
global using HarmonyLib;
using Il2CppAssets.Scripts.UI.Panels;

namespace BringBackOldScoreboard
{
    public class Main : MelonMod
    {
        public const string ModVersion = "1.1.0";

        public string[] toDisable = {
            "ImgTitleTop",
            "TxtContent",
            "BtnRandomReset",
            "MaskLevelConfig",
            "rootBtnLevelConfigTop",
            "rootBtnLevelConfigRight"
        };
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("BringBackOldScoreboard initialized.");

            base.OnInitializeMelon();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "UISystem_PC")
            {
                var pnlRank = GameObject.Find("UI/Standerd/PnlPreparation/Panels/PnlRankLocalization/Pc/PnlRank").GetComponent<PnlRank>();
                var panel = GameObject.Find("UI/Standerd/PnlPreparation/Panels/PnlRankLocalization/Pc/PnlRank/Mask");
                var base1 = panel.transform.Find("ImgBaseDarkP").gameObject;
                var base2 = base1.transform.Find("ImgTittleBaseP").gameObject;
                var bgRectTransform = base2.transform.Find("ImgRankTips").GetComponent<RectTransform>();
                var newLabel = base2.transform.Find("ImgBaseShrinkAndNotInShankShowText").gameObject;
                var oldLabel = base2.transform.Find("ImgBaseShallowP").gameObject;

                // Disabling new UI
                foreach (var uiName in toDisable)
                {
                    panel.transform.Find(uiName).gameObject.SetActive(false);
                }

                // Fixing the UI
                base1.GetComponent<Image>().enabled = false;
                base2.GetComponent<Button>().enabled = false;
                base2.transform.Find("TxtContent/ImgLroll").gameObject.SetActive(false);
                base2.transform.localPosition = new Vector3(0, 58, 0);
                bgRectTransform.sizeDelta = new Vector2(0, 340);
                bgRectTransform.anchoredPosition = new Vector2(0, -270);
                base2.transform.Find("ScvRank/Viewport").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 336);

                newLabel.GetComponent<Image>().enabled = false;
                newLabel.transform.Find("TxtId").gameObject.SetActive(false);

                var oldLabelClone = GameObject.Instantiate(oldLabel, base2.transform);
                oldLabelClone.SetActive(true);

                oldLabel.GetComponent<Image>().enabled = false;
                for (int i = 0; i < oldLabel.transform.GetChildCount(); i++)
                {
                    var obj = oldLabel.transform.GetChild(i);
                    obj.gameObject.SetActive(false);
                }
            }

            base.OnSceneWasLoaded(buildIndex, sceneName);
        }

        public static void FixScoreboard()
        {
            var pnlRank = GameObject.Find("UI/Standerd/PnlPreparation/Panels/PnlRankLocalization/Pc/PnlRank").GetComponent<PnlRank>();
            pnlRank.OnClickRestLevelConfig();

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
