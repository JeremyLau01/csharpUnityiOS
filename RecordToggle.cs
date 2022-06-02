using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordToggle : MonoBehaviour
{
    public Button StartRecord;
    public Button StopRecord;

    public GameObject StartR;
    public GameObject StopR;

    bool StartRec = true;
    bool StopRec = false;

    

    // Start is called before the first frame update
    void Start()
    {
        StartRecord.onClick.AddListener(ClickOn);
        StopRecord.onClick.AddListener(ClickOff);
        UpdateButtons();
    }

    void ClickOn()
    {
        StartRec = !StartRec;
        StopRec = !StopRec;
        UpdateButtons();

    }

    void ClickOff()
    {
        ClickOn();
    }

    void UpdateButtons()
    {
        Debug.Log(StartRec + " Start");
        Debug.Log(StopRec + " Stop");
        StartR.SetActive(StartRec);
        StopR.SetActive(StopRec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
