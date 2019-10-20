using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InentoryManager : MonoSingleTon<InentoryManager >
{
    [Header ("所有物品")] public List<Item> itemList = new List<Item>();
    public List<Consumable> consumableList = new List<Consumable>();
    public List<Equipment> equipmentList = new List<Equipment>();
    public List<Weapon> weaponList = new List<Weapon>();
    //public List<Text > textList = new List<Text>();

    private ToolTip toolTip;
    private bool isToolShow = false;
    private Canvas canvas;


     
    private void Start()
    {
        toolTip = GameObject.Find("ToolTip").GetComponent<ToolTip>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        
        ParseItemJson();
        AddToitemList();
    }

    private void ParseItemJson()
    {
        ParseItemJson parseItemJson = new ParseItemJson();
        parseItemJson.ParseItem_Json();
        weaponList = parseItemJson.itemList.weaponList;
        equipmentList = parseItemJson.itemList.equipmentList;
        consumableList = parseItemJson.itemList.consumableList;
        //materialList = parseItemJson.itemList.materialList;
        Debug.Log("111111  " + parseItemJson.itemList.consumableList.Count ); // parseItemJson.itemList.materialList.Count);
    }
    void AddToitemList ()
    {
        for (int i = 0; i < consumableList.Count; i++)
        {
            itemList.Add(consumableList[i]);
        }

        for (int i = 0; i < equipmentList.Count; i++)
        {
            itemList.Add(equipmentList[i]);
        }

        for (int i = 0; i < weaponList.Count; i++)
        {
            itemList.Add(weaponList[i]);
        }
    }



    public Item GetItemById (int id )
    {
        for (int i = 0; i < itemList .Count ; i++)
        {
            if (itemList[i].ID  == id )
            {
                return itemList[i];
            }
        }
        return null; 
    }


    private void Update()
    {
        if (isToolShow )
        {
            Vector2 position;
            //得到鼠标在画布上的局部坐标
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera , out position);
            toolTip.SetLocalPosition(position);
        }
    }
    public void ShowToolTip (string content )
    {
        isToolShow = true;
        toolTip.Show (content);
    }
    public void HideToolTip ()
    {
        isToolShow = false;  
        toolTip.Hide();
    }
}
