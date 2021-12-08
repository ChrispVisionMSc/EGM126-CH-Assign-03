using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBehaviour : MonoBehaviour
{
    public Transform raycastOrigin;
    public LayerMask layerMask;
    public GameObject treeCollider;


    // Update is called once per frame
    void Update()
    {
        AdvancedRaycast();
    }

    private void AdvancedRaycast()
    {
        Debug.DrawRay(transform.position, transform.forward * 6f, Color.magenta);

        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, transform.forward, out hit, 6f, layerMask)) 
        {
            // Deactivates any game object hit by the Raycast (use with layers to limit
            //deactivation to desired objects)
            //hit.transform.gameObject.SetActive(false);
            
            Debug.Log("Raycast Interaction");
        }
    }
}
