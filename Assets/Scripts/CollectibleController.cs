using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.isStarCollected == true)
        {
            this.gameObject.SetActive(false);
        }
        else if (GameManager.Instance.isStarCollected == false)
        {
            this.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
