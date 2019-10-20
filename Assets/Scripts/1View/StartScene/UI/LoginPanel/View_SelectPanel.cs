using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace StartScene.View
{
    public class View_SelectPanel : BaseUIPanel
    {
        public Button swordBtn;
        public Button magicBtn;
        public InputField inputFieldName;
        public Button confirmBtn;
        public GameObject sowrd;
        public GameObject magic;
        public GameObject swordInfoImage;
        public GameObject magicInfoImage;




        private void Start()
        {
            swordBtn.onClick.AddListener(delegate ()
            {
                OpenSowrdInfo();
            });
            magicBtn.onClick.AddListener(() =>
            {
                OpenMagicInfo();
            });
            inputFieldName.text = "默认名字";
            inputFieldName.onValueChanged.AddListener(delegate (string s) { });

            confirmBtn.onClick.AddListener(() =>
            {
                //RecordHeroData.playerName = inputFieldName.text;

                SceneManager.LoadSceneAsync("LoadingMainScene");
            });
        }

        public void OpenSowrdInfo()
        {
            //RecordHeroData.playerType = PlayerType.Sword;
            sowrd.gameObject.SetActive(true);
            swordInfoImage.gameObject.SetActive(true);
            magic.SetActive(false);
            magicInfoImage.SetActive(false);
        }

        private void OpenMagicInfo()
        {
            //RecordHeroData.playerType = PlayerType.Magic;
            sowrd.gameObject.SetActive(false);
            swordInfoImage.gameObject.SetActive(false);
            magic.SetActive(true);
            magicInfoImage.SetActive(true);
        }


    }
}