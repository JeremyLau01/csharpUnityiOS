using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordToggle : MonoBehaviour
{
    public Button StartRecord;
    public Button StopRecord;

    bool StartRec = true;
    bool StopRec = false;

    

    // Start is called before the first frame update
    void Start()
    {
        UpdateButtons();

        Button btnOn = StartRecord.GetComponent<Button>();
        btnOn.onClick.AddListener(ClickOn);
        Button btnOff = StopRecord.GetComponent<Button>();
    }

    void ClickOn()
    {
        StartRec = !StartRec;
        StopRec = !StopRec;
        UpdateButtons();

    }

    void UpdateButtons()
    {
        StartRecord.SetActive(StartRec);
        StopRecord.SetActive(StopRec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
