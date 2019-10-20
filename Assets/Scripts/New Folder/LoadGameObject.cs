using UnityEngine;



public class LoadGameObject
{
    public static GameObject Load(string name)
    {
        GameObject go = null;
        GameObject g = Resources.Load<GameObject>(name);
        go = GameObject.Instantiate(g);
        return go;
    }
    
    public static GameObject Load(GameObject prefab)
    {
        GameObject go = null;
        go = GameObject.Instantiate(prefab);
        return go;
    }

    public static GameObject Load(string name, Vector3 pos, Vector3 rot, Transform parent = null)
    {
        GameObject go = null;
        GameObject g = Resources.Load<GameObject>(name);
        go = GameObject.Instantiate(g);
        if (parent != null)
        {
            go.transform.SetParent(parent);
        }
        go.transform.localPosition = pos;
        go.transform.localEulerAngles = rot;

        return go;
    }

    public static Sprite LoadSprite(string name)
    {
        Sprite s = Resources.Load<Sprite>(name);
        return s; 
    }


    public static T Load<T> (T t) where T : CharacterController  
    { 
        return (T)t; 
    }

}
