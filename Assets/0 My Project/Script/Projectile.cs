using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    [SerializeField]
    private bool hit;
    private Animator anim;
    [SerializeField]
    private BoxCollider2D boxCollider;
    private float projectile_lifetime;
    [SerializeField]
    private Rigidbody2D rb;

    private void Awake() {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
		this.transform.Translate(movementSpeed, 0, 0);
		projectile_lifetime += Time.deltaTime;
		if (projectile_lifetime > 2)
		{
			Deactivate();
		}
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //kalau hit sesuatu
        hit = true;
         
        boxCollider.enabled = false;
        anim.SetTrigger("explodes");  

		//kalau hit enemy
		if(collision.gameObject.tag == "Enemy"){
			collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
		}
         
    }

    //menentukan arah projectile
    public void SetDirection(float projectile_direction)
    {
        projectile_lifetime = 0;
        direction = projectile_direction;
        //untuk menentukan projectile masih ada
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != projectile_direction)
        {
            localScaleX = -localScaleX;
        }
		Debug.Log("localScaleX: " + localScaleX);
		Debug.Log("direction: " + direction);
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

	
}
