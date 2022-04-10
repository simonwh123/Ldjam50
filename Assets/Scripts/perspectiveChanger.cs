using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class perspectiveChanger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cameraToSwitchTo;
    [SerializeField] CinemachineVirtualCamera OriginalCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OriginalCamera.enabled = false;
            cameraToSwitchTo.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OriginalCamera.enabled = true;
            cameraToSwitchTo.enabled = false;
        }
    }
}
