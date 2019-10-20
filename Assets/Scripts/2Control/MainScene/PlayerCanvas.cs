using MainScene.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCanvas : MonoBehaviour
{
    public TextT playerName;
    public Transform targetCamera;


	void Start ()
    {
        playerName.text = PlayerData.Instance.Name;
        targetCamera = GameObject.Find("Main Camera").transform; 
        //Debug.Log(targetCamera.gameObject); 
    }
	

	void Update ()
    {
        this.transform.LookAt(targetCamera);
	}
}
