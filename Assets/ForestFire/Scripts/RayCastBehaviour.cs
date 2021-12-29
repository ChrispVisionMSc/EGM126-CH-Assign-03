using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastBehaviour : MonoBehaviour
{
    
    public Transform raycastOrigin; //Enables referance to this script from a gameObject
        
    public LayerMask layerMask; // To set which 'layer mask' Ray Cast can act upon.
        
    public InputActionReference RightHandTrigger;//Reference to an action to assign to an XR controller button

    float waitTime = 2; //Determines time in seconds of raycastDelay

    RaycastHit hit; // Lets system know if raycast has intersected collider object

    public GameObject flameThrowerVFX;



    // Update is called once per frame
    void Update()
    {
        //Monitors input from right hand controller trigger
        if (RightHandTrigger.action.ReadValue<float>() > 0.5f)
        {
            AdvancedRaycast();
            flameThrowerVFX.SetActive(true);//turn on flameThrower VFX
        }
        else 
            flameThrowerVFX.SetActive(false);//turn off flameThrower VFX
            StopCoroutine(raycastDelay());
        // This is supposed to interupt raycastDelay coroutine if trigger released
        // before 2 seconds but does not work??

    }

    private void AdvancedRaycast()
    {
        Debug.DrawRay(transform.position, transform.forward * 6f, Color.magenta);

        if (Physics.Raycast(raycastOrigin.position, transform.forward, out hit, 6f, layerMask))
        {
            StartCoroutine(raycastDelay());
        }
    }
    private IEnumerator raycastDelay() // Co-routine to delay cell state change when acted upon by raycast
    {
        Debug.Log("Raycast Interaction");

        yield return new WaitForSeconds(waitTime);

        CellSetBurnt();
    }

    private void CellSetBurnt()
    {
        // 503403 Any ForestFireCell with RaycastTarget script gets set to State.Setburnt on Raycast hit.
        hit.transform.gameObject.GetComponent<RaycastTarget>().forestFireCell.SetBurnt();
    }


}
