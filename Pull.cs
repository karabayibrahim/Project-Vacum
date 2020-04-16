using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull: MonoBehaviour
{
    public float Force = 200f;
    public float BlackForce;
    public bool PullCheck = false;
    public GameObject AnaKarak;
    //public GameObject DenemePartic;



    List<Rigidbody> rgballs = new List<Rigidbody>();
    List<Rigidbody> blballs = new List<Rigidbody>(); //Surprise bombaları , Blackler = Surprise
    List<Rigidbody> boomballs = new List<Rigidbody>();

    Transform CekimPoint;

   public  void Start()
    {
        CekimPoint = GetComponent<Transform>();
        AnaKarak = GameObject.FindGameObjectWithTag("HedefPoint");

    }
    public void FixedUpdate()
    {
        BallPull();
        BlackPull();
        BombPull();
        //Particledeneme();
        
        //foreach (Rigidbody rgball in rgballs)
        //{
        //    rgball.AddForce((CekimPoint.position - rgball.position) * Force * Time.deltaTime);
        //}
        //foreach (Rigidbody blball in blballs)
        //{
        //    blball.AddForce((CekimPoint.position - blball.position) * Force * Time.deltaTime);
        //}

    }
    
    public  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balls"))
        {
            rgballs.Add(other.GetComponent<Rigidbody>());
          

        }
        if (other.CompareTag("Black"))
        {
            blballs.Add(other.GetComponent<Rigidbody>());
        }
        if (other.CompareTag("Bomb"))
        {
            boomballs.Add(other.GetComponent<Rigidbody>());
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Balls") )
        {
            rgballs.Remove(other.GetComponent<Rigidbody>());
           
        }
        if (other.CompareTag("Black"))
        {
            blballs.Remove(other.GetComponent<Rigidbody>());
        }
        if (other.CompareTag("Bomb"))
        {
            boomballs.Remove(other.GetComponent<Rigidbody>());
        }
    }
    void BallPull()
    {
        if (Input.GetMouseButton(0))
        {
            PullCheck = true;
            
            foreach (Rigidbody rgball in rgballs)
            {
                rgball.AddForce((AnaKarak.transform.position - rgball.position) * Force * Time.deltaTime);
                
            }
           

        }
        else
        {
            PullCheck = false;
        }
        
    }
    void BlackPull()
    {
        if (Input.GetMouseButton(0))
        {
            PullCheck = true;
            foreach (Rigidbody blball in blballs)
            {
                blball.AddForce((AnaKarak.transform.position - blball.position) * BlackForce * Time.deltaTime);
                
            }
            
        }
        else
        {
            PullCheck = false;
        }
    }
    void BombPull()
    {
        if (Input.GetMouseButton(0))
        {
            PullCheck = true;

            foreach (Rigidbody boomball in boomballs)
            {
                boomball.AddForce((AnaKarak.transform.position - boomball.position) * BlackForce * Time.deltaTime);

            }

        }
        else
        {
            PullCheck = false;
        }
    }
   //void Particledeneme()
   // {
   //     if (Input.GetMouseButton(0)&&FindObjectOfType<PlayerTouch>().VakumAktifmi==true)
   //     {
   //         DenemePartic.SetActive(true);
   //     }
   //     else
   //     {
   //         DenemePartic.SetActive(false);
   //     }
   // }


}
