using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public static GameController instance;

	private WifiController wifiController;
	private InterfaceController interfaceController;

	public float deadlineTime = 56f;

	private bool isInHotspotArea = false;
	public float internetReach = 10f;
	public float downloadComplicator = 4f;
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

		interfaceController.UpdateTimer(deadlineTime);
		interfaceController.UpdateDownloadBar(uploadAmount, uploadTotalSize);
		interfaceController.UploadFilesSent(filesSent, totalFiles);

	}

	void Update () {
		float dist = wifiController.GetDistanceFromSignal();
		interfaceController.UpdateWifiSymbol(dist, internetReach);

		deadlineTime -= Time.deltaTime;

		if(deadlineTime <= 0f){
			Debug.LogWarning("00:00");
			interfaceController.UpdateTimer(deadlineTime);
			//TODO: Show score screen
			return;
		}
		interfaceController.UpdateTimer(deadlineTime);

		if(dist <= internetReach && !isInHotspotArea){
			if(uploadAmount >= uploadTotalSize){
				if(filesSent<totalFiles){
					filesSent++;
					ChainJam.AddPointsPlayerOne(1);
					uploadAmount = 0f;
					interfaceController.UploadFilesSent(filesSent, totalFiles);
					if(filesSent%2==0)wifiController.ChangeActiveSignal();
				}
				return;
			}
			//TODO: verify if speed is good enough;
			uploadAmount += (Mathf.Pow(internetReach-dist, downloadComplicator)/Mathf.Pow(internetReach, downloadComplicator))*downloadSpeedMultiplier*Time.deltaTime;
			interfaceController.UpdateDownloadBar(uploadAmount, uploadTotalSize);
			if(dist <= distanceToChangeSpot) wifiController.ChangeActiveSignal();
		}
	}

#if UNITY_EDITOR
	void OnGUI(){
		GUILayout.Box("Shitty placeholder UI");
		GUILayout.Box("Distance: " + wifiController.GetDistanceFromSignal());
		GUILayout.Box("Uploaded: " + uploadAmount);
		
		float dist = wifiController.GetDistanceFromSignal();
		float sp = ((Mathf.Pow(internetReach-dist, downloadComplicator)/Mathf.Pow(internetReach, downloadComplicator)))*downloadSpeedMultiplier;
		GUILayout.Box("DLSpeed: " + sp);
	}
#endif

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
