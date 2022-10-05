using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{
    private GameObject target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = null;

    }
    private void OnTriggerStay(Collider other) // anchor player to platform
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            target = other.gameObject;
            offset = target.transform.position - transform.position;
        }
    }
    private void OnTriggerExit(Collider other) // release player
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            target = null;

        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }

    private void LateUpdate()
    {
        if (target != null) // used to fix positioning
        {
            target.transform.position = transform.position + offset;
        }
    }
}
