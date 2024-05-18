using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    private Vector2 mov;
    public float speed = 5f;
    public bool canMove,useBoot = false;
    public bool canRun = false;
    public bool timeOut = false;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update() {
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mov.Normalize();
    }

    private void FixedUpdate() {
        if (canMove || useBoot)
        {
            rb.velocity = mov * speed;
        }
        
        
    }

    public Vector2 GetMov() {
        return mov;
    }

    public bool IsMoving() {
        return mov != Vector2.zero;
    }

}
