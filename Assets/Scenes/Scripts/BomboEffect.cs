using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomboEffect : MonoBehaviour
{
    public float maxTimeBetweenKeys = 1.0f;
    public float disableDuration = 6.0f;
    public string[] requiredKeys = { "R", "T", "Y", "U", "I", "O", "P" };
    public string[] targetSequence = { "R", "T", "Y", "U", "I", "O", "P" };
    public GameObject[] objectsToDisable;

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
                      if (PlayerNotes.bomboState && PlayerNotes.instrumentChoice == 1) {
                        StartCoroutine(DisableEnemies());
                      }
                       
                       

                        
                    }
                }
            }
        }
    }


    IEnumerator DisableEnemies()
    {
        foreach (GameObject enemy in objectsToDisable)
        {
            
            enemy.SetActive(false);
        }

        keySequence.Clear();

        yield return new WaitForSeconds(disableDuration);

        foreach (GameObject enemy in objectsToDisable)
        {
            enemy.SetActive(true);
        }
    }
}
