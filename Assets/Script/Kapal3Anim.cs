using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapal3Anim : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {  
            anim.SetTrigger("kapal3Shove");
            AudioManager.Instance.Shove();
        }
    }
}
