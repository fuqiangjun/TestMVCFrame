using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;





public enum GameEventType
{
    NameChange , HPChange , MPChange , AttackChange , DefenceChange
}


public delegate void Callback(); 
public delegate void Callback<T> ( T arg1 ); 
public delegate void Callback<T1,T2> ( T1 arg1 ,T2 arg2); 



public class MessageCenter
{

    public static Dictionary<GameEventType, Delegate> mEventTable = new Dictionary<GameEventType, Delegate>();


    public static void AddListener (GameEventType  eventType , Callback handler)
    {
        if(!IsCanAddListener (eventType , handler ))
        {
            return;
        }

        //同一個委托可以注冊多個方法
        mEventTable[eventType]  =  (Callback ) mEventTable[eventType] + handler;
    }
    
    public static void AddListener<T> (GameEventType  eventType , Callback<T>  handler)
    {
        if (!IsCanAddListener(eventType, handler))
        {
            return;
        }
        
        mEventTable[eventType] = (Callback<T>)mEventTable[eventType] + handler;
    }
    public static void AddListener<T1,T2> (GameEventType  eventType , Callback<T1,T2>  handler)
    {
        if (!IsCanAddListener(eventType, handler))
        {
            return;
        }
        
        mEventTable[eventType] = (Callback<T1,T2 >)mEventTable[eventType] + handler;
    }
    private static   bool IsCanAddListener (GameEventType eventType  , Delegate  handler )
    {
        //字典是否存在 eventType值 類型 , 沒有就添加
        if (!mEventTable .ContainsKey (eventType)) 
        {
            mEventTable.Add(eventType, null );
        }

        Delegate d = mEventTable[eventType];

        //如果d的類型 != 傳入參數handler的類型 , 表示不餓能添加
        if (d != null &&  d.GetType () != handler.GetType())
        {
            Debug.Log(eventType+  " 加入監聽回調與當前監聽類型不符合,  當前類型:" + d.GetType().Name + " , 加入類型:" + handler.GetType().Name);
            return false; 
        }

        return true; 
    }




    public static void RemoveListener (GameEventType eventType , Callback handler )
    {
        if(!IsCanRemoveListener (eventType , handler ))
        {
            return; 
        }

        mEventTable[eventType] = (Callback)mEventTable[eventType] - handler; 

        if(mEventTable [eventType ] == null )
        {
            mEventTable.Remove(eventType); 
        }
    }
    
    public static void RemoveListener<T> (GameEventType eventType, Callback<T> handler)
    {
        if (!IsCanRemoveListener(eventType, handler))
        {
            return;
        }

        mEventTable[eventType] = (Callback<T>)mEventTable[eventType] - handler;

        if (mEventTable[eventType] == null)
        {
            mEventTable.Remove(eventType);
        }
    }
    
    public static void RemoveListener<T1 ,T2> (GameEventType eventType, Callback<T1, T2 > handler)
    {
        if (!IsCanRemoveListener(eventType, handler))
        {
            return;
        }

        mEventTable[eventType] = (Callback<T1 ,T2 >)mEventTable[eventType] - handler;

        if (mEventTable[eventType] == null)
        {
            mEventTable.Remove(eventType);
        }
    }
    public static  bool  IsCanRemoveListener(GameEventType eventType, Delegate  handler)
    {
        if(mEventTable .ContainsKey(eventType))
        {
            Delegate d = mEventTable[eventType]; 

            if(d == null )
            {
                Debug.Log("試圖移除的 " + eventType + " , 但當前監聽為空");
                return false;
            }
            else if (d .GetType () != handler .GetType ())
            {
                Debug.Log ("試圖移除的 " + eventType + " , 與當前類型 " + d.GetType () .Name + " 不服和");

                return false; 
            }
        }
        else
        {
            Debug.Log("MessageManager 不包含要移除的對象 " + eventType);
            return false;
        }

        return true; 
    }




    public static void Broadcast (GameEventType eventType )
    {
        if(!mEventTable .ContainsKey (eventType ) )
        {
            return; 
        }

        Delegate d; 
        if(mEventTable .TryGetValue (eventType , out d  ) )
        {
            Callback call = d as Callback; 

            if(call != null )
            {
                call(); 
            }
            else
            {
                Debug.Log("廣播 " + eventType + " 報錯") ;
            }
        }
    }
    
    public static void Broadcast<T>(GameEventType eventType , T arg1)
    {
        if (!mEventTable.ContainsKey(eventType))
        {
            return;
        }

        Delegate d;
        if (mEventTable.TryGetValue(eventType, out d))
        {
            Callback<T>  call = d as Callback<T> ;

            if (call != null)
            {
                call(arg1 );
            }
            else
            {
                Debug.Log("廣播 " + eventType + " 報錯");
            }
        }
    }
    
    public static void Broadcast<T1,T2>(GameEventType eventType , T1 arg1 ,T2 arg2 )
    {
        if (!mEventTable.ContainsKey(eventType))
        {
            return;
        }

        Delegate d;
        if (mEventTable.TryGetValue(eventType, out d))
        {
            Callback<T1, T2>  call = d as Callback<T1, T2> ;

            if (call != null)
            {
                call(arg1 ,arg2 );
            }
            else
            {
                Debug.Log("廣播 " + eventType + " 報錯");
            }
        }
    }
}
