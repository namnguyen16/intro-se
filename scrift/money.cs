using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class money : MonoBehaviour
{
    public InputField MoneyInputField;

    private string Money;

    private int mon;

    public void SubmitMoney()
    {
        Money = MoneyInputField.text;
        Debug.Log(Money);

        bool success = int.TryParse(Money, out mon);

        if(success)
        {
            if (mon>500000 && mon<1000000)
            {
                num.k = 1;
                SceneManager.LoadScene("main play");
            }

            if (mon>1000000 && mon <1500000)
            {
                num.k = 2;
                SceneManager.LoadScene("main play");
            }

            if (mon>1500000)
            {
                num.k = 3;
                SceneManager.LoadScene("main play");
            }
        }
    }
}
