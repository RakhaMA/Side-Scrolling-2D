using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currHealth {get; private set;}
    private Animator anim;
    [SerializeField]
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        //menentukan max dan min 
        //min 0, max healthawal
        currHealth = Mathf.Clamp(currHealth - damage, 0, startingHealth);
        

        if (currHealth > 0)
        {
            Debug.Log("Enemy Health: " + currHealth);
            anim.SetTrigger("Hurt");
        }else 
        {
            Debug.Log("Enemy Die");
            anim.SetTrigger("Die");
            Destroy(gameObject, 0.5f);
            //GetComponent<PlayerMovement>().enabled = false;
        }
    }


}
