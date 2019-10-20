using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 在 Assets 下添加菜单
// fileName: 生成文件名称, menuName: 菜单按钮名, order: 按钮显示顺序
[CreateAssetMenu(fileName = "T1", menuName = "CreateT1", order = 1)]
public class TestScriptableObject : ScriptableObject
{
    public string name = "fqj";
    public int id = 1; 
	
}
