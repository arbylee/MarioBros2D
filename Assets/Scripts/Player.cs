using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public LayerMask groundLayer;

	private Animator marioAnimator;
	private Rigidbody2D rb;
	private float speed = 4f;
	private float jumpSpeed = 350f;
	private Transform groundCheck;
	private float overlapRadius = 0.1f;

	void Awake () {
		marioAnimator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		groundCheck = transform.FindChild ("GroundCheck");
	}

	void FixedUpdate () {
		float moveSpeed = Input.GetAxis ("Horizontal");
		marioAnimator.SetFloat ("Speed", Mathf.Abs(moveSpeed));
		bool isGrounded = IsGrounded ();
		marioAnimator.SetBool("isTouched", isGrounded);

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isGrounded) {
				rb.AddForce (Vector2.up * jumpSpeed, ForceMode2D.Force);
				isGrounded = false;
			}
		}


		if (moveSpeed > 0) {
			transform.localScale = new Vector2 (1f, 1f);
		} else if (moveSpeed < 0){
			transform.localScale = new Vector2 (-1f, 1f);
		}
		rb.velocity = new Vector2(moveSpeed * speed, rb.velocity.y);
	}

	bool IsGrounded() {
		return Physics2D.OverlapCircle (groundCheck.position, overlapRadius, groundLayer);
	}
}
