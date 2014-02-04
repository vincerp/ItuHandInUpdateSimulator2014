using UnityEngine;
using System.Collections;

public class MobileHotspot : MonoBehaviour {
	
	public const string ENTERED = "OnHotspotEnter";
	public const string EXITED = "OnHotspotExit";

	void OnTriggerEnter (Collider col) {
		col.SendMessage(ENTERED, SendMessageOptions.DontRequireReceiver);
	}
	
	void OnTriggerExit (Collider col) {
		col.SendMessage(EXITED, SendMessageOptions.DontRequireReceiver);
	}
}
