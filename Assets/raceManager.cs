using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raceManager : MonoBehaviour
{
    bool hasBeenTouched;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasBeenTouched == false)
        {
            hasBeenTouched = true;
        }

        if (other.gameObject.name == "Swan" && hasBeenTouched == false)
        {
            hasBeenTouched = true;
        }
    }
}
