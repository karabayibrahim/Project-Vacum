using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullSuper : MonoBehaviour
{
    public float Force = 200f;
    public float BlackForce;
    public bool PullCheckSuper = false;
    public GameObject AnaKarak;



    List<Rigidbody> rgballs = new List<Rigidbody>();
    //List<Rigidbody> blballs = new List<Rigidbody>(); //Surprise bombaları , Blackler = Surprise
    //List<Rigidbody> boomballs = new List<Rigidbody>();

    Transform CekimPointSuper;

    public void Start()
    {
        CekimPointSuper = GetComponent<Transform>();
        AnaKarak = GameObject.FindGameObjectWithTag("HedefPoint");

    }
    public void FixedUpdate()
    {
        BallPull();
        //BlackPull();
        //BombPull();

        //foreach (Rigidbody rgball in rgballs)
        //{
        //    rgball.AddForce((CekimPoint.position - rgball.position) * Force * Time.deltaTime);
        //}
        //foreach (Rigidbody blball in blballs)
        //{
        //    blball.AddForce((CekimPoint.position - blball.position) * Force * Time.deltaTime);
        //}

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balls"))
        {
            rgballs.Add(other.GetComponent<Rigidbody>());


        }
        //if (other.CompareTag("Black"))
        //{
        //    blballs.Add(other.GetComponent<Rigidbody>());
        //}
        //if (other.CompareTag("Bomb"))
        //{
        //    boomballs.Add(other.GetComponent<Rigidbody>());
        //}

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Balls"))
        {
            rgballs.Remove(other.GetComponent<Rigidbody>());

        }
        //if (other.CompareTag("Black"))
        //{
        //    blballs.Remove(other.GetComponent<Rigidbody>());
        //}
        //if (other.CompareTag("Bomb"))
        //{
        //    boomballs.Remove(other.GetComponent<Rigidbody>());
        //}
    }
    void BallPull()
    {
        if (Input.GetMouseButton(0))
        {
            PullCheckSuper = true;
            foreach (Rigidbody rgball in rgballs)
            {
                rgball.AddForce((AnaKarak.transform.position- rgball.position) * Force * Time.deltaTime);

            }


        }
        else
        {
            PullCheckSuper = false;
        }

    }
    //void BlackPull()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        PullCheck = true;
    //        foreach (Rigidbody blball in blballs)
    //        {
    //            blball.AddForce((CekimPoint.position - blball.position) * BlackForce * Time.deltaTime);

    //        }

    //    }
    //    else
    //    {
    //        PullCheck = false;
    //    }
    //}
    //void BombPull()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        PullCheck = true;
    //        foreach (Rigidbody boomball in boomballs)
    //        {
    //            boomball.AddForce((CekimPoint.position - boomball.position) * BlackForce * Time.deltaTime);

    //        }

    //    }
    //    else
    //    {
    //        PullCheck = false;
    //    }
    //}


}

