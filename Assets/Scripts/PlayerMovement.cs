using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 movementVector;
    public float speed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }
    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
        
        movementVector *= speed;
        rigid.linearVelocity = movementVector;
    }
}
