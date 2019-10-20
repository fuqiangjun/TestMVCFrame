using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat : Item
{

    public Mat(int _id, string _name, ItemType _itemType, ItemQuality _quality, string _description,
          int _capacity, int _buyPrice, int _sellPrice, string _spritePath)
                   : base(_id, _name, _itemType, _quality, _description, _capacity, _buyPrice, _sellPrice, _spritePath)
    {
        
    }
}
