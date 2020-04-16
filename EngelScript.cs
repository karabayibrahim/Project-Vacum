using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelScript : MonoBehaviour
{
    public float AutomaticMoveSpeed=2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FindObjectOfType<RightTrig>().Kontrol==false)//Burada kontrolü false yaparak rigmovent
        {
            RightMovent();
        }
        else
        {
            LeftMovement();
        }
        
        
    }
    public void RightMovent()
    {
        transform.position += Vector3.right * AutomaticMoveSpeed * Time.deltaTime;
    }
    public void LeftMovement()
    {
        transform.position += Vector3.left * AutomaticMoveSpeed * Time.deltaTime;
    }
}
