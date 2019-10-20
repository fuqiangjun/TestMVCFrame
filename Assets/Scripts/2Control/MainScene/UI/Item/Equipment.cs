using System;
using UnityEngine;


/// <summary>
/// 装备类
/// </summary>
[Serializable]
public class Equipment : Item
{
    [SerializeField] private int _strength;
    [SerializeField] private int _intellect;
    [SerializeField] private int _agility;
    [SerializeField] private int _stamina;
    [SerializeField] private EquipmentType _equipType;

    /// <summary>
    /// 力量
    /// </summary>
    public int Strength
    {
        get
        {
            return _strength;
        }
        set
        {
            _strength = value;
        }
    }
    /// <summary>
    /// 智力
    /// </summary>
    public int Intellect
    {
        get
        {
            return _intellect;
        }
        set
        {
            _intellect = value;
        }
    }
    /// <summary>
    /// 敏捷
    /// </summary>
    public int Agility
    {
        get
        {
            return _agility;
        }
        set
        {
            _agility = value;
        }
    }
    /// <summary>
    /// 体力
    /// </summary>
    public int Stamina
    {
        get
        {
            return _stamina;
        }
        set
        {
            _stamina = value;
        }
    }
    /// <summary>
    /// 装备类型
    /// </summary>
    public EquipmentType EquipType
    {
        get
        {
            return _equipType; 
        }
        set
        {
            _equipType = value;
        }
    }



    public Equipment(int _id, string _name, ItemType _itemType, ItemQuality _quality, string _description,
            int _capacity, int _buyPrice, int _sellPrice, string _spritePath,
                 int _strength, int _intellect, int _agility, int _stamina, EquipmentType _equipType)
                      : base(_id, _name, _itemType, _quality, _description, _capacity, _buyPrice, _sellPrice, _spritePath)
    {
        Strength = _strength;
        Intellect = _intellect;
        Agility = _agility;
        Stamina = _stamina;
        EquipType = _equipType;
    }


    /// <summary>
    /// 装备类型枚举
    /// </summary>
    public enum EquipmentType
    {
        /// <summary>
        /// 头
        /// </summary>
        Head,
        /// <summary>
        /// 脖子
        /// </summary>
        Neck,
        /// <summary>
        /// 胸部
        /// </summary>
        Chest,
        /// <summary>
        /// 戒子
        /// </summary>
        Ring,
        /// <summary>
        /// 腿
        /// </summary>
        Leg,
        /// <summary>
        /// 护腕
        /// </summary>
        Bracer,
        /// <summary>
        /// 鞋子
        /// </summary>
        Boots,
        /// <summary>
        /// 肩膀
        /// </summary>
        Shoulder,
        /// <summary>
        /// 腰带
        /// </summary>
        Belt,
        /// <summary>
        /// 护手
        /// </summary>
        OffHand
    }
}
