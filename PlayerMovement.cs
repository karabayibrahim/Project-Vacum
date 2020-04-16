using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed = 10f;
    public float AutomaticMoveSpeed = 2f;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position += Vector3.forward * AutomaticMoveSpeed * Time.deltaTime;

        transform.Translate(MoveSpeed*Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.16f, 3.54f),
            transform.position.y, transform.position.z);
        
    }
}
