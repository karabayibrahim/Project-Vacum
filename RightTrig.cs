using System.Collections.Generic;
using UnityEngine;

public class RightTrig : MonoBehaviour
{ 
    public float AutomaticMoveSpeed = 2;
    public bool Kontrol = false;


    public void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.CompareTag("Engel"))
        {
            Kontrol = true;
            
        }
    }
    void FixedUpdate()
    {
        //if (Kontrol==true)
        //{
        //    FindObjectOfType<EngelScript>().CancelInvoke("RightMovent");
        //    FindObjectOfType<EngelScript>().LeftMovement();
        //}




    }
}

