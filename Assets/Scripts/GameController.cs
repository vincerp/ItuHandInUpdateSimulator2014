using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public static GameController instance;

	private WifiController wifiController;

	public float deadlineTime = 55f;

	private bool isInHotspotArea = false;
	public float internetReach = 10f;
	public float downloadSpeedMultiplier = 1f;
	public float distanceToChangeSpot = 2f;

	public float uploadAmount = 0f;
	public float uploadTotalSize = 100f;

	void Start(){
		instance = this;
		wifiController = GetComponent<WifiController>();
	}

	void Update () {
		float dist = wifiController.GetDistanceFromSignal();

		deadlineTime -= Time.deltaTime;

		if(dist <= internetReach && !isInHotspotArea){
			if(uploadAmount >= uploadTotalSize){
				uploadAmount = uploadTotalSize;
				return;
			}
			//TODO: verify if speed is good enough;
			uploadAmount += ((dist*dist)/(internetReach*internetReach))*downloadSpeedMultiplier*Time.deltaTime;
			if(dist <= distanceToChangeSpot) wifiController.ChangeActiveSignal();
		}
	}

	void OnGUI(){
		GUILayout.Box("Shitty placeholder UI");
		GUILayout.Box("Distance: " + wifiController.GetDistanceFromSignal());
		GUILayout.Box("Uploaded: " + uploadAmount);
	}

	/**
	 * Message receivers for MobileHotpot
	 */

	public void OnHotspotEnter(){
		if(!isInHotspotArea) isInHotspotArea = true;
	}

	public void OnHotspotExit(){
		if(isInHotspotArea) isInHotspotArea = false;
	}
}
