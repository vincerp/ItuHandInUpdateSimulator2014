using UnityEngine;
using System.Collections;

public class MobileHotspot : MonoBehaviour {
	
	void OnTriggerEnter (Collider col) {
		if(col.tag == "Player") GameController.instance.OnHotspotEnter();
	}
	
	void OnTriggerExit (Collider col) {
		if(col.tag == "Player") GameController.instance.OnHotspotExit();
	}

	private void OnDrawGizmos(){
		if(collider && collider is SphereCollider){
			float radius = (collider as SphereCollider).radius;
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, radius);
			Gizmos.color = new Color(1f, 0.8f, 0.8f, 0.2f);
			Gizmos.DrawSphere(transform.position, radius);
		}
	}
}
