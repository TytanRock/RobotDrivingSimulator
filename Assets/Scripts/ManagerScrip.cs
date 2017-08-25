using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScrip : MonoBehaviour {

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, Screen.width / 6, Screen.height / 6), "Exit")) Application.Quit();
    }
}
