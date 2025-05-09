using UnityEngine;
using UnityEngine.UI;
using MelonLoader;
using Il2CppAssets.Scripts.UI.Panels;

namespace BringBackOldScoreboard
{
    public class Main : MelonMod
    {
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
            }

            base.OnSceneWasLoaded(buildIndex, sceneName);
        }
    }
}
