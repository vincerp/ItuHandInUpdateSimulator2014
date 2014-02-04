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
}
