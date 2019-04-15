using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;

    public bool isEmpty = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlacementMode == true)
        {
            RefillPlatform();
        }
        if (GameManager.Instance.isPlacementMode == false)
        {
            isEmpty = true;
        }
    }

    void RefillPlatform()
    {
        if (isEmpty == true)
        {
            SpawnPlatform(platform);
            isEmpty = false;
        }
    }

    void SpawnPlatform(GameObject obj)
    {
        GameObject clonedPlatform = Instantiate(obj, this.transform.position, Quaternion.identity, this.transform);
        clonedPlatform.name = platform.name;
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.tag == "Platform")
        {
            isEmpty = true;
        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (GameManager.Instance.isPlacementMode == false)
        {
            Destroy(hit.gameObject);
        }
    }
}
