using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    UIManager m_ui;
    UIManager1 m_ui1;
    private string _voucher = pod.strVoucher;
    private string _image = pod.strImage;

    // Start is called before the first frame update
    void Start()
    {
        m_ui = FindObjectOfType<UIManager> ();
        m_ui.SetNumPlay(_voucher);

        m_ui1 = FindObjectOfType<UIManager1> ();
        m_ui1.SetNumPlay(_image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
