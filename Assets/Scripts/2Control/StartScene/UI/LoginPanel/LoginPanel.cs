using System;
using UnityEngine;
using UnityEngine.UI;

namespace StartScene.View
{
    public class LoginPanel : BaseUIPanel
    {
        public Button startBtn;



        private void Start()
        {

            startBtn.onClick.AddListener(delegate ()
            {
                FadeInAndOut.Instance.fadeRawImageState = FadeInAndOut.FadeRawImageState.FadeOut;
            });
        }

    }
}