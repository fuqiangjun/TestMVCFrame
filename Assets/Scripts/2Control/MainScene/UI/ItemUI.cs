using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image imageItem;
    [SerializeField] private TextT amountText;
    [SerializeField] private Item item;
    [SerializeField] private int amount;
    public Item Item
    {
        get
        {
            return item;
        }
        set
        {
            item = value;
        }
    }
    public int Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
        }
    }
    public Image ImageItem
    {
        get
        {
            if (imageItem == null)
            {
                imageItem = GetComponent<Image>();
            }
            return imageItem;
        }
    }
    public TextT AmountText
    {
        get
        {
            if (amountText == null)
            {
                amountText = transform.Find("Amount").GetComponent<TextT>();
            }
            return amountText;
        }
    }



    public void SetItem(Item _item, int _amount = 1)
    {
        this.Item = _item;
        this.Amount = _amount;

        //更新显示UI
        ImageItem.sprite = Resources.Load<Sprite>(Item.Sprite);
        AmountText.text = Amount.ToString();  // "";
    }
    public void AddAmount(int _amount = 1)
    {
        this.Amount += _amount;

        AmountText.text = Amount.ToString();
    }

}
