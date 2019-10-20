using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// 物品槽
/// </summary>
public class Slot : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public GameObject itemPrefab;

    /// <summary>
    /// 存储物品(把物品存入当前空物品槽里面)
    /// 如果自身下面已经有item , amount++
    /// 如果没有 根据itemprefab去实例化一个item 放在下面
    /// </summary>
    public void StoreItem(Item item)
    {
        if (transform .childCount  == 0 )
        {
            GameObject itemObj =  Instantiate(itemPrefab);
            itemObj.transform.SetParent(this.transform);
            itemObj.transform.localPosition = Vector3.zero;
            itemObj.transform.localRotation = Quaternion.identity;
            itemObj.transform.localScale = Vector3.one; 
            itemObj.GetComponent<ItemUI>().SetItem(item, 1);
        }
        else
        {
            this.transform.GetChild(0).GetComponent<ItemUI>().AddAmount();
        }
    }


    /// <summary>
    /// 得到当前物品槽存储的物品类型
    /// </summary>
    public Item.ItemType  GetItemType ()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.Type_;
    }
    /// <summary>
    /// 得到当前物品槽存储的物品ID
    /// </summary>
    public int GetItemID ()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.ID;
    }


    /// <summary>
    /// 判断物品槽是否已经满了
    /// </summary>
    public bool  IsFilled ()
    {
        ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();

        return itemUI.Amount >= itemUI.Item.Capacity;  //当前数量>=item的容量
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform .childCount >0)
        {
            string toolTipText = transform.GetChild(0).GetComponent<ItemUI>().Item.GetToolTipText();
            InentoryManager.Instance.ShowToolTip(toolTipText);
        }
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            InentoryManager.Instance.HideToolTip();
        }
    }

}
