using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetupController : MonoBehaviour
{
    public CharacterData data;
    public UIController_CharacterSetup uiController;

    public event InputConfirmed onInputConfirmed;

    // Start is called before the first frame update
    void Start()
    {
        if (data == null)
        {
            data = new CharacterData();
            //goto character creation screen
            onInputConfirmed += uiController.LoadNextScreen;

            return;
        }

        //goto game screen
    }
    
    public void RaiseInputConfirmed()
    {
        onInputConfirmed?.Invoke();
    }

    public void SetGender(int gender)
    {
        data.gender = gender;
        RaiseInputConfirmed();
    }

    public void SetCharacterName(string text)
    {
        data.playerName = text;
        uiController.SetCharacterNameBox(text);
    }

    public void SetCatName(string text)
    {
        data.catName = text;
    }
}

public delegate void InputConfirmed();

