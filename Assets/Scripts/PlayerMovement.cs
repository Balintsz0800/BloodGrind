using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    [HideInInspector] public Vector3 movementVector;
    public float speed;
    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;
    
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

        if (movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }

        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }
        
        animation.horizontal = movementVector.x;
        movementVector *= speed;
        rigid.linearVelocity = movementVector;
    }
}
