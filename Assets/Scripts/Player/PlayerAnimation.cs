using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
	
	private Animator animator;
	private PlayerMovement playerMovement;
	
	private void Awake() {
		animator = GetComponentInChildren<Animator>();
		playerMovement = GetComponent<PlayerMovement>();
	}
	
	void Update() {
		if (playerMovement.GetMov() != Vector2.zero) {
			Vector2 movement = playerMovement.GetMov();
			animator.SetFloat("Horizontal", movement.x);
			animator.SetFloat("Vertical", movement.y);
		}

		animator.SetBool("IsMoving", playerMovement.IsMoving());
	}
}