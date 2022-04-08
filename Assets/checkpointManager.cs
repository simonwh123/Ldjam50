using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointManager : MonoBehaviour
{
    public static bool dead;
    public GameObject[] checkpoints;
    [SerializeField] GameObject Player;
    Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            foreach(GameObject checkpoint in checkpoints)
            {
                if (checkpoint.GetComponent<checkpoint>().unlocked == true)
                {
                    respawnPoint = checkpoint.transform;
                    dead = false;
                    Player.transform.position = respawnPoint.transform.position;
                }
            }
        }
    }
}
