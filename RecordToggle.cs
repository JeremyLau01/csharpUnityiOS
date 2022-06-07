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
    public Button AssetViewRec; // no custom button yet :)
    //public Button AssetSaveRec; - when get this working in the first place :)

    // For SetActive (can only do on game objects)
    public GameObject StartR;
    public GameObject StopR;

    // Keeps track of current states of buttons
    bool StartRecActive = true;
    bool StopRecActive = false;



    // Start is called before the first frame update
    void Start()
    {
        StartRecord.onClick.AddListener(ClickButton);
        StopRecord.onClick.AddListener(ClickButton);
        UpdateButtons();
    }

    void ClickButton()
    {
        StartRecActive = !StartRecActive;
        StopRecActive = !StopRecActive;
        UpdateButtons();
        // Click asset buttons according to the current boolean values
        if (StopRecActive)
        {
            AssetStartRec.onClick.Invoke();
        }
        else
        {
            AssetStopRec.onClick.Invoke();
        }


    }

    void UpdateButtons()
    {
        StartR.SetActive(StartRecActive);
        StopR.SetActive(StopRecActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
