using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI; // for test text

public class ARCursor : MonoBehaviour
{
    public GameObject cursorChildObject;

    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;

    public Button stateButton; // for color differentiating

    public GameObject InstructionScreen; // for not tapping in instructions




    // trying to have the object point towards the viewer on place down
    public Transform target; // transform of the AR camera

    GameObject hoop = null; // temporary object so can place new hoops and destroy old ones

    // Start is called before the first frame update
    void Start()
    {
        //cursorChildObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector4 stateButtonColor = stateButton.image.color;
        bool state = stateButtonColor[0].Equals((float)0.1);
        bool currentlyRecording = !state;


        //cursorChildObject.SetActive(currentlyRecording); // hide when recording


        UpdateCursor();

        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (!InstructionScreen.activeSelf && currentlyRecording && touch.phase == TouchPhase.Began && touch.position.y > 200 && !(touch.position.y > 1200 && touch.position.x < 130)) //screenPosThresh.y
            {
                Destroy(hoop); // destroy previous hoop, so that there will not be so many in one scene
                hoop = GameObject.Instantiate(objectToPlace, transform.position, transform.rotation); // how set reference to hoop as new game object
                                                                                                      // rotate on y axis towards user, using AR camera's position
                hoop.transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            }

        }
    }

    void UpdateCursor()
    {
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }

}
