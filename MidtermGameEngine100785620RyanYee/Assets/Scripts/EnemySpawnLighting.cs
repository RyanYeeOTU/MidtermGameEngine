using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnLighting : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Bullet") //If enemy is shot, destroy
        {
            ScoreManager.instance.ChangeScore(1);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame

}
