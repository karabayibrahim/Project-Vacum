using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCubeMovement : MonoBehaviour
{
    public float MoveSpeed = 10f;

    private void Start()
    {
       
    }

    void Update()
    {


        transform.Translate(MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);
        
    }
}
