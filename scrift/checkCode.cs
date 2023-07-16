using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checkCode : MonoBehaviour
{
    public InputField CodeInput;
    public Button CheckButton;
    public Button LogoutButton;

    ArrayList code;

    // Start is called before the first frame update
    void Start()
    {
        CheckButton.onClick.AddListener(login);
        LogoutButton.onClick.AddListener(moveToLogin);

        if (File.Exists(Application.dataPath + "/code.txt"))
        {
            code = new ArrayList(File.ReadAllLines(Application.dataPath + "/code.txt"));
        }
        else
        {
            Debug.Log("Code file doesn't exist");
        }

    }



    // Update is called once per frame
    void login()
    {
        bool isExists = false;

        code = new ArrayList(File.ReadAllLines(Application.dataPath + "/code.txt"));

        foreach (var i in code)
        {
            string line = i.ToString();
            //Debug.Log(line);
            //Debug.Log(line.Substring(11));
            //substring 0-indexof(:) - indexof(:)+1 - i.length-1
            if (i.ToString().Equals(CodeInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"correct code '{CodeInput.text}'");
            loadWelcomeScreen();
        }
        else
        {
            Debug.Log("Incorrect code");
        }
    }

    void moveToLogin()
    {
        SceneManager.LoadScene("Login");
    }

    void loadWelcomeScreen()
    {
        SceneManager.LoadScene("main play");
    }
}
