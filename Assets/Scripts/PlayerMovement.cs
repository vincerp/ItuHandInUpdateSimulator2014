using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxVel = 2f;
	public float maxArmsH = 340;
	public float minArmsH = 20;

	public Transform arms;
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
			rigidbody.MoveRotation(rigidbody.rotation*(Quaternion.Euler(Vector3.up*-horizontalRotationSpeed)));
		}

		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.UP))
		{
			arms.Rotate(Vector3.right*-verticalLaptopMovementSpeed);
			//if (arms.localEulerAngles.x > 340 || arms.localEulerAngles.x <= 0)

		}



		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.DOWN))
		{
			//if (arms.localEulerAngles.x )
			arms.Rotate(Vector3.right*verticalLaptopMovementSpeed);

		}

		if (arms.localEulerAngles.x < maxArmsH && arms.localEulerAngles.x > 180)
			arms.localRotation = Quaternion.Euler(maxArmsH,0,0);

		if (arms.localEulerAngles.x > minArmsH && arms.localEulerAngles.x < 180)
		{arms.localRotation = Quaternion.Euler(minArmsH,0,0);}

		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.A))
		{

		}
		
		if(ChainJam.GetButtonPressed(ChainJam.PLAYER.PLAYER1,ChainJam.BUTTON.B))
		{

		}

		 
	}
}