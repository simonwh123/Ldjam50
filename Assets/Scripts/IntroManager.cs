using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class IntroManager : MonoBehaviour
{
    public UnityEvent dialogueEvent;
    [SerializeField]
    private GameObject dialogueManager;
    [SerializeField]
    private string nextSceneToLoad;

    [SerializeField]
    private bool switchSceneAfterDialogue;
    [SerializeField]
    private bool dialogueStarted;
 
    public GameObject cameraToDestroy;
    public GameObject cameraToEnable;

    // Start is called before the first frame update
    public void Start()
    {
        Invoke("StartDialogue", 4);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (dialogueManager.GetComponent<TriggerDialogue>().isDialogueActive == false && dialogueStarted == true)
        {
            if (switchSceneAfterDialogue)
            {
                StartCoroutine("switchScene");
            }
            else
            {
                cameraToEnable.SetActive(true);
                cameraToDestroy.SetActive(false);
            }
        }
    }

    public void StartDialogue()
    {
        dialogueEvent.Invoke();
        dialogueStarted = true;
        npcDialogue.dialogueTimer = 0;
    }

    IEnumerator switchScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
