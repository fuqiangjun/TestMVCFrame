using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 可序列化字典
/// </summary>
public class SerializableDictionary<TK, TV> : Dictionary<TK, TV>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TK> keys = new List<TK>();
    [SerializeField] private List<TV> values = new List<TV>();

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        foreach (KeyValuePair<TK, TV> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();

        if (keys.Count != values.Count)
        {
            Debug.LogErrorFormat("keys个数{0} 与values个数{1}不等", keys.Count, values.Count);
        }

        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}


[System.Serializable]
public class dictionaryOfIntAndInt : SerializableDictionary<int, int>
{

}




