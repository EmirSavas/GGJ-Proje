using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    
    void Start()
    {
        
    }


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);
        RaycastHit raycastHit;

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
            {
                Debug.Log(raycastHit.collider.name);
            }
        }
    }
}
