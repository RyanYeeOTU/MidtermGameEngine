using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenChange : MonoBehaviour
{

    private void Awake()
    {
    
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Bullet")
        {
            transform.tag = "Green";
           
        }


        if (other.collider.tag == "Player" && transform.tag == "Green")
        {
            ScoreManager.instance.ChangeScore(1);
            Destroy(gameObject);
        }
    }

}