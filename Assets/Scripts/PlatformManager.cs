using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private GameObject[] platformList;
    private GameObject[] activePlatform;

    // Start is called before the first frame update
    void Start()
    {
        FindPlatformType();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FindActivePlatform();
    }

    void FindActivePlatform()
    {
        activePlatform = GameObject.FindGameObjectsWithTag("Platform");

        if (GameManager.Instance.isPlacementMode == false)
        {
            GameManager.Instance.activePlatform = activePlatform.Length;
        }
        else if (GameManager.Instance.isPlacementMode == true)
        {
            GameManager.Instance.activePlatform = activePlatform.Length - platformList.Length;
        }
    }

    void FindPlatformType()
    {
        platformList = GameObject.FindGameObjectsWithTag("PlatformContainer");
    }
}
