using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;
   

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {

            current++;


        }
        
    }
}
