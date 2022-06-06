using System.Collections;
using System.Collections.Generic;

//below is imported from example gamecontroller (usings)
using System;
using System.Linq;
using GetSocialSdk.Capture.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecordiPhone : MonoBehaviour
{
	public static RecordiPhone instance;         //A reference to our game control script so we can access it statically.

	public GetSocialCapturePreview capturePreview;
	private GetSocialCapture _capture;


	//	private bool startedFlag = false;
	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if (instance != this)
			//...destroy this one because it is a duplicate.
			Destroy(gameObject);

		_capture = GetComponent<GetSocialCapture>();
	}

	private void Start()
	{
		_capture.StartCapture();
		StartCoroutine(TestWaitCoroutine()); // wait 5 seconds
		StopRecording();
		StartCoroutine(TestWaitCoroutine()); // again wait before share
		ShareResult(); // share result
	}

	public void ShareResult()
	{
		Debug.Log("Starting gif generation");
		Action<byte[]> result = bytes =>
		{

		};
		_capture.GenerateCapture(result);
	}

	public void StopRecording()
	{
		// stop recording
		_capture.StopCapture();
		capturePreview.Play();
	}

	IEnumerator TestWaitCoroutine()
    {
		yield return new WaitForSeconds(5);
    }
}