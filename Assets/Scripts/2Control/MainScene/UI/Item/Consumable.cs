using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 消耗品类
/// </summary>
[Serializable]
public class Consumable : Item
{
   [SerializeField] private int hp;
   [SerializeField] private int mp;

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
    public int MP
    {
        get
        {
            return mp;
        }
        set
        {
            mp = value;
        }
    }

    public Consumable(int _id, string _name, ItemType _itemType, ItemQuality _quality, string _description,
            int _capacity, int _buyPrice, int _sellPrice, string _spritePath
                , int _hp, int _mp)
                     : base(_id, _name, _itemType, _quality, _description, _capacity, _buyPrice, _sellPrice, _spritePath)
    {
        HP = _hp;
        MP = _mp;
    }

}
