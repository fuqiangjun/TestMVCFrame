using System;
using UnityEngine;


/// <summary>
/// 武器类
/// </summary>
[Serializable]
public class Weapon : Item
{
    [SerializeField] private int _demage;
    [SerializeField] private WeaponType _wpType;

    /// <summary>
    /// 武器攻击力
    /// </summary>
    public int Demage
    {
        get
        {
            return _demage;
        }
        set
        {
            _demage = value;
        }
    }
    /// <summary>
    /// 武器类型
    /// </summary>
    public WeaponType WpType
    {
        get
        {
            return _wpType;
        }
        set
        {
            _wpType = value;
        }
    }


    public Weapon(int _id, string _name, ItemType _itemType, ItemQuality _quality, string _description,
            int _capacity, int _buyPrice, int _sellPrice, string _spritePath
                 , int _demage, WeaponType _wpType)
                     : base(_id, _name, _itemType, _quality, _description, _capacity, _buyPrice, _sellPrice, _spritePath)
    {
        Demage = _demage;
        WpType = _wpType;
    }


    /// <summary>
    /// 武器类型枚举
    /// </summary>
    public enum WeaponType
    {
        /// <summary>
        /// 副手武器
        /// </summary>
        OffHand,
        /// <summary>
        /// 主手武器
        /// </summary>
        MainHand
    }
}
