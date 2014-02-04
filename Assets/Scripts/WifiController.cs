using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WifiController : MonoBehaviour {

	public static WifiController instance;

	public Transform laptopPosition;
	public WifiSignal activeSignal;
	public List<WifiSignal> signals;

	public float laptopYMultiplyier = 1f; //makes Y move more "drastic"

	private void Start(){
		instance = this;
	}

	public float GetDistanceFromSignal(){
		if(null == activeSignal || null == laptopPosition){
			Debug.LogError("Something is wrong!");
			return Mathf.Infinity;
		}

		Vector3 playerPos = laptopPosition.position + Vector3.up * laptopYMultiplyier;
		Vector3 signalPosition = activeSignal.position;

		float distance = Vector3.Distance(playerPos, signalPosition);

		return distance;
	}

	public void ChangeActiveSignal(){
		//change it here!
		//random signal, not the last
		int currentIndex = signals.IndexOf(activeSignal);
		int max = signals.Count - 1;
		int random;
		do{
			random = Random.Range(0, max);
		} while (random == currentIndex);

		activeSignal = signals[random];

		Debug.Log("WiFi Spot changed to " + activeSignal.name);
	}
}
