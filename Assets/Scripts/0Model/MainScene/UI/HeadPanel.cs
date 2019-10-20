using MainScene.Model;
using UnityEngine;
using UnityEngine.UI;


public class HeadPanel : MonoBehaviour
{
    public TextT playerNameTxet;
    public TextT currentHPTxet;
    public TextT maxHPTxet;
    public TextT currentMPTxet;
    public TextT maxMPTxet;
    public Slider hpSlider;
    public Slider mpSlider;
    public TextT levelTxet;


    private void OnEnable()
    {
        MessageCenter.AddListener<string>(GameEventType.NameChange, Name_Change);
        MessageCenter.AddListener<int>(GameEventType.HPChange, HP_Change);
        MessageCenter.AddListener<int>(GameEventType.MPChange, MP_Change);
    }
    private void OnDisable()
    {
        MessageCenter.RemoveListener<string>(GameEventType.NameChange, Name_Change);
        MessageCenter.RemoveListener<int>(GameEventType.HPChange, HP_Change);
        MessageCenter.RemoveListener<int>(GameEventType.MPChange, MP_Change);
    }
    private void Name_Change(string arg1)
    {
        playerNameTxet.text = arg1;
    }
    private void HP_Change(int arg1)
    {
        currentHPTxet.text = arg1.ToString();
        hpSlider.value = arg1 / float.Parse(maxHPTxet.text);
    }
    private void MP_Change(int arg1)
    {
        currentMPTxet.text = arg1.ToString();
        mpSlider.value = arg1 / float.Parse(maxMPTxet.text);
    }


    private void Awake()
    {
        maxHPTxet.text = "100";
        maxMPTxet.text = "100";
        levelTxet.text = "999";
    }


    private void Update()
    {
        //测试操作生命值
        if(Input.GetKeyDown ("a"))
        {
            PlayerData.Instance.AddHP(10); 
        }
        if (Input.GetKeyDown("b"))
        {
            PlayerData.Instance.AddMP(5);
        }
    }
}
