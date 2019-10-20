using UnityEngine;

public class ChangeCursor : MonoBehaviour
{

    public Texture2D cursor1;
    public Texture2D cursor2;
    public Texture2D cursor3;

    private void Start()
    {

    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    SetCursor(cursor1, Vector2.zero, CursorMode.Auto);
        //}
    }


    public void SetCursor(Texture2D texture2D, Vector2 v, CursorMode cursorMode)
    {
        Cursor.SetCursor(texture2D, v, cursorMode);
    }
}
