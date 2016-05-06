using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20f;
	private Rigidbody playerRigidbody;
	[SerializeField]
	private RandomSouncPlayer playerFootSteps;



	// Use this for initialization
	void Start () {
		
		// Gather the Animator components from the Player GameObject.
		playerAnimator = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		// Gather input from the keyboard
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");

		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
	}

	void FixedUpdate(){
		
		// If Player's movement vector does not equal zero...
		if (movement != Vector3.zero) {

			// ... then create a target rotation based on the movement vector...
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

			// ... and create another rotation that moves from the current rotation to the target rotation...
			Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, turningSpeed + Time.deltaTime);

			// ... and change the player's rotation to the new incremental rotation.
			playerRigidbody.MoveRotation(newRotation);

			// then play the "jump" animation.
			playerAnimator.SetFloat ("Speed", 3f);

			// play footstep sounds...
			playerFootSteps.enabled = true;

			// otherwise, don't play the "jump" animation.
		} else {
			playerAnimator.SetFloat ("Speed", 0f);

			// don't play footstep sounds
			playerFootSteps.enabled = false;
		}
	}
}
