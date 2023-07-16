using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playername : MonoBehaviour
{
    public InputField playerNameInputField;

    public static List<string> database = new List<string>() ;

    private string playerName;

    public void SubmitPlayerName()
    {
        playerName = playerNameInputField.text;
        Debug.Log(playerName);
        print(database[0]);
    }
}
