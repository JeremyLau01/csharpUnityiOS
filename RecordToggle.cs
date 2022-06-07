using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordToggle : MonoBehaviour
{
    // For detecting click
    public Button StartRecord;
    public Button StopRecord;

    public Button AssetStartRec;
    public Button AssetStopRec;
    public Button AssetViewRec;
    //public Button AssetSaveRec; - when get this working in the first place :)

    // For SetActive (can only do on game objects)
    public GameObject StartR;
    public GameObject StopR;

    // Keeps track of current states of buttons
    bool StartRecActive = true;
    bool StopRecActive = false;

    // Custom view button
    bool ViewableRecording = false;
    // For SetActive (can only do on game objects)
    public GameObject ViewR;



    // Start is called before the first frame update
    void Start()
    {
        StartRecord.onClick.AddListener(ClickButton);
        StopRecord.onClick.AddListener(ClickButton);
        AssetViewRec.onClick.AddListener(ViewRecording);
        UpdateButtons();
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
        }
        else
        {
            AssetStopRec.onClick.Invoke();
            ViewableRecording = true;
        }
        UpdateButtons();
    }

    void ViewRecording()
    {
        AssetViewRec.onClick.Invoke();
    }

    void UpdateButtons()
    {
        StartR.SetActive(StartRecActive);
        StopR.SetActive(StopRecActive);
        ViewR.SetActive(ViewableRecording);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
