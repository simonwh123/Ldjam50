using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class npcDialogue : MonoBehaviour
{
    [SerializeField] UnityEvent dialogueEvent;
    [SerializeField] CinemachineVirtualCamera[] cameras;
    [SerializeField] float zoomInFOV;
    [SerializeField] float zoomInSpeed;
    [SerializeField] GameObject dialogueManager;
    [SerializeField] float originalFOV;
    public static bool colliding;
    CinemachineVirtualCamera activeCamera;
    public static float dialogueTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            colliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            colliding = false;
        }
    }

    private void Update()
    {
        dialogueTimer -= Time.deltaTime;

        if (colliding)
        {
            foreach (CinemachineVirtualCamera camera in cameras)
            {
                if (camera.GetComponent<CinemachineVirtualCamera>().enabled == true)
                {
                    activeCamera = camera;
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && dialogueManager.GetComponent<TriggerDialogue>().isDialogueActive == false)
            {
                dialogueEvent.Invoke();
                dialogueTimer = 0.3f;
                //GetComponent<SphereCollider>().enabled = false;
            }


            if (dialogueManager.GetComponent<TriggerDialogue>().isDialogueActive)
            {
                if (activeCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView > zoomInFOV)
                {
                    activeCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView -= Time.deltaTime * zoomInSpeed;
                }
            }
            else
            {
                GameObject.FindGameObjectWithTag("Animal").GetComponent<MalbersAnimations.MalbersInput>().enabled = true;

                if (activeCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView < originalFOV)
                {
                    activeCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView += Time.deltaTime * zoomInSpeed;
                }
            }


        }
    }
}
