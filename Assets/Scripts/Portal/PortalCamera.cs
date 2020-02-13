using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField]
    private Transform portal = null;
    [SerializeField]
    private Transform otherPortal = null;

    private void Start()
    {
        transform.position = Camera.main.transform.parent.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 offsetFromPortal = Camera.main.transform.position - otherPortal.position;
        transform.position = portal.position + offsetFromPortal;
    }

}
