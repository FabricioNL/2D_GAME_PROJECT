using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotes : MonoBehaviour
{
    public  AudioClip[] flauta; // o áudio a ser tocado
    public  AudioClip[] piano; // o áudio a ser tocado
    public  AudioClip[] violoncelo; // o áudio a ser tocado
    public  AudioClip bombo; // o áudio a ser tocado

    public AudioSource audioSource;
    public static int instrumentChoice;

    public static bool bomboState;
    public static bool pianoState; 
    public static bool flautaState;
    public static bool violonceloState;




    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("instrumentChoice")){
            instrumentChoice = PlayerPrefs.GetInt("instrumetChoice");
        }
        else {
            instrumentChoice = 27;
        }

        if (PlayerPrefs.HasKey("bomboState")){
            bomboState = SavingStates.IntToBool(PlayerPrefs.GetInt("bomboState"));
        }
        else {
            bomboState = false;
        }

        if (PlayerPrefs.HasKey("pianoState")){
            pianoState = SavingStates.IntToBool(PlayerPrefs.GetInt("pianoState"));
        }
        else {
            pianoState = false;
        }

        if (PlayerPrefs.HasKey("violonceloState")){
            violonceloState = SavingStates.IntToBool(PlayerPrefs.GetInt("violonceloState"));
        }
        else {
            violonceloState = false;
        }

        if (PlayerPrefs.HasKey("flautaState")){
            flautaState = SavingStates.IntToBool(PlayerPrefs.GetInt("flautaState"));
        }
        else {
            flautaState = false;
        }
    }

    public static void allowBombo(){
        bomboState = true;
    }

    public static void allowPiano(){
        pianoState = true;
    }

    public static void allowFlauta(){
        flautaState = true;
    }

    public static void allowVioloncelo(){
        violonceloState = true;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H) && bomboState) {
            instrumentChoice = 1;
        }

        else if (Input.GetKeyDown(KeyCode.J) && flautaState) {
            instrumentChoice = 2;
        }

        else if (Input.GetKeyDown(KeyCode.K) && violonceloState) {
            instrumentChoice = 3;
        }

        else if (Input.GetKeyDown(KeyCode.L) && pianoState) {
            instrumentChoice = 4;
        }


        if (Input.GetKeyDown(KeyCode.R)) //do
        {   
            if (instrumentChoice == 1) {
                audioSource.PlayOneShot(bombo);
            }

            else if (instrumentChoice == 2) {
                audioSource.PlayOneShot(flauta[0]);
            }

            else if (instrumentChoice == 3) {
                audioSource.PlayOneShot(violoncelo[0]);
            }

            else if (instrumentChoice == 4) {
                audioSource.PlayOneShot(piano[0]);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.T)) //re
        {   
            if (instrumentChoice == 1) {
                audioSource.PlayOneShot(bombo);
            }

            else if (instrumentChoice == 2) {
                audioSource.PlayOneShot(flauta[1]);
            }

            else if (instrumentChoice == 3) {
                audioSource.PlayOneShot(violoncelo[1]);
            }

            else if (instrumentChoice == 4) {
                audioSource.PlayOneShot(piano[1]);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Y)) //mi
        {   
            if (instrumentChoice == 1) {
                audioSource.PlayOneShot(bombo);
            }

            else if (instrumentChoice == 2) {
                audioSource.PlayOneShot(flauta[2]);
            }

            else if (instrumentChoice == 3) {
                audioSource.PlayOneShot(violoncelo[2]);
            }

            else if (instrumentChoice == 4) {
                audioSource.PlayOneShot(piano[2]);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.U)) //fa
        {   
            if (instrumentChoice == 1) {
                audioSource.PlayOneShot(bombo);
            }

            else if (instrumentChoice == 2) {
                audioSource.PlayOneShot(flauta[3]);
            }

            else if (instrumentChoice == 3) {
                audioSource.PlayOneShot(violoncelo[3]);
            }

            else if (instrumentChoice == 4) {
                audioSource.PlayOneShot(piano[3]);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.I)) //sol
        {   
            if (instrumentChoice == 1) {
                audioSource.PlayOneShot(bombo);
            }

            else if (instrumentChoice == 2) {
                audioSource.PlayOneShot(flauta[4]);
            }

            else if (instrumentChoice == 3) {
                audioSource.PlayOneShot(violoncelo[4]);
            }

            else if (instrumentChoice == 4) {
                audioSource.PlayOneShot(piano[4]);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.O)) //la
        {   
            if (instrumentChoice == 1) {
                audioSource.PlayOneShot(bombo);
            }

            else if (instrumentChoice == 2) {
                audioSource.PlayOneShot(flauta[5]);
            }

            else if (instrumentChoice == 3) {
                audioSource.PlayOneShot(violoncelo[5]);
            }

            else if (instrumentChoice == 4) {
                audioSource.PlayOneShot(piano[5]);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.P)) //si
        {   
            if (instrumentChoice == 1) {
                audioSource.PlayOneShot(bombo);
            }

            else if (instrumentChoice == 2) {
                audioSource.PlayOneShot(flauta[6]);
            }

            else if (instrumentChoice == 3) {
                audioSource.PlayOneShot(violoncelo[6]);
            }

            else if (instrumentChoice == 4) {
                audioSource.PlayOneShot(piano[6]);
            }
            
        }
 

        
    }

    private void OnDestroy() {

        SavingStates.SaveInstrumenstInfo(instrumentChoice, bomboState,pianoState,flautaState, violonceloState);

    }
}
