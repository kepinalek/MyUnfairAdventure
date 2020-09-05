using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerTutorial : MonoBehaviour
{
	GameObject start, check;
	Rigidbody2D rb;
    public float dirX = 0;
	public LayerMask groundLayer;
    public GameObject bodyPart;
	bool canDie = true;
	public bool dead, kenaJamur;
	public AudioSource deadSound, jumpSound;

    [SerializeField]
    float moveSpeed = 5f, jumpForce = 700f;

    bool facingRight = true;
    Vector3 localScale;

    private Animator anim;

	// Use this for initialization
	void Start ()
	{
		if (SaveSystem.GetInt("Checkpoint") == 0)
			start = GameObject.Find("Startpoint");
		else if (SaveSystem.GetInt("Checkpoint") == 1)
			start = GameObject.Find("Checkpoint");
		else
			start = GameObject.Find("Checkpoint (1)");
		
		transform.position = start.transform.position;
        localScale = transform.localScale;
		
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		check = GameObject.Find("Checkpoint");
	}
	
	// Update is called once per frame
	void Update ()
	{
		dirX = CrossPlatformInputManager.GetAxis("Horizontal");

        if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown("up") || Input.GetKeyDown("w"))
            Jump();
	}
	
	void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
		
		if (dirX > 0)
            anim.SetBool("isWalking", true);
        else
        if (dirX < 0)
			anim.SetBool("isWalking", true);
		else anim.SetBool("isWalking", false);
    }

    void LateUpdate()
    {
		CheckWhereToFace();
    }
	
	void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else
            if (dirX < 0)
				facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
		{
            localScale.x *= -1;
		}
        else transform.localScale = localScale;
    }
	
	public void Jump()
    {
		if (rb.velocity.y == 0 || isGrounded())
		{
            rb.AddForce(Vector2.up * jumpForce);
			jumpSound.Play();
		}
    }
	
	void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            StartCoroutine(OnExplode());
			SaveSystem.SetInt("Checkpoint", 1);
        }
    }
	
	void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            StartCoroutine(OnExplode());
			SaveSystem.SetInt("Checkpoint", 2);
        }
		
		if (target.name == "Finishpoint")
		{
			Destroy(GameObject.Find("BGM"));
			SceneManager.LoadScene("MainMenu");
		}
    }
	
	public IEnumerator OnExplode()
    {
		if (canDie)
		{
			if (gameObject.tag == "Player")
			{
				dead = true;
				canDie = false;
				deadSound.Play();
			
				for (int i = 0; i < 15; i++)
				{
					transform.TransformPoint(0, -100, 0);
					GameObject clone = Instantiate(bodyPart, transform.position, Quaternion.identity) as GameObject;
					clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-50, 50));
					clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(100, 400));
				}
				Debug.Log("mati");
		
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
				rb.constraints = RigidbodyConstraints2D.FreezePositionX;
			
				yield return new WaitForSeconds(1f);
		
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				SaveSystem.SetInt("Live", SaveSystem.GetInt("Live") - 1);
		
				if (SaveSystem.GetInt("Live") <= 0)
				{
					SaveSystem.SetInt("Death", SaveSystem.GetInt("Death") + 1);
					SaveSystem.SetString("Stage", SceneManager.GetActiveScene().name);
					SceneManager.LoadScene("GameOver");
				}
			}
		}
    }
	
	bool isGrounded()
	{
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 1.0f;
    
		RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
		if (hit.collider != null)
			return true;
    
		return false;
	}
}