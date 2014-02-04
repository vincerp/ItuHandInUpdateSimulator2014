using UnityEngine;
using System.Collections;

public class MobileHotspot : MonoBehaviour {
	
	public const string ENTERED = "OnHotspotEnter";
	public const string EXITED = "OnHotspotExit";

	void OnTriggerEnter (Collider col) {
		if(col.tag == "Player") col.SendMessage(ENTERED, SendMessageOptions.DontRequireReceiver);
	}
	
	void OnTriggerExit (Collider col) {
		if(col.tag == "Player") col.SendMessage(EXITED, SendMessageOptions.DontRequireReceiver);
	}
}
