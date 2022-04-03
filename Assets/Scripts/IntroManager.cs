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
    private bool carScene;
    private bool dialogueStarted;

    // Start is called before the first frame update
    void Awake()
    {
        Invoke("StartDialogue", 4);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dialogueManager.GetComponent<TriggerDialogue>().isDialogueActive == true)
        {
            dialogueStarted = true;
        }

        if (dialogueManager.GetComponent<TriggerDialogue>().isDialogueActive == false && dialogueStarted == true && switchSceneAfterDialogue == true)
        {
            StartCoroutine("switchScene");
        }

        if (dialogueManager.GetComponent<TriggerDialogue>().isDialogueActive == false && dialogueStarted == true && switchSceneAfterDialogue == false && carScene == true)
        {
            Camera.main.GetComponent<PlayableDirector>().enabled = true;
        }
    }

    public void StartDialogue()
    {
        dialogueEvent.Invoke();
    }

    IEnumerator switchScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
