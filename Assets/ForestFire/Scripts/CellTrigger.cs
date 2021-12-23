using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTrigger : MonoBehaviour
{
    
    //503403 This script is attached to a collider object that is a child of the ForestFireCell prefab.
    //The purpose of the script is to note the position of a triggered cell in the grid so the MiniMap script-
    //can change the colour of the cellSpriteRenderer at that coordinate to magenta inticating player position
    //on the map
    
    public ForestFire3D forestFire3D; // 503403 Reference to forestFire3D objects derived from ForestFire3D script/class

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
