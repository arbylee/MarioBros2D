using UnityEngine;
using System.Collections;

public class Goomba : MonoBehaviour {
	private Animator animator;
	void Awake () {
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		animator.SetBool ("Dead", true);
		Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (rb.velocity.x, 0);
		rb.AddForce (Vector2.up * 350f, ForceMode2D.Force);
		Invoke("DestroySelf", 1);
	}

	void DestroySelf() {
		Destroy (gameObject);
	}
}
