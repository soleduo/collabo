using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_CharacterSetup : MonoBehaviour
{
    public GameObject[] screens;
    public int activeScreen;

    public TMPro.TextMeshProUGUI activityTitle;
    public TMPro.TextMeshProUGUI nameBox;

    public void LoadNextScreen()
    {
        if (activeScreen >= screens.Length)
        {
            SetupEnd();
            return;
        }

        screens[activeScreen].SetActive(false);

        activeScreen++;

        if (activeScreen == 1)
            SetActivityTitle("Your Name");

        if (activeScreen > 1)
            activityTitle.gameObject.SetActive(false);

        screens[activeScreen].SetActive(true);
    }

    public void SetCharacterNameBox(string text)
    {
        nameBox.text = text;
    }

    public void SetActivityTitle(string text)
    {
        activityTitle.text = text;
    }

    public void SetupEnd() { }
}
