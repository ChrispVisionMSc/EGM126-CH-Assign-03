using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTrigger : MonoBehaviour
{
    
    //This script is attached to a collider object that is a child of the ForestFireCell prefab.
    //The purpose of the script is to note the position of a triggered cell in the grid and then pass
    //the coordinate
    
    public ForestFire3D forestFire3D; // Reference to forestFire3D objects derived from ForestFire3D script/class

    private void Start()
    {
        forestFire3D = FindObjectOfType<ForestFire3D>(); //
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            if (other.gameObject.CompareTag("MainCamera"))
            {
                forestFire3D = FindObjectOfType<ForestFire3D>();
            }

            forestFire3D.playerCell = transform.parent.GetComponent<ForestFireCell>();
        }
    }
}
