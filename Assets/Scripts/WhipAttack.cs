using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using System.Collections;

public class WhipAttack : MonoBehaviour
{
    [SerializeField] private float AttackTime = 4f;
    private float timer;
    
    [SerializeField] GameObject LeftWhip;
    [SerializeField] GameObject RightWhip;
    
    PlayerMovement playerMovement;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);
    [SerializeField] int whipDamage = 1;

    void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        timer = AttackTime;

        if (playerMovement.lastHorizontalVector > 0)
        {
            RightWhip.SetActive(true);
            Collider2D[] Rcolliders =  Physics2D.OverlapBoxAll(RightWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(Rcolliders);

            yield return new WaitForSeconds(0.3f);
            
            LeftWhip.SetActive(true);
            Collider2D[] Lcolliders =  Physics2D.OverlapBoxAll(LeftWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(Lcolliders);
        }
        else
        {
            LeftWhip.SetActive(true);
            Collider2D[] Lcolliders =  Physics2D.OverlapBoxAll(LeftWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(Lcolliders);
            
            yield return new WaitForSeconds(0.3f);
            
            RightWhip.SetActive(true);
            Collider2D[] Rcolliders =  Physics2D.OverlapBoxAll(RightWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(Rcolliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Enemy enemy = colliders[i].GetComponent<Enemy>();
            if (enemy != null)
            {
                colliders[i].GetComponent<Enemy>().TakeDamage(whipDamage);
            }
        }
    }
}
