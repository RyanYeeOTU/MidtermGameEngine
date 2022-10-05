using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Clone1;
    public GameObject Clone2;
    Rigidbody C1;

    public bool collectSummonPower;
    private void Awake()
    {
        C1 = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Green") // if collide with power up
        {
            collectSummonPower = true;

            if (collectSummonPower)
            {
                Vector3 Clone1pos = transform.position;
                Clone1pos.x = transform.position.x - 2;
                Rigidbody C1 = Instantiate(Clone1, Clone1pos, Quaternion.identity).GetComponent<Rigidbody>();
                //C1.isKinematic = true;

                Vector3 Clone2pos = transform.position;
                Clone2pos.x = transform.position.x + 2;
                Rigidbody C2 = Instantiate(Clone2, Clone2pos, Quaternion.identity).GetComponent<Rigidbody>();
              // C2.isKinematic = true;

                
            }
        }
    }

    // Update is called once per frame
  
}
