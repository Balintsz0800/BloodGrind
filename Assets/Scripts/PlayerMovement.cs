using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 movementVector;
    public float speed;
    
    Animation animation;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animation = GetComponent<Animation>();
    }
    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
        
        animation.horizontal = movementVector.x;
        movementVector *= speed;
        rigid.linearVelocity = movementVector;
    }
}
