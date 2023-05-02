using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class SceneRespawn : MonoBehaviour

{


    public void Awake() {
            if (PlayerPrefs.HasKey("X")&&PlayerPrefs.HasKey("Y")&&PlayerPrefs.HasKey("Z") && PlayerPrefs.HasKey("STATE") && PlayerPrefs.GetInt("STATE") == 1){
            transform.position = new Vector3 (PlayerPrefs.GetFloat("X"),PlayerPrefs.GetFloat("Y"),PlayerPrefs.GetFloat("Z"));
            PlayerPrefs.SetInt("STATE",0);
            }
    }
    


}

