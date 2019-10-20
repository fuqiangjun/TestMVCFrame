using StartScene.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StartScene
{
    public class UIManager : MonoSingleTon <UIManager >
    {
        public LoginPanel loginPanel;
        public View_SelectPanel view_SelectPanel;


        public void OpenLoginPanel ()
        {
            loginPanel.OpenPanel();
            view_SelectPanel.HidePanel(); 
        }

        public void OpenSelectPanel ()
        {
            loginPanel.HidePanel();
            view_SelectPanel.OpenPanel();
            view_SelectPanel.OpenSowrdInfo();
        }
        
    }
}