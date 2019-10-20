using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

/// <summary>
/// 下載ab包:
///         1.從本地下載: 使用AssetBundle.LoadFromFile(path);
///         2.服務器使用tcp協議,我們利用tcp協議把assetbundle下載下來,得到的就是一個byte數組
///             這個時候就使用 AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes("path")) , 或者將byte數組存到本地,在進行讀取
///         3.WWW下載    
/// </summary>
public class AssetBundleLoad : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(Test1_1());
        //Test1(); 


        //StartCoroutine (Test2()); 
        //Test2_1();


        //StartCoroutine(Test3());
        //StartCoroutine(Test3_2());
        StartCoroutine(Test3_3());


        //StartCoroutine(Test4()); 
        //StartCoroutine(Test4_2()); 
    }


    /// <summary>
    /// 第一種加載資源的方式 LoadFromFile從本地下載
    /// </summary>
    private void Test1()
    {
        string dir = Application.dataPath + "/AssetBundles/Scenes/cubewall.unity3d";
        string mat = Application.dataPath + "/AssetBundles/share.unity3d";

        AssetBundle abPre = AssetBundle.LoadFromFile(dir);
        AssetBundle abMat = AssetBundle.LoadFromFile(mat);

        GameObject g = abPre.LoadAsset<GameObject>("cubewall");
        GameObject go = Instantiate(g);
    }

    /// <summary>
    /// 第一種加載資源的方式 異步加載
    /// </summary>
    private IEnumerator Test1_1()
    {
        string dir = Application.dataPath + "/AssetBundles/Scenes/cubewall.unity3d";
        string mat = Application.dataPath + "/AssetBundles/share.unity3d";

        AssetBundleCreateRequest request1 = AssetBundle.LoadFromFileAsync(dir);
        AssetBundleCreateRequest request2 = AssetBundle.LoadFromFileAsync(mat);
        yield return request1;
        yield return request2;

        AssetBundle ab = request1.assetBundle;
        GameObject g = ab.LoadAsset<GameObject>("cubewall");
        GameObject go = Instantiate(g);
    }



    /// <summary>
    /// 第二種加載資源的方式  AssetBundle.LoadFromMemoryAsync()
    /// </summary>
    private IEnumerator Test2()
    {
        string path = Application.dataPath + "/AssetBundles/Scenes/cubewall.unity3d";

        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path)); //異步的方式要等待加載完成
        yield return request;

        //使用裏面的資源
        AssetBundle ab = request.assetBundle;
        GameObject g = ab.LoadAsset<GameObject>("cubewall");
        GameObject go = Instantiate(g);
    }

    /// <summary>
    /// 第二種加載資源的方式  AssetBundle.LoadFromMemory()
    /// </summary>
    private void Test2_1()
    {
        string path = Application.dataPath + "/AssetBundles/Scenes/cubewall.unity3d";

        AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path)); //同步的方式

        GameObject g = ab.LoadAsset<GameObject>("cubewall");
        GameObject go = Instantiate(g);
    }



    /// <summary>
    /// 第三種加載方式  www加載
    /// </summary>
    private IEnumerator Test3()
    {
        Debug.Log("WWW通過本地加載!");
        string path = @"file://F:/2019Project/AssetBundleTest/Assets/AssetBundles/scenes/cubewall.unity3d";

        while (Caching.ready == false )
        {
            yield return null; 
        }

        WWW www  =  WWW.LoadFromCacheOrDownload(path, 1);
        yield return www;

        if (string .IsNullOrEmpty ( www.error) ==false  )
        {
            Debug.Log("www錯誤:  " + www.error);
            yield break; 
        }


        AssetBundle ab = www.assetBundle;

        GameObject g = ab.LoadAsset<GameObject>("cubewall");
        VideoClip v = ab.LoadAsset<VideoClip>("aa");
        GameObject go = Instantiate(g);
    }
    /// <summary>
    /// WWW下載  通過http協議
    /// </summary>
    /// <returns></returns>
    public IEnumerator Test3_2()
    {
        Debug.Log("WWW通過http協議從服務器端加載!");

        string path = "http://localhost/AssetBundles/cubewall.unity3d";

        while (Caching.ready == false) //等待缓存系统就绪
        {
            yield return null;
        }

        WWW www = WWW.LoadFromCacheOrDownload(path, 1);
        yield return www;

        if (string.IsNullOrEmpty(www.error) == false)
        {
            Debug.Log("www錯誤:  " + www.error);
            yield break;
        }


        AssetBundle ab = www.assetBundle;

        GameObject g = ab.LoadAsset<GameObject>("cubewall");
        GameObject go = Instantiate(g);
    }
    /// <summary>
    /// WWW 下載百度圖片
    /// </summary>
    /// <returns></returns>
    public IEnumerator Test3_3 ()
    {
        string uri = "http://a0.att.hudong.com/51/15/01300000165488121534157931952.jpg";

        WWW www = new WWW(uri);
        yield return www;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); 
        cube .GetComponent<Renderer>().material.mainTexture = www.texture;
    }





    /// <summary>
    /// 第四種加載方式  UnityWebRequest下載 取代WWW的  
    /// </summary>
    public IEnumerator Test4()
    {
        Debug.Log("UnityWebRequest本地下載");

        string uri  = "file://F:/2019Project/AssetBundleTest/Assets/AssetBundles/scenes/cubewall.unity3d";

        UnityWebRequest request =  UnityWebRequestAssetBundle.GetAssetBundle(uri); //下載并沒有開始下載

        yield return request.SendWebRequest();
        //yield return request.Send(); 

        AssetBundle ab  =  DownloadHandlerAssetBundle.GetContent(request); //第一種得到AssetBundle的方式
        //AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;//第二種得到AssetBundle的方式

        GameObject g = ab.LoadAsset<GameObject>("cubewall");
        GameObject go = Instantiate(g);
    }
    /// <summary>
    /// 第四種加載方式  UnityWebRequest從服務器端下載
    /// </summary>
    public IEnumerator Test4_2()
    {
        Debug.Log("UnityWebRequest從服務器端下載");

        string uri = "http://localhost/AssetBundles/cubewall.unity3d";

        UnityWebRequest request =  UnityWebRequestAssetBundle.GetAssetBundle(uri); 

        yield return request.SendWebRequest();
        //yield return request.Send(); 

        AssetBundle ab  =  DownloadHandlerAssetBundle.GetContent(request); //第一種得到AssetBundle的方式
        //AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;//第二種得到AssetBundle的方式

        //將ab保存到本地
        //File.WriteAllBytes  request .downloadHandler.data 

        GameObject g = ab.LoadAsset<GameObject>("cubewall");
        GameObject go = Instantiate(g);
    }

}
