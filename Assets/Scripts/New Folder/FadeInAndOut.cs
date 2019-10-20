using StartScene;
using UnityEngine;
using UnityEngine.UI;




public class FadeInAndOut : MonoBehaviour
{
    public enum FadeRawImageState
    {
        None, FadeIn, FadeOut
    }
    private static FadeInAndOut instance = null;
    public static FadeInAndOut Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject(typeof(FadeInAndOut).ToString());
                go.AddComponent<FadeInAndOut>();
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
        instance = GetComponent<FadeInAndOut>();

    }



    public RawImage _RawImage;
    public float FloColorChangeSpeed = 2;
    private bool isFadeInFinish = false;
    private bool isFadeOutFinish = false;
    public FadeRawImageState fadeRawImageState = FadeRawImageState.None;


    private void Start()
    {
        InitFadeRawImageState();
    }
    public void InitFadeRawImageState()
    {
        fadeRawImageState = FadeRawImageState.FadeIn;
    }


    private void Update()
    {
        switch (fadeRawImageState)
        {
            case FadeRawImageState.None:
                break;
            case FadeRawImageState.FadeIn:
                ScenesFadeIn();
                break;
            case FadeRawImageState.FadeOut:
                ScenesFadeOut();
                break;
            default:
                break;
        }
    }



    /// <summary>
    /// 场景淡入
    /// </summary>
    private void ScenesFadeIn()
    {
        if (isFadeInFinish) { return; }

        if (!_RawImage.gameObject.activeInHierarchy)
        {
            _RawImage.gameObject.SetActive(true);
        }

        _RawImage.color = Color.Lerp(_RawImage.color, Color.clear, FloColorChangeSpeed * Time.deltaTime);

        if (_RawImage.color.a <= 0.05)
        {
            _RawImage.color = Color.clear;

            ScenesFadeInFinish();
        }
    }

    private void ScenesFadeInFinish()
    {
        Debug.Log("场景淡入完成");
        _RawImage.gameObject.SetActive(false);
        isFadeInFinish = true;
    }

    /// <summary>
    /// 场景淡出
    /// </summary>
    private void ScenesFadeOut()
    {
        if (isFadeOutFinish) { return; }

        if (!_RawImage.gameObject.activeInHierarchy)
        {
            _RawImage.gameObject.SetActive(true);
        }

        _RawImage.color = Color.Lerp(_RawImage.color, Color.black, FloColorChangeSpeed * Time.deltaTime);

        if (_RawImage.color.a >= 0.95)
        {
            _RawImage.color = Color.black;

            ScenesFadeOutFinish();
        }
    }

    private void ScenesFadeOutFinish()
    {
        Debug.Log("场景淡出完成");

        isFadeOutFinish = true;
        fadeRawImageState = FadeRawImageState.FadeIn;
        isFadeInFinish = false;

        UIManager.Instance.OpenSelectPanel();
    }


}
