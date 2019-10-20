using UnityEngine;

public class BaseUI : MonoBehaviour
{

    public virtual void OpenPanel()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HidePanel()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void MoveToTop()
    {
        this.transform.SetAsLastSibling();
    }

    public virtual void MoveToBottom()
    {
        this.transform.SetAsLastSibling();
    }

}
