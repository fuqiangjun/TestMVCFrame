using UnityEngine;
using UnityEngine.UI;


public class ToolTip : MonoBehaviour
{
    private TextT toolText;
    private TextT contentText;
    private CanvasGroup canvasGroup;
    private  float targetAlpha = 0;
    private float smoothing = 4;
    private RectTransform rect;
    private Vector3 offset = new Vector3(50, -50, 0);

    private void Start()
    {
        toolText = GetComponent<TextT>();
        contentText = transform.Find("Conteent").GetComponent<TextT>();
        canvasGroup = GetComponent<CanvasGroup>();
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);

            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.05f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }

    }

    public void Show(string _content)
    {
        targetAlpha = 1;
        toolText.text = _content;
        contentText.text = _content;
    }

    public void Hide()
    {
        targetAlpha = 0;
    }

    public void SetLocalPosition(Vector3 position)
    {
        rect.anchoredPosition = position + offset;
    }
}
