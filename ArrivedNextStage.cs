using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivedNextStage : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject obje;
    PlayerMovement code;
    GameObject obje2;
    CameraMovementScript codeCam;
    float sayac = 8;
    bool AzalmaKontrol = false;
    
    
    void Start()
    {
        obje = GameObject.FindGameObjectWithTag("Player");
        code = obje.GetComponent<PlayerMovement>();
        obje2 = GameObject.FindGameObjectWithTag("MainCamera");
        codeCam = obje2.GetComponent<CameraMovementScript>();

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (AzalmaKontrol)
    //    {
    //        Azalma();
    //    }
    //}

    public void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {

            code.AutomaticMoveSpeed = 4f;
            codeCam.CamAutoMoveSpeed = code.AutomaticMoveSpeed;
           

        }
        //else if (FindObjectOfType<PlayerTouch>().HizlanmaKontrol == true)
        //{
        //    if (FindObjectOfType<ToNextStage>().kontrol2 == true)
        //    {
        //        code.AutomaticMoveSpeed = 8f;
                
        //        codeCam.CamAutoMoveSpeed = code.AutomaticMoveSpeed;
        //    }
        //}

    }
    
}
