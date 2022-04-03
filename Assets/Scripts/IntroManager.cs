using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public UnityEvent dialogueEvent;
    [SerializeField]
    private GameObject dialogueManager;
    [SerializeField]
    private string nextSceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        dialogueEvent.Invoke();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dialogueManager.GetComponent<TriggerDialogue>().isDialogueActive == false)
        {
            StartCoroutine("switchScene");
        }
    }

    IEnumerator switchScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
