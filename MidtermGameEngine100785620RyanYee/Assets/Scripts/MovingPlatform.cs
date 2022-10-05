using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
  
    float platformSpeed;
    float platformLimit;
    bool platformRangeReach = false;
    // Start is called before the first frame update
    void Start()
    {

        platformRangeReach = true;
        platformSpeed = Random.Range(2, 10);
        platformLimit = Random.Range(8, 16); // randomize both speed and distance

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x > platformLimit) 
        {
            platformRangeReach = false;
        }
        if (transform.position.x < -platformLimit)
        {
            platformRangeReach = true;
        }

        if (platformRangeReach == true)
        {
            transform.Translate(platformSpeed * Time.deltaTime, 0, 0);
        }
        if (platformRangeReach == false)
        {
            transform.Translate(-platformSpeed * Time.deltaTime, 0, 0);

        }

     
    }
}
