using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordToggle : MonoBehaviour
{
    // For detecting click
    public Button StartRecord;
    public Button StopRecord;

    // For SetActive (can only do on game objects)
    public GameObject StartR;
    public GameObject StopR;

    // Keeps track of current states of buttons
    bool StartRec = true;
    bool StopRec = false;



    // Start is called before the first frame update
    void Start()
    {
        StartRecord.onClick.AddListener(ClickButton);
        StopRecord.onClick.AddListener(ClickButton);
        UpdateButtons();
    }

    void ClickButton()
    {
        StartRec = !StartRec;
        StopRec = !StopRec;
        UpdateButtons();

    }

    void UpdateButtons()
    {
        StartR.SetActive(StartRec);
        StopR.SetActive(StopRec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
