using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
	
	private Animator animator;
	private PlayerMovement playerMovement;
	private PlayerInventory playerInventory;
	
	private void Awake() {
		animator = GetComponentInChildren<Animator>();
		playerMovement = GetComponentInParent<PlayerMovement>();
		playerInventory = GetComponentInParent<PlayerInventory>();
	}
	
	void Update() {
		if (playerMovement.GetMov() != Vector2.zero) {
			Vector2 movement = playerMovement.GetMov();
			animator.SetFloat("Horizontal", movement.x);
			animator.SetFloat("Vertical", movement.y);
		}

		animator.SetBool("IsMoving", playerMovement.IsMoving());
		animator.SetBool("IsCarrying", playerInventory.IsCarrying());
	}
}