using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public WifiController wifiController;

	public float deadlineTime = 55f;

	private bool isInHotspotArea = false;
	public float internetReach = 10f;
	public float downloadSpeedMultiplier = 1f;

	public float uploadAmount = 0f;
	public float uploadTotalSize = 100f;

	IEnumerator Start(){
		yield return new WaitForEndOfFrame();
		wifiController = WifiController.instance;
	}

	void Update () {
		float dist = wifiController.GetDistanceFromSignal();

		deadlineTime -= Time.deltaTime;

		if(dist <= internetReach && !isInHotspotArea){
			//TODO: increment download speed
			uploadAmount += ((dist*dist)/(internetReach*internetReach))*Time.deltaTime;
		}
	}

	void OnGUI(){
		GUILayout.Box("Shitty placeholder UI");
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
