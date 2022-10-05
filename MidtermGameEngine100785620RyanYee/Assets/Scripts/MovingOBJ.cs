using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOBJ : MonoBehaviour
{
    float movement = 5f;
    float movelimit = 6f;
    float randomizeDir;
    bool hitLimit; 
    // Start is called before the first frame update
    void Start()
    {
        hitLimit = true;
        randomizeDir = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
       //x
        if (transform.position.x < movelimit) // hits 1 side, switches
        {
            hitLimit = true;
        }
        if (transform.position.x > -movelimit) // hit 1 side , switches to other direction
        {
            hitLimit = false;
        }

        //y
        if (transform.position.y < movelimit) // hits 1 side, switches
        {
            hitLimit = true;
        }
        if (transform.position.y > -movelimit) // hit 1 side , switches to other direction
        {
            hitLimit = false;
        }
        //z
        if (transform.position.z < movelimit) // hits 1 side, switches
        {
            hitLimit = true;

        }
        if (transform.position.z > -movelimit) // hit 1 side , switches to other direction
        {
            hitLimit = false;
        }


        if (hitLimit == true) // movement of object
        {

            if (randomizeDir == 1)
            {
                transform.Translate(movement * Time.deltaTime, 0, 0);
            }
            if (randomizeDir == 2)
            {
                transform.Translate(0,movement * Time.deltaTime, 0);
            }
            if (randomizeDir == 3)
            {
                transform.Translate(0, 0 ,movement * Time.deltaTime);
            }
        }

        if (hitLimit == false)
        {
           

            if (randomizeDir == 1)
            {
                transform.Translate(-movement * Time.deltaTime, 0, 0);
            }
            if (randomizeDir == 2)
            {
                transform.Translate(0, -movement * Time.deltaTime, 0);
            }
            if (randomizeDir == 3)
            {
                transform.Translate(0, 0, -movement * Time.deltaTime);
            }

        }


    }
}
