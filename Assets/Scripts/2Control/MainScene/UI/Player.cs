using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{


    void Start ()
    {
       

    }

    void Update () {
		if (Input.GetKeyDown("g"))
        {
            int id = UnityEngine.Random.Range(1, 18);
            Knapsack.Instance.StoreItem(id);
        }
	}
}
