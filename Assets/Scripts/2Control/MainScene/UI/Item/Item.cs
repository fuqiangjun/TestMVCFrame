using System;
using UnityEngine;


/// <summary>
/// 物品基类
/// </summary>
[Serializable]
public class Item
{
    #region 
    [SerializeField] private int _iD;
    [SerializeField] private string _name;
    [SerializeField] private ItemType _type_;
    [SerializeField] private ItemQuality _quality_;
    [SerializeField] private string _description;
    [SerializeField] private int _capacity;
    [SerializeField] private int _buyPrice;
    [SerializeField] private int _sellPrice;
    [SerializeField] private string _sprite;

    /// <summary>
    /// 物品ID
    /// </summary>
    public int ID
    {
        get
        {
            return _iD;
        }
        set
        {
            _iD = value;
        }
    }
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    /// <summary>
    /// 物品类型
    /// </summary>
    public ItemType Type_
    {
        get
        {
            return _type_;
        }
        set
        {
            _type_ = value;
        }
    }
    /// <summary>
    /// 物品品质
    /// </summary>
    public ItemQuality Quality_
    {
        get
        {
            return _quality_;
        }
        set
        {
            _quality_ = value;
        }
    }
    /// <summary>
    /// 物品描述
    /// </summary>
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
    /// <summary>
    /// 容量
    /// </summary>
    public int Capacity
    {
        get
        {
            return _capacity;
        }
        set
        {
            _capacity = value;
        }
    }
    /// <summary>
    /// 购买价格
    /// </summary>
    public int BuyPrice
    {
        get
        {
            return _buyPrice;
        }
        set
        {
            _buyPrice = value;
        }
    }
    /// <summary>
    /// 卖出价格
    /// </summary>
    public int SellPrice
    {
        get
        {
            return _sellPrice;
        }
        set
        {
            _sellPrice = value;
        }
    }
    /// <summary>
    /// 物品图标的路径
    /// </summary>
    public string Sprite
    {
        get
        {
            return _sprite;
        }
        set
        {
            _sprite = value;
        }
    }
    #endregion


    public Item()
    {
        ID = -1;
    }

    public Item(int _id, string _name, ItemType _itemType, ItemQuality _quality, string _description,
            int _capacity, int _buyPrice, int _sellPrice, string _spritePath)
    {
        ID = _id;
        Name = _name;
        Type_ = _itemType;
        Quality_ = _quality;
        Description = _description;
        Capacity = _capacity;
        BuyPrice = _buyPrice;
        SellPrice = _sellPrice;
        Sprite = _spritePath;
    }


    #region  枚举
    /// <summary>
    /// 物品类型枚举
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// 消耗品
        /// </summary>
        Consumable,
        /// <summary>
        /// 装备
        /// </summary>
        Equipment,
        /// <summary>
        /// 武器
        /// </summary>
        Weapon,
        /// <summary>
        /// 材料
        /// </summary>
        Material
    }

    /// <summary>
    /// 物品品质枚举
    /// </summary>
    public enum ItemQuality
    {
        /// <summary>
        /// 常见的
        /// </summary>
        Common,
        /// <summary>
        /// 不常见的
        /// </summary>
        Unmmon,
        /// <summary>
        /// 稀有的
        /// </summary>
        Rare,
        /// <summary>
        /// 史诗
        /// </summary>
        Epic,
        /// <summary>
        /// 传说
        /// </summary>
        Legendary,
        /// <summary>
        /// 远古
        /// </summary>
        Artifact
    }

    #endregion


    /// <summary>
    /// 得到提示面板应该显示什么内容
    /// </summary>
    public virtual string GetToolTipText ()
    {
        return Name; 
    }
}
