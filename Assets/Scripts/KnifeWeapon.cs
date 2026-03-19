using UnityEngine;

public class KnifeWeapon : MonoBehaviour
{
    public GameObject knifePrefab;
    public float damage = 2f;
    public float speed = 11f;
    public float fireRate = 1.1f;

    private float timer;
    private PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 dir = new Vector2(playerMovement.lastHorizontalVector, playerMovement.lastVerticalVector);

        if (dir == Vector2.zero)
            dir = Vector2.right;
        else
            dir.Normalize();

        GameObject knife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
        
        Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();
        rb.linearVelocity = dir * speed;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        knife.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}