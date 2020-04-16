using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public GameObject SoundOn;
    public GameObject Cross;
         
    void OnMouseUp()
    {

        if (Cross.activeInHierarchy)
        {
            Cross.SetActive(false);
        }
        else
        {
            Cross.SetActive(true);
        }
        
    }
}
