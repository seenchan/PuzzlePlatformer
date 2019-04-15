using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPlatformController : MonoBehaviour
{
    
    private GameObject windDirection;
    private Vector3 dir;
    

    // Start is called before the first frame update
    void Start()
    {
        windDirection = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        FindDirection();
    }

    void OnTriggerStay(Collider hit)
    {
        if (GameManager.Instance.isPlacementMode == false)
        {
            if (hit.tag == "Player")
            {
                hit.GetComponent<Rigidbody>().AddForce(dir * GameManager.Instance.platformWindPower);
            }
        }
    }

    void FindDirection()
    {
        dir = windDirection.transform.position - this.transform.position;
    }
}
