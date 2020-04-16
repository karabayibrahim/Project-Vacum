using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    GameObject object1;
    PlayerMovement playerMoveCode;
    
    // Start is called before the first frame update
    public float CamAutoMoveSpeed;
    
    private void Start()
    {
        object1 = GameObject.FindGameObjectWithTag("Player");
        playerMoveCode = object1.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CamAutoMoveSpeed = playerMoveCode.AutomaticMoveSpeed;
        transform.position += Vector3.forward * CamAutoMoveSpeed * Time.deltaTime;

        transform.position = new Vector3(Mathf.Clamp( transform.position.x, -0.72f, -0.72f),
            transform.position.y, transform.position.z);

    }
   
}
