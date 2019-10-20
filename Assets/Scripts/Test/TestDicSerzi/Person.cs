using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private string name = " 11";
    [SerializeField] private int id = 1;
    [SerializeField] private List<int> list  = new List<int>();
    [SerializeField] private dictionaryOfIntAndInt dic = new dictionaryOfIntAndInt(); 

    private void Start()
    {
        
    }
    
}



//[CustomEditor(typeof(Person))]
public class PersonEditor : Editor
{
    private SerializedProperty nameProperty;
    private SerializedProperty idProperty;
    private SerializedProperty listProperty;


    private void OnEnable()
    {
        nameProperty = serializedObject.FindProperty("name");
        idProperty = serializedObject.FindProperty("id");
        listProperty = serializedObject.FindProperty("list");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        EditorGUILayout.PropertyField(nameProperty);
        EditorGUILayout.PropertyField(idProperty);
        EditorGUILayout.PropertyField(listProperty , true );


    }
}
