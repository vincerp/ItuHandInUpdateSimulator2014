using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CapsuleCollider))]
public class CapsuleHighlight : MonoBehaviour {

	public Color gizmoColor = Color.green;

	void OnDrawGizmos(){
		CapsuleCollider col = GetComponent<CapsuleCollider>();
		float rad = col.radius;
		Vector3 pos = col.center - Vector3.up * rad;
		float height = col.height - rad*2f;

		pos = transform.position + pos;
		Gizmos.color = gizmoColor;
		Gizmos.DrawWireSphere(pos, rad);

		pos += Vector3.up * height;
		Gizmos.DrawWireSphere(pos, rad);
	}
}
