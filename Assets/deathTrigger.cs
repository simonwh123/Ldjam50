using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathTrigger")
        {
            die();        
        }
    }

    public void die()
    {
        checkpointManager.dead = true;
    }
}
