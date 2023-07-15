using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenceChange : MonoBehaviour
{
    public string scencename;


    public void OnButtonClicked()
    {
        SceneManager.LoadScene(scencename);
    }

    public void OnButtonClicked2()
    {
        SceneManager.LoadScene("input");
    }

}
