using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleTon<T> : MonoBehaviour where T : MonoSingleTon<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject(typeof(T).ToString());
                go.AddComponent<T>();
            }

            return instance;
        }
    }


    public virtual  void Awake()
    {
        if (instance != null)
        {
            //Debug.LogError("已经存在 " + this.GetType() + " 类型实例  删除当前物体");
            Destroy(gameObject);
            return;
        }
        
        instance = GetComponent<T>();
    }
    

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            //print(typeof(T) + "  实例已经被删除!");
        }
    }
    
}
