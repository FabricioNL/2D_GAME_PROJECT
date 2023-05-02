using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingStates : MonoBehaviour
{
    public static int BoolToInt(bool value) {

        if(value)
            return 1;
        else
            return 0;
    }

    public static bool IntToBool(int value) {
        return value != 0;
    }


    public static void SaveInstrumenstInfo(int instrumentChoice, bool bomboState, bool pianoState, bool flautaState, bool violonceloState) {
        PlayerPrefs.SetInt("bomboState", BoolToInt(bomboState));
        PlayerPrefs.SetInt("flautaState", BoolToInt(flautaState));
        PlayerPrefs.SetInt("pianoState", BoolToInt(pianoState));
        PlayerPrefs.SetInt("violonceloState", BoolToInt(violonceloState));
        PlayerPrefs.SetInt(("instrumentChoice") , instrumentChoice);
    }

    public static void SaveHealthBarPercentage(int currentHealth) {
        PlayerPrefs.SetInt("currentHealth",currentHealth);
    }

    
}
