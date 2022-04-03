using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialogue : MonoBehaviour
{
    float textSpeed = .05f; // the lower the faster

    Animator animDialogue;
    Image charImage;
    Text charName;
    Text textDialogue;
    Dialogue dialogue;
    IEnumerator textTypeCoroutine; // keep a single copy of a coroutine
    int sentenceCount;
    public bool isDialogueActive; // flag to check if there's an on going conversation
    [SerializeField]
    AudioSource sound;

    void Start()
    {
        GameObject dialogueCanvas = GameObject.Find("DialogueCanvas"); // get dialogue canvas from the world
        animDialogue = dialogueCanvas.transform.GetChild(0).GetComponent<Animator>(); // get the animator of its child - DialoguePanel
        charImage = dialogueCanvas.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
        charName = dialogueCanvas.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>(); // get the text reference for character name
        textDialogue = dialogueCanvas.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>(); // get the text reference for dialogue
        animDialogue.SetBool("open",false);
        isDialogueActive = false;
    }

    void LateUpdate()
    {
        
    }

    public void StartDialogue(GameObject npc) {
        // dialogue will only start if it's not currently active
        if (!isDialogueActive) {
            // get dialogue script of npc
            dialogue = npc.GetComponent<Dialogue>();
            charImage.sprite = dialogue.charImg;
            charName.text = dialogue.charName;
            sentenceCount = 0; // always starts with the first sentence
            textTypeCoroutine = TypeDialogue(dialogue.sentences[sentenceCount]); // assign the coroutine to global var
            StartCoroutine(textTypeCoroutine); // execute coroutine
            animDialogue.SetBool("open", true);
            isDialogueActive = true;
        }
        
    }

    bool isSentenceFinished = false; // flag to check if sentence is still typing
    IEnumerator TypeDialogue(string sentence) {
        string textDisplay = "";
        foreach (char letter in sentence.ToCharArray()) {
            isSentenceFinished = false;
            textDisplay += letter;
            yield return new WaitForSeconds(textSpeed);
            textDialogue.text = textDisplay;
            sound.Play();
        }
        isSentenceFinished = true;
    }

    public void ContinueDialogue() {
        int sentences = dialogue.sentences.Length;
        if (sentenceCount < sentences - 1)
        {
            StopCoroutine(textTypeCoroutine);
            if (!isSentenceFinished)
            {
                textDialogue.text = dialogue.sentences[sentenceCount];
                isSentenceFinished = true;
            }
            else {
                sentenceCount += 1; // go to next sentence if there's any
                textTypeCoroutine = TypeDialogue(dialogue.sentences[sentenceCount]);
                StartCoroutine(textTypeCoroutine); // start displaying the next sentence
            }
            
        }
        else {
            StopCoroutine(textTypeCoroutine);
            if (!isSentenceFinished)
            {
                textDialogue.text = dialogue.sentences[sentenceCount];
                isSentenceFinished = true;
            }
            else
            {
                animDialogue.SetBool("open", false); // end if there's no more sentence left to display
                isDialogueActive = false;
            }
            
        }
    }
}
