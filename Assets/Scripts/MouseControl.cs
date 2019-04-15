using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private Vector3 mousePosition;
    private GameObject heldPlatform;
    private GameObject targetedPlatform;
    private int ignoredLayer = 9;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isPlacementMode == true)
        {
            RegisterPlatform();
            RayPosition();
            MovePlatform();
            RotateObject(Input.GetAxis("MouseScroll"));
        }
    }

    void RegisterPlatform()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,Mathf.Infinity, ignoredLayer))
            {
                if (hit.collider.tag == "Platform" && heldPlatform == null)
                {
                    heldPlatform = hit.collider.gameObject;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            heldPlatform = null;
        }
    }

    void RayPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
            GameManager.Instance.mousePosition = hit.point;
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ignoredLayer))
        {
            TargetPlatform(hit.collider.gameObject);
        }
    }

    void TargetPlatform(GameObject target)
    {
        if (target.tag == "Platform")
        {
            targetedPlatform = target.gameObject;
        }
        else
        {
            targetedPlatform = null;
        }
    }

    void MovePlatform()
    {
        if (heldPlatform != null)
        {
            heldPlatform.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }

    void RotateObject(float value)
    {
        if (targetedPlatform != null)
        {
            targetedPlatform.transform.Rotate(new Vector3(0, 0, value));
        }
    }
}
