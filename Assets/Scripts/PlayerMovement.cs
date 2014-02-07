using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxVel = 2f;

	
	public float horizontalRotationSpeed = 1f;
	public float verticalLaptopMovementSpeed = 1f;

	
	void Update () {

		//rigidbody.angularVelocity = Vector3.forward*forwardSpeed;

		//transform.Translate(Vector3.forward * Time.deltaTime);

		rigidbody.AddRelativeForce(0, 0, 10);
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVel);





		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.RIGHT))
		{
			rigidbody.MoveRotation(rigidbody.rotation*(Quaternion.Euler(Vector3.up*horizontalRotationSpeed)));
		}

		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.LEFT))
		{
			rigidbody.MoveRotation(rigidbody.rotation*(Quaternion.Euler(Vector3.up*(-horizontalRotationSpeed))));
		}

		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.UP))
		{

		}

		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.DOWN))
		{

		}
		
		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.A))
		{

		}
		
		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.B))
		{

		}

		 
	}
}
