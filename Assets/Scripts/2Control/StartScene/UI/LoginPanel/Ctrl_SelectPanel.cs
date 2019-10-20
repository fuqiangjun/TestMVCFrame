using UnityEngine;



namespace StartScene.Ctrl
{
    public class Ctrl_SelectPanel : MonoBehaviour
    {
        private static Ctrl_SelectPanel instance;
        public static Ctrl_SelectPanel Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(Ctrl_SelectPanel).ToString());
                    go.AddComponent<Ctrl_SelectPanel>();
                }
                return instance;
            }
        }
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("已经存在 " + this.GetType() + " 类型实例  删除当前物体");
                Destroy(gameObject);
                return;
            }
            instance = GetComponent<Ctrl_SelectPanel>();
        }


        public GameObject sowrd;
        public GameObject magic;
        public GameObject swordInfoImage;
        public GameObject magicInfoImage;


        public void OpenSowrdInfo()
        {
            sowrd.gameObject.SetActive(true);
            swordInfoImage.gameObject.SetActive(true);
        }
        public void CloseSowrdInfo()
        {
            sowrd.gameObject.SetActive(false);
            swordInfoImage.gameObject.SetActive(false);
        }

        public void OpenMagicInfo()
        {
            magic.SetActive(true);
            magicInfoImage.SetActive(true);
        }
        public void CloseMagicInfo()
        {
            magic.SetActive(false);
            magicInfoImage.SetActive(false);
        }
        

    }
}