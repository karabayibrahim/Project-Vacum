using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextStage : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject obje;
    PlayerMovement code;
    GameObject obje2;
    CameraMovementScript codeCam;
    public bool kontrol = false;
    public bool kontrol2 = false;

    void Start()
    {
        
        obje = GameObject.FindGameObjectWithTag("Player");
        obje2 = GameObject.FindGameObjectWithTag("MainCamera");

        code = obje.GetComponent<PlayerMovement>();
        codeCam = obje2.GetComponent<CameraMovementScript>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            kontrol = true;
            //kontrol2 = true;
            code.AutomaticMoveSpeed = 50f;
            codeCam.CamAutoMoveSpeed = code.AutomaticMoveSpeed;
            

        }
        
       

    }
    
    
}
