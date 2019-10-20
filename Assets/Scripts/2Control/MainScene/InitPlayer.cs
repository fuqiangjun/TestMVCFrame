using MainScene.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class InitPlayer : MonoBehaviour
{
    string path;


    private void Awake()
    {
       path = Path.Combine(Application.streamingAssetsPath, "PlayerData", "PlayerInfo.json");
        StartCoroutine(GetPlayerInfo(path , InitPlayerData));
    }
    private IEnumerator GetPlayerInfo(string path , Action callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(path))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                //Debug.Log("加载文件内容: " + request.downloadHandler.text);
                TempPlayer tempPlayer = JsonConvert.DeserializeObject<TempPlayer>(request.downloadHandler.text);
                PlayerData playerData = new PlayerData(tempPlayer.playerType, tempPlayer.name,
                    tempPlayer.hP, tempPlayer.mP, tempPlayer.attack, tempPlayer.defence);
                callback(); 
            }
        }
    }

    private void InitPlayerData()
    {
        CreateCharacterByType();


    }
    
   private void CreateCharacterByType ()
    {
        GameObject g = null;
        switch (PlayerData.Instance.Player_Type)
        {
            case PlayerType.None:
                break;
            case PlayerType.Sword:
                g = Resources.Load<GameObject>("Player/SwordHero");
                break;
            case PlayerType.Magic:
                g = Resources.Load<GameObject>("Player/MagicianHero");
                break;
            default:
                break;
        }
        GameObject go = Instantiate(g);
    }


    private void Start()
    {

    }


}
