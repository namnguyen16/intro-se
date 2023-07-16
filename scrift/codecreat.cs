using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class codecreat : MonoBehaviour
{
    public InputField CodeInput;
    public Button CreatButton;

    ArrayList code;

    // Start is called before the first frame update
    void Start()
    {
        CreatButton.onClick.AddListener(writeStuffToFile);

        if (File.Exists(Application.dataPath + "/code.txt"))
        {
            code = new ArrayList(File.ReadAllLines(Application.dataPath + "/code.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/code.txt", "");
        }

    }

    void writeStuffToFile()
    {
        bool isExists = false;

        code = new ArrayList(File.ReadAllLines(Application.dataPath + "/code.txt"));
        foreach (var i in code)
        {
            if (i.ToString().Contains(CodeInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"code '{CodeInput.text}' already exists");
        }
        else
        {
            code.Add(CodeInput.text);
            File.WriteAllLines(Application.dataPath + "/code.txt", (String[])code.ToArray(typeof(string)));
            Debug.Log("Code created");
        }
    }
}
