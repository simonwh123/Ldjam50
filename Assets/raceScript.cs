using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raceScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject raceTarget;
    bool racing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<npcInteract>().hasBeenInteracted == true && TriggerDialogue.isDialogueActive == false)
        {
            racing = true;
        }
        else
        {
            racing = false;
        }

        if (racing)
        {
            animator.Play("SwanRace");
        }
        else
        {
            animator.Play("Idle");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == raceTarget.name)
        {
            racing = false;
        }
    }
}
