using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float forwardSpeed = 1f;
	
	public float horizontalRotationSpeed = 1f;
	public float verticalLaptopMovementSpeed = 1f;

	
	void Update () {

		rigidbody.velocity = Vector3.right*forwardSpeed;

		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.RIGHT))
		{
			rigidbody.trasform.rotation = Quaternion.Euler(Vector3.up*horizontalRotationSpeed);
		}

		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.LEFT))
		{
			rigidbody.trasform.rotation = Quaternion.Euler(Vector3.up*(-horizontalRotationSpeed));
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
