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


    // For screen tap space
    //public Transform threshold;


    // trying to have the object point towards the viewer on place down
    public Transform target; // transform of the AR camera

    GameObject hoop = null; // temporary object so can place new hoops and destroy old ones

    // Start is called before the first frame update
    void Start()
    {
        cursorChildObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursor();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //Vector3 screenPosThresh = Camera.main.WorldToScreenPoint(threshold.position);

            if (touch.phase == TouchPhase.Began && touch.position.y > 200) //screenPosThresh.y
            {
                Destroy(hoop); // destroy previous hoop, so that there will not be so many in one scene
                hoop = GameObject.Instantiate(objectToPlace, transform.position, transform.rotation); // how set reference to hoop as new game object
                                                                                                      // rotate on y axis towards user, using AR camera's position
                hoop.transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            }

        }
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).position.y < abovePoint.position.y)
        //{
        //    
        //    Destroy(hoop); // destroy previous hoop, so that there will not be so many in one scene
        //    hoop = GameObject.Instantiate(objectToPlace, transform.position, transform.rotation); // how set reference to hoop as new game object
        //    // rotate on y axis towards user, using AR camera's position
        //    hoop.transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        //}
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