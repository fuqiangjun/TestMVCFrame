using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ParseItemJson
{
    public  ItemList itemList;

    public ParseItemJson ()
    {
        itemList = new ItemList();
    }


    public ItemList ParseItem_Json()
    {
        //去内存读取 或 服务器读取
        //TextAsset t = Resources.Load<TextAsset>("Items4");
        //string itemsJson = t.text;
        string itemsJson = File.ReadAllText(Application.streamingAssetsPath + "/Items4.json");
        itemList = JsonConvert.DeserializeObject<ItemList>(itemsJson);
        return itemList;
    }
    public ItemList ParseItem_Json(string jsonPath)
    {
        string itemsJson = File.ReadAllText(jsonPath);
        itemList = JsonConvert.DeserializeObject<ItemList>(itemsJson);
        return itemList;
    }

    public string SaveItem_Json()
    {
        Consumable c = new Consumable(0, "0", Item.ItemType.Consumable, Item.ItemQuality.Common, "0", 0, 0, 0, "0", 0, 0);
        List<Consumable> cList = new List<Consumable>() { c };
        string s = JsonConvert.SerializeObject(cList);
        Debug.Log("s  = " + s);
        return s;
    }
}
