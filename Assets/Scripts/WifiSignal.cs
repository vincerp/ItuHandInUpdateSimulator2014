using UnityEngine;
using System.Collections;

public class WifiSignal : MonoBehaviour {
	
	private Transform _tr;
	
	public Vector3 position{
		get{
			return _tr.position;
		}
	}

	private void Start(){
		_tr = transform;
	}

	private void OnDrawGizmos(){
		if(collider && collider is SphereCollider){
			float radius = (collider as SphereCollider).radius;
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, radius);
			Gizmos.color = new Color(0.8f, 1f, 0.8f, 0.2f);
			Gizmos.DrawSphere(transform.position, radius);
		}
	}
}
