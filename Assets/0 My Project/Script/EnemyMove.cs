using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] public float xmin = -5f;
    [SerializeField] public float xmax = 5f;

    public float direction = 1f;

    private SpriteRenderer spriteRenderer;
    public EnemyMelee enemyMelee;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyMelee = GetComponent<EnemyMelee>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(!enemyMelee.CheckPlayer() && !CheckAnimationHurt()){
            Move();
        }
        FlipIfNeeded();
    }

    private void Move()
    {
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0f, 0f);
    }

    public void FlipIfNeeded()
    {
        if (transform.position.x <= xmin && direction < 0f)
        {
            Flip();
        }
        else if (transform.position.x >= xmax && direction > 0f)
        {
            Flip();
        }
    }

    public void Flip()
    {
        direction *= -1f;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public bool CheckAnimationHurt(){
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt");
    }
}
