using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class conscence : MonoBehaviour
{
    UIManager m_ui;
    private int random = pod.randomNum;
    public float delaySecond = 2;
    public string namescene = "main play";
    private string str;
    // Start is called before the first frame update

    
    void Start()
    {
        if (random > 10 && random < 14)
        {
            random -= 10;
            str= random + " Lượt";
            random += 10;
        }

        if (random > 0 && random < 10)
        {
            str = "hình " + random ;
        }

        if (random > 20 && random < 28)
        {
            random -= 20;
            str = "Voucher  " + random + "0%" ;
            random += 20;
        }
        m_ui = FindObjectOfType<UIManager> ();
        m_ui.SetNumPlay( "CHÚC MỪNG BẠN NHẬN ĐƯỢC " + str );
        ModeSelect();
    }

    // Update is called once per frame
    public void ModeSelect()
    {
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);

        SceneManager.LoadScene(namescene);
    }


}
