using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

using System;

//using VideoCreator;

//[RequireComponent(typeof(AudioSource))]
public class RecordToggle : MonoBehaviour
{
    // For detecting click
    public Button StartRecord;
    public Button StopRecord;
    public Button ViewRecord;
    public Button SaveRecord; //

    // Asset button with watermark - off to the side
    public Button AssetStartRec;
    public Button AssetStopRec;
    public Button AssetViewRec;
    public Button AssetSaveRec;

    // For SetActive (can only do on game objects)
    public GameObject StartR;
    public GameObject StopR;
    public GameObject ViewR;
    public GameObject SaveR;

    // Keeps track of current states of buttons
    bool StartRecActive = true;
    bool StopRecActive = false;

    // Custom view button, save recording will have same behavior as view recording button
    bool ViewableRecording = false;
    bool ViewableSave = false;



    // FOR DISTINGUISHING WHICH BUTTON WAS PRESSED
    public GameObject stateGameobject;
    /// <summary>
	/// /////////
	/// </summary>


    // Start is called before the first frame update
    void Start()
    {
        //cachePath = Application.persistentDataPath + "/video.mov"; // maybe need to change this to .mpeg

        StartRecord.onClick.AddListener(ClickButton);
        StopRecord.onClick.AddListener(ClickButton);
        ViewRecord.onClick.AddListener(ViewRecording);
        SaveRecord.onClick.AddListener(SaveRecording); // copy view record
        UpdateButtons();
    }


    public void SetStateColor(int colorVal)
    {
        // get current color - put in other script
        //Vector4 stateButtonColor = stateButton.image.color;

        //stateGameobject.GetComponent<Renderer>().material.SetColor("_Color", ____);
        stateGameobject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, colorVal);

    }


    void ClickButton()
    {
        StartRecActive = !StartRecActive;
        StopRecActive = !StopRecActive;
        // Click asset buttons according to the current boolean values
        if (StopRecActive)
        {
            AssetStartRec.onClick.Invoke();
            ViewableRecording = false;
            ViewableSave = false;
            SetStateColor(1); // Argument for don't do anything --> simple recorder . cs
        }
        else
        {
            AssetStopRec.onClick.Invoke();
            ViewableRecording = true;
            ViewableSave = true;
            SetStateColor(2); // Immediately save to camera roll --> simple recorder . cs
        }
        UpdateButtons();
    }

    void ViewRecording()
    {
        AssetViewRec.onClick.Invoke();
        SetStateColor(3); // View Recording --> simple recorder . cs
    }

    
    void SaveRecording() // Really should be share recording --> change names at the end
    {
        AssetSaveRec.onClick.Invoke();
        SetStateColor(4); // Share Recording --> simple recorder . cs
        //SaveR.SetActive(false);

    }
    

    void UpdateButtons()
    {
        StartR.SetActive(StartRecActive);
        StopR.SetActive(StopRecActive);
        ViewR.SetActive(ViewableRecording);
        SaveR.SetActive(ViewableSave);

    }

    // Update is called once per frame - from medium
    void Update()
    {
        
    }

}
