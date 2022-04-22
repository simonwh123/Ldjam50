using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class npcInteract : MonoBehaviour
{
    [SerializeField] UnityEvent dialogueEvent;
    [SerializeField] CinemachineVirtualCamera[] cameras;
    [SerializeField] float zoomInFOV;
    [SerializeField] float zoomInSpeed;
    [SerializeField] GameObject dialogueManager;
    [SerializeField] float originalFOV;
    [SerializeField] GameObject player;
    public bool hasBeenInteracted;
    public bool colliding;
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
            transform.LookAt(player.transform);

            if (Input.GetKeyDown(KeyCode.E) && TriggerDialogue.isDialogueActive == false)
            {
                dialogueEvent.Invoke();
                dialogueTimer = 0.3f;
                player.GetComponent<MalbersAnimations.MalbersInput>().Horizontal.active = false;
                player.GetComponent<MalbersAnimations.MalbersInput>().Vertical.active = false;
                hasBeenInteracted = true;
            }
        }

        foreach (CinemachineVirtualCamera camera in cameras)
        {
            if (camera.GetComponent<CinemachineVirtualCamera>().enabled == true)
            {
                activeCamera = camera;
            }
        }

        if (TriggerDialogue.isDialogueActive)
        {
            if (activeCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView > zoomInFOV)
            {
                activeCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView -= Time.deltaTime * zoomInSpeed;
                
            }
        }
        else
        {
            player.GetComponent<MalbersAnimations.MalbersInput>().Horizontal.active = true;
            player.GetComponent<MalbersAnimations.MalbersInput>().Vertical.active = true;

            if (activeCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView < originalFOV)
            {
                activeCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView += Time.deltaTime * zoomInSpeed;
                
            }
        }
    }
}
