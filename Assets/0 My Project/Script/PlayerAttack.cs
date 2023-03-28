using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private float fireballSpeed;


    //untuk fire fireball
    [SerializeField] private Transform firePoint;
    public GameObject[] fireballs;



    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && cooldownTimer > attackCooldown)
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;

        
    }

    private void Attack()
    {
        anim.SetTrigger("attack"); // blm dibuat
        cooldownTimer = 0;

        //fireball
        fireballs[CheckFireball()].transform.position = firePoint.position;
        fireballs[CheckFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    // private void Attack()
    // {
    //     anim.SetTrigger("attack"); // blm dibuat
    //     cooldownTimer = 0;

    //     //fireball
    //     // StartCoroutine(Fireball());

    //     // fireballs[CheckFireball()].transform.position = firePoint.position;
    //     // fireballs[CheckFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    // }

    // private IEnumerator Fireball()
    // {
    //     float direction = transform.localScale.x > 0 ? 1f : -1f;
    //     // Debug.Log(direction);
    //     GameObject temp = Instantiate(fireballs, firePoint.position, Quaternion.identity);
    //     fireballs.GetComponent<Projectile>().SetDirection(direction);
    //     yield return new WaitForSeconds(5f);
    //     Destroy(temp);
    // }


    private int CheckFireball()
    {
        for (int i=0; i<fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
