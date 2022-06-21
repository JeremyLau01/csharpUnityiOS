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


    private string shareMessage;

    /// <summary>
	/// this is the added github medium code
	/// </summary>
	/// public RenderTexture texture = null;
    /*
    public RenderTexture texture;


    private bool isRecording = false;
    //private bool recordAudio = false;
    private bool saveAfterFinish = false;

    private string cachePath = "";

    //private long amountFrame = 0;
    private float startTime = 0;

    private long startTimeOffset = 6_000_000;
    */

    // Start is called before the first frame update
    void Start()
    {
        //cachePath = Application.persistentDataPath + "/video.mov"; // maybe need to change this to .mpeg

        StartRecord.onClick.AddListener(ClickButton);
        StopRecord.onClick.AddListener(ClickButton);
        ViewRecord.onClick.AddListener(ViewRecording);
        SaveRecord.onClick.AddListener(SaveRecording); // copy view record
        UpdateButtons();



        /// from medium
        //Application.targetFrameRate = 30;
        //var source = gameObject.AddComponent<AudioSource>();
        //source.Stop();

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
            //StartRecMovWithNoAudio();
        }
        else
        {
            AssetStopRec.onClick.Invoke();
            ViewableRecording = true;
            ViewableSave = true;
            //FinishRec();
        }
        UpdateButtons();
    }

    void ViewRecording()
    {
        AssetViewRec.onClick.Invoke();
    }

    
    void SaveRecording()
    {
        //AssetSaveRec.onClick.Invoke();
        //SaveR.SetActive(false);
        ClickShareButton();
        //FinishRec();
        // define ss to be the video we are saving, call function to find the video
        //byte[] ss = new byte[](....);
        //NativeGallery.Permission permission = NativeGallery.SaveVideoToGallery(ss, "Vertical Jumps", "Video.mp4", (success, path) => Debug.Log("Media save result: " + success + " " + path));
        //Destroy(ss);
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

        /*
        if (isRecording)
        {
            long time = (long)((Time.time - startTime) * 1_000_000) + startTimeOffset;

            MediaCreator.WriteVideo(texture, time);
        }
        else
        {
            return;
        }
        */
        
    }

    // from medium
    /*
    public void StartRecMovWithNoAudio()
    {

        //cachePath = "" + Application.temporaryCachePath + "/tmp.mov"; // btwn quotes is "file : //" without spaces
        

        MediaCreator.InitAsMovWithNoAudio(cachePath, "h264", texture.width, texture.height);
        MediaCreator.Start(startTimeOffset);

        startTime = Time.time;

        isRecording = true;
        saveAfterFinish = true;
    }

    public void FinishRec()
    {
        MediaCreator.FinishSync();
        if (saveAfterFinish)
        {
            MediaSaver.SaveVideo(cachePath);
        }

        isRecording = false;
        //recordAudio = false;
        saveAfterFinish = false;
    }
    */


    public void ClickShareButton()
    {
        shareMessage = "Check out this crazy jump!";

        StartCoroutine(TakeScreenshotAndShare());
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("Jeremy's AR Basketball Hoop App").SetText(shareMessage).SetUrl("https://github.com/yasirkula/UnityNativeShare")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
    }
}
