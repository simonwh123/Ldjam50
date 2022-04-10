using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkpointManager : MonoBehaviour
{
    public static bool dead;
    public GameObject[] checkpoints;
    [SerializeField] GameObject Player;
    [SerializeField] Image deathUI;
    byte fadeAmount;
    Transform respawnPoint;
    bool fadeOutDeathScreen;

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
            deathUI.color = new Color32(0, 0, 0, 255);

            foreach (GameObject checkpoint in checkpoints)
            {
                if (checkpoint.GetComponent<checkpoint>().unlocked == true)
                {
                    respawnPoint = checkpoint.transform;
                    dead = false;
                    Player.transform.position = respawnPoint.transform.position;

                    fadeOutDeathScreen = true;
                }
            }
        }

        if (fadeOutDeathScreen)
        {
            deathUI.color = new Color32(0, 0, 0, fadeAmount);
            fadeAmount -= 1;
            if (fadeAmount < 1)
            {
                fadeOutDeathScreen = false;
            }
        }
    }
}
