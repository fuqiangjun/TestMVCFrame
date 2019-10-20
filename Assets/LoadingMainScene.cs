using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingMainScene : MonoBehaviour
{
    [SerializeField ] private  float loadSpeed = 0.01f;
    [SerializeField] private float lerpSpeed = 1;
    public Text text; 
    public Slider slider;
    private AsyncOperation op;


    private void Start()
    {
        StartCoroutine(StartLoading());
    }
    private IEnumerator StartLoading()
    {
        slider.value = 0;

        op = SceneManager.LoadSceneAsync("MainScene");
        op.allowSceneActivation = false;
        yield return null; 
    }


    private void Update()
    {
        if (op.progress >= 0.9f)
        {
            slider.value = Mathf.Lerp(slider.value, 1, Time.deltaTime * lerpSpeed);

            if (Mathf.Abs(slider.value - 1) < 0.02f)
            {
                slider.value = 1;
            }
        }
        else
        {
            slider.value += (Time.deltaTime * loadSpeed);
        }

        text.text = (slider.value*100).ToString("f0") + "/100" ;

        
        if (slider .value  == 1 )
        {
            op.allowSceneActivation = true; 
        }
 
    }
}
