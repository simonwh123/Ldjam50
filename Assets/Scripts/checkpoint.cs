using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public bool unlocked;
    [SerializeField] GameObject checkPointManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(GameObject checkpoint in checkPointManager.GetComponent<checkpointManager>().checkpoints)
            {
                checkpoint.GetComponent<checkpoint>().unlocked = false;
            }
            unlocked = true;
        }
    }
}
