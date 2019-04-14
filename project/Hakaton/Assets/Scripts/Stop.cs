using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    // Called by SpeechManager when the user says the "Reset world" command
    void OnReset()
    {
        Electron_moving.Freeze = true;
    }
    void GoOn()
    {
        Electron_moving.Freeze = false;
    }
}
