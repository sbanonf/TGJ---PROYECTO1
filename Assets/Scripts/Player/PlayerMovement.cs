using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    private Vector2 mov;
    public float speed = 5f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mov.Normalize();
    }

    private void FixedUpdate() {
        rb.velocity = mov * speed;
    }

    public Vector2 GetMov() {
        return mov;
    }

    public bool IsMoving() {
        return mov != Vector2.zero;
    }
}
