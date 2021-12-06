using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTrigger : MonoBehaviour
{
    public ForestFire3D forestFire3D;

    private void Start()
    {
        forestFire3D = FindObjectOfType<ForestFire3D>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            forestFire3D.playerCell = transform.parent.GetComponent<ForestFireCell>();
        }
    }
}
