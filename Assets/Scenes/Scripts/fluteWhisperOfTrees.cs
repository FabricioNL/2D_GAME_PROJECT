using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluteWhisperOfTrees : MonoBehaviour
{
    public float maxTimeBetweenKeys = 1.0f;
    public float disableDuration = 6.0f;
    public string[] requiredKeys = { "R", "T", "Y", "U", "I", "O", "P" };
    public string[] targetSequence = { "R", "T", "Y", "U", "I", "O", "P" };
    public GameObject door0;
    public GameObject door1;

    public bool door0State = false;
    public bool door1State = false;
    private List<string> keySequence = new List<string>();
    private float lastKeyPressTime = 0.0f;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            string key = Input.inputString.ToUpper();
            if (key == "R" || key == "T" || key == "Y" || key == "U" || key == "I" || key == "O" || key == "P")
            {
                float currentTime = Time.time;
                if (currentTime - lastKeyPressTime > maxTimeBetweenKeys)
                {
                    keySequence.Clear();
                }
                lastKeyPressTime = currentTime;
                keySequence.Add(key);

                if (keySequence.Count == targetSequence.Length)
                {
                    bool sequenceMatched = true;
                    for (int i = 0; i < targetSequence.Length; i++)
                    {
                        if (keySequence[i] != targetSequence[i])
                        {
                            sequenceMatched = false;
                            break;
                        }
                    }
                    if (sequenceMatched)
                    {
                      Debug.Log("Entrs");
                      if (PlayerNotes.flautaState && PlayerNotes.instrumentChoice == 2) {

                        if (door0State) {
                            transform.position = door1.transform.position;
                        }

                        else if (door1State) {
                            transform.position = door0.transform.position;
                        }
                        
                      }
                       
                       

                        
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("door0"))
        {
            door0State = true;
        }

        if (other.CompareTag("door1"))
        {
            door1State = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
            door1State = false;
            door0State = false;
        
    }

   
}
