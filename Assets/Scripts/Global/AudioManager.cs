using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject(typeof(AudioManager).ToString());
                go.AddComponent<AudioManager>();
            }
            return instance;
            #region 
            //GameObject audioMgr = GameObject.Find("AudioManager");
            //if (audioMgr == null)
            //{
            //    audioMgr = new GameObject("AudioManager");
            //}

            //if (instance == null)
            //{
            //    instance = audioMgr.GetComponent<AudioManager>();

            //    if (instance == null)
            //    {
            //        instance = audioMgr.AddComponent<AudioManager>();
            //    }
            //}
            //return instance;
            #endregion
        }
    }

    public List<AudioClip> allAudioList = new List<AudioClip>();
    public Dictionary<string, AudioClip> allAudioClipDic = new Dictionary<string, AudioClip>();




    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("已经存在 " + this.GetType() + " 类型实例  删除当前物体");
            Destroy(gameObject);
            return;
        }
        instance = GetComponent<AudioManager>();

        Init();  
    }

    private void Init()
    {
        for (int i = 0; i < allAudioList.Count; i++)
        {
            if (allAudioClipDic.ContainsKey(allAudioList[i].name))
            {
                Debug.Log("字典中已经存在该名字音频 " + allAudioList[i].name);
                continue;
            }

            allAudioClipDic.Add(allAudioList[i].name, allAudioList[i]);
        }
    }

    private void AddAudioClipToList(AudioClip audioClip)
    {
        if (allAudioList.Contains(audioClip))
        {
            Debug.Log("音频列表中已存在该音频");
            return;
        }

        allAudioList.Add(audioClip);
    }





    public void PlayAudioClip(AudioSource audioSource, string audioClipName, bool isLoop = false, float _volume = 1, float _pitch = 1)
    {
        AudioClip audioClip = null;

        if (allAudioClipDic.ContainsKey(audioClipName))
        {
            audioClip = allAudioClipDic[audioClipName];
        }
        else
        {
            Debug.Log("字典中不存在改名字音频: " + audioClipName);
            return;
        }


        if (audioClip != null && audioSource != null)
        {
            PlayAudioClip(audioSource, audioClip, isLoop, _volume, _pitch);
        }
    }

    public void PlayAudioClip(AudioSource audioSource, AudioClip audioClip, bool isLoop = false, float _volume = 1, float _pitch = 1)
    {
        if (audioSource.clip == audioClip)
        {
            return;
        }

        audioSource.volume = _volume;
        audioSource.pitch = _pitch;


        if (audioClip)
        {
            audioSource.loop = isLoop;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("audioClip == null !!");
        }
    }



    

    public void StopPlay(AudioSource audioSource)
    {
        audioSource.Stop();
    }

    public void PausePlay(AudioSource audioSource)
    {
        audioSource.Pause();
    }


}
