using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private string NextPhaseName;
    [SerializeField]
    private bool NeedOfInstatiation;
    [SerializeField]
    private GameObject Respawn;

    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        GoToNextPhase();
    }

    private void GoToNextPhase() {
        if (NeedOfInstatiation){
            SaveLocationRespawn();
            
        }
        SceneManager.LoadScene(this.NextPhaseName);
        
        

        
        
    }


    public void SaveLocationRespawn() {
        PlayerPrefs.SetFloat("X", Respawn.transform.position.x);
        PlayerPrefs.SetFloat("Y", Respawn.transform.position.y);
        PlayerPrefs.SetFloat("Z", Respawn.transform.position.z);
        PlayerPrefs.SetInt(("STATE") , 1);

    }

}
