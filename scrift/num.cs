using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class num : MonoBehaviour
{
    public static int k = 100;


    public static List<string> objectList = new List<string>() ;
    // Start is called before the first frame update
    public static void NUM()
    {
        k = pod.numplay;
    }

    public static void delete()
    {
        foreach (string obj in objectList)
        {
            Destroy(GameObject.Find(obj));
        }
    }
    
}
