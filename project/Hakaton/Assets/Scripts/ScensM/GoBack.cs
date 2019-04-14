using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA.Input;

public class GoBack : MonoBehaviour
{
    public static GoBack Instance { get; private set; }

    GestureRecognizer recognizer;
    RaycastHit hitInfo;

    void Awake()
    {

        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();

        recognizer.Tapped += (args) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            SceneManager.LoadScene(0);
        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        recognizer.StartCapturingGestures();
    }
}