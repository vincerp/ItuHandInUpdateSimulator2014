using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WifiController : MonoBehaviour {
	
	public Transform player;
	public WifiSignal activeSignal;
	public List<WifiSignal> signals;

	public float GetDistanceFromSignal(){
		if(null == activeSignal || null == player){
			Debug.LogError("Something is wrong!");
			return;
		}

		Vector3 playerPos = player.position;
		Vector3 signalPosition = activeSignal.transform.position;

		float distance = Vector3.Distance(playerPos, signalPosition);

		return distance;
	}

	public void ChangeActiveSignal(){
		//change it here!
		//random signal, not the last
	}
}
