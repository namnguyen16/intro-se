using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rod : MonoBehaviour
{
    [SerializeField]
    private string _tag; //loại
    public float slowDown; // cân nặng
    public int[] gift ;// 1-> 9: tranh, 11->13: them luot, 21->27: giam gia

     
   void Awake()
   {
        this.tag = _tag;
   }
}
