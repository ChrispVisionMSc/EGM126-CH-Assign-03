using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastBehaviour : MonoBehaviour
{
    public Transform raycastOrigin;
    public LayerMask layerMask;

    //Reference to an action to assign to a controller button
    public InputActionReference RaycastTrigger;

    // Update is called once per frame
    void Update()
    {
        //looks at input from controller trigger (change name from raycasttrigger to RightHandTrigger)
        if (RaycastTrigger.action.ReadValue<float>() > 0.5f)
        {
            //maybe add delay here for 1 second to allow raybeam effect etc
            AdvancedRaycast();
        }
        


    }

    private void AdvancedRaycast()
    {
        Debug.DrawRay(transform.position, transform.forward * 6f, Color.magenta);

        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, transform.forward, out hit, 6f, layerMask)) 
        {
            // Deactivates any game object hit by the Raycast (use with layers to limit deactivation to desired objects)
            //hit.transform.gameObject.SetActive(false);
            hit.transform.gameObject.GetComponent<RaycastTarget>().forestFireCell.SetBurnt();


            //forestFireCellsNextGenStates[xCount, yCount] = ForestFireCell.State.Burnt;

            Debug.Log("Raycast Interaction");
        }
    }
}
