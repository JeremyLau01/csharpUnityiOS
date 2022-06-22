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


    public void SetStateColor(double colorVal)
    {


        //stateGameobject.GetComponent<Renderer>().material.SetColor("_Color", ____);



        stateGameobject.GetComponent<Image>().color = new Color((float)colorVal, 0, 0, 1);

    }


    void ClickButton()
    {
        StartRecActive = !StartRecActive;
        StopRecActive = !StopRecActive;
        // Click asset buttons according to the current boolean values
        if (StopRecActive)
        {
            SetStateColor(0.1); // Argument for don't do anything --> simple recorder . cs
            AssetStartRec.onClick.Invoke();
            ViewableRecording = false;
            ViewableSave = false;
        }
        else
        {
            SetStateColor(0.2); // Immediately save to camera roll --> simple recorder . cs
            AssetStopRec.onClick.Invoke();
            AssetSaveRec.onClick.Invoke(); // Immediately save
            ViewableRecording = true;
            ViewableSave = true;
        }
        UpdateButtons();
    }

    void ViewRecording()
    {
        SetStateColor(0.3); // View Recording --> simple recorder . cs
        AssetViewRec.onClick.Invoke();
    }

    
    void SaveRecording() // Really should be share recording --> change names at the end
    {
        SetStateColor(0.4); // Share Recording --> simple recorder . cs
        AssetSaveRec.onClick.Invoke();
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
