using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    private Slot[] slotList; 


	public virtual  void Start ()
    {
        slotList  = GetComponentsInChildren<Slot>();
	}

    //存储物品(将item放入物品槽)
    public bool StoreItem(int id)
    {
        Item item = InentoryManager.Instance.GetItemById(id);
        return StoreItem(item); 
    }

    public bool StoreItem(Item item)
    {
        if (item == null ) { Debug.LogError("要存储的物品为null");  return false ; }

        if( item.Capacity ==1 )
        {
            Slot slot = FindEmptySlot(); 
            if (slot == null )
            {
                Debug.LogError("没有空的物品槽来存放物品: " + item.Name);
                return false;
            }
            else
            {
                slot.StoreItem(item); 
            }
        }
        else
        {
            Slot slot = FindSameIDSlot(item);
            if (slot != null)  //找一个类型相同的物品槽 并且物品槽没有满
            {
                slot.StoreItem(item);
            }
            else   //没有找到, 找一个空的槽放进去
            {
                Slot emptySlot = FindEmptySlot();
                if (emptySlot == null)
                {
                    Debug.LogError("没有空的物品槽来存放物品: " + item.Name);
                    return false;
                }
                else
                {
                    emptySlot.StoreItem(item);
                }
            }
        }

        return true;
    }


    /// <summary>
    /// 寻找所有物品槽中空的物品槽
    /// </summary>
    private Slot  FindEmptySlot ()
    {
        for (int i = 0; i < slotList .Length  ; i++)
        {
            if (slotList [i].transform .childCount ==0)
            {
                return slotList[i];
            }
        }
        return null; 
    }
    /// <summary>
    /// 找到相同ID的物品槽 
    /// </summary>
    private  Slot FindSameIDSlot (Item item)
    {
        for (int i = 0; i < slotList.Length; i++)
        {
            if (slotList [i].transform .childCount >= 1 && slotList [i].GetItemID () == item.ID   && slotList[i].IsFilled () ==false )
            {
                return slotList[i];
            }
        }
        return null; 
    }
}
