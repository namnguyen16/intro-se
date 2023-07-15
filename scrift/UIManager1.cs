using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager1 : MonoBehaviour
{
   
    public TextMeshProUGUI numPlay;

   public void SetNumPlay(string txt)
   {
    if (numPlay)
        numPlay.text = txt;
   }
}
