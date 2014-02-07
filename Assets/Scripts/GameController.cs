using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public static GameController instance;

	private WifiController wifiController;
	private InterfaceController interfaceController;

	public float deadlineTime = 56f;

	private bool isInHotspotArea = false;
	public float internetReach = 10f;
	public float downloadSpeedMultiplier = 1f;
	public float distanceToChangeSpot = 2f;

	public float uploadAmount = 0f;
	public float uploadTotalSize = 100f;
	public int filesSent = 0;
	public const int totalFiles = 10;

	void Start(){
		instance = this;
		wifiController = GetComponent<WifiController>();
		interfaceController = GameObject.FindObjectOfType<InterfaceController>();
	}

	void Update () {
		float dist = wifiController.GetDistanceFromSignal();
		interfaceController.UpdateWifiSymbol(dist, internetReach);

		deadlineTime -= Time.deltaTime;
		interfaceController.UpdateTimer(deadlineTime);

		if(deadlineTime <= 0f){
			Debug.LogWarning("Time is up!");
			//TODO: Show score screen
			return;
		}

		if(dist <= internetReach && !isInHotspotArea){
			if(uploadAmount >= uploadTotalSize){
				if(filesSent<totalFiles){
					filesSent++;
					uploadAmount = 0f;
					interfaceController.UploadFilesSent(filesSent, totalFiles);
				}
				return;
			}
			//TODO: verify if speed is good enough;
			uploadAmount += ((dist*dist)/(internetReach*internetReach))*downloadSpeedMultiplier*Time.deltaTime;
			interfaceController.UpdateDownloadBar(uploadAmount, uploadTotalSize);
			if(dist <= distanceToChangeSpot) wifiController.ChangeActiveSignal();
		}
	}

	void OnGUI(){
		GUILayout.Box("Shitty placeholder UI");
		GUILayout.Box("Distance: " + wifiController.GetDistanceFromSignal());
		GUILayout.Box("Uploaded: " + uploadAmount);
	}

	/**
	 * MobileHotpot events
	 */

	public void OnHotspotEnter(){
		if(!isInHotspotArea) isInHotspotArea = true;
	}

	public void OnHotspotExit(){
		if(isInHotspotArea) isInHotspotArea = false;
	}
}
