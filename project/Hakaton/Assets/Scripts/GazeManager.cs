using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA.Input;

public class GazeManager : MonoBehaviour
{
    int sceneN = 1;
    public GameObject[] objects = new GameObject[6];
    public static GazeManager Instance { get; private set; }
    public static Vector3 resetV = new Vector3(0, 0, 0.1f);
    public static Vector3 moveV = new Vector3(0, 0, -0.1f);
    Vector3 headPosition;
    Vector3 gazeDirection;
    GameObject oldFocusObject;
    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

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
             if (FocusedObject != null)
             {
                 for(int i = 0; i < objects.Length; i++)
                 {
                     if(objects[i].Equals(FocusedObject))
                     {
                         SceneManager.LoadScene(i);
                         break;
                     }
                 }
                 FocusedObject.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
         
             }
         };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        headPosition = Camera.main.transform.position;
        gazeDirection = Camera.main.transform.forward;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            oldFocusObject?.transform.Translate(resetV);
            FocusedObject?.transform.Translate(moveV);
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}