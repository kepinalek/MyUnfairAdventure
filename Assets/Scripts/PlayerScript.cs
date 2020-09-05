using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour
{
	GameObject start, check;
	Text checkTxt;
	Rigidbody2D rb;
	float dirX;
	public LayerMask groundLayer;
    public GameObject bodyPart;
	bool canDie = true;
	public bool dead, kenaJamur, inputEnabled = true;
	public AudioSource deadSound, jumpSound;

    [SerializeField]
    float moveSpeed = 5f, jumpForce = 700f;

    bool facingRight = true;
    Vector3 localScale, localScale3;

    private Animator anim;

	// Use this for initialization
	void Start ()
	{
		SaveSystem.SaveToDisk();
		
		if (SaveSystem.GetInt("Checkpoint") == 0)
			start = GameObject.Find("Startpoint");
		else
			start = GameObject.Find("Checkpoint");
		
		transform.position = start.transform.position;
        localScale = transform.localScale;
		localScale3 = transform.localScale * 3;
		
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		check = GameObject.Find("Checkpoint");
		checkTxt = check.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
		checkTxt.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		dirX = CrossPlatformInputManager.GetAxis("Horizontal");

		if (inputEnabled)
			if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown("up") || Input.GetKeyDown("w"))
				Jump();
	}
	
	void FixedUpdate()
    {
		if (inputEnabled)
		{
			rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
		
			if (dirX > 0)
				anim.SetBool("isWalking", true);
			else
			if (dirX < 0)
				anim.SetBool("isWalking", true);
			else anim.SetBool("isWalking", false);
		}
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
            localScale3.x *= -1;
		}
		if (kenaJamur)
			transform.localScale = localScale3;
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
        if (target.gameObject.tag == "Deadly" || target.gameObject.tag == "Enemy" || target.gameObject.tag == "PlayerBig")
        {
            StartCoroutine(OnExplode());
        }
		
		if (target.gameObject.name == "Mushroom")
        {
			StartCoroutine(HitMushroom());
        }
    }
	
	IEnumerator OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            StartCoroutine(OnExplode());
        }
		
		if (target.name == "Checkpoint")
		{
			check.transform.GetChild(0).transform.localScale *= new Vector2(-1, 1);
			Destroy(check.GetComponent<BoxCollider2D>());
			
			if (SaveSystem.GetInt("Checkpoint") == 0)
			{
				SaveSystem.SetInt("Checkpoint", 1);
				checkTxt.enabled = true;
				
				
				for (float i = 1; i >= 0; i -= Time.deltaTime)
				{
					checkTxt.transform.position += new Vector3(0, i * Time.deltaTime, 0);
					checkTxt.color = new Color(1, 1, 1, i);
					yield return null;
				}
			}
		}
		
		if (target.name == "Finishpoint")
		{
			Destroy(GameObject.Find("BGM"));
			SaveSystem.SetBool(SceneManager.GetActiveScene().name + "Cleared", true);
			SaveSystem.SetBool("DialogOn", true);
			
			if (SceneManager.GetActiveScene().name == "Stage1")
			{
				SaveSystem.SetInt("Checkpoint", 0);
				SceneManager.LoadScene("Stage2");
			}
			else if (SceneManager.GetActiveScene().name == "Stage2")
			{
				SaveSystem.SetInt("Checkpoint", 0);
				SceneManager.LoadScene("Stage3");
			}
			else if (SceneManager.GetActiveScene().name == "Stage3")
			{
				SaveSystem.SetInt("Checkpoint", 0);
				SceneManager.LoadScene("Stage4");
			}
			else if (SceneManager.GetActiveScene().name == "Stage4")
			{
				SaveSystem.SetInt("Checkpoint", 0);
				SceneManager.LoadScene("Stage5");
			}
			else
			{
				SceneManager.LoadScene("Congratulation");
				Destroy(GameObject.Find("BGM"));
				Destroy(GameObject.Find("Script"));
				SaveSystem.SetBool("finish", true);
			}
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
				print("mati");
		
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
					SaveSystem.SaveToDisk();
				}
			}
		}
    }
	
	IEnumerator HitMushroom()
	{
		gameObject.tag = "PlayerBig";
		kenaJamur = true;
		transform.position += new Vector3(0, 1, 0);
		
		yield return new WaitForSeconds(2);
		
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		SaveSystem.SetInt("Live", SaveSystem.GetInt("Live") - 1);
		
		if (SaveSystem.GetInt("Live") <= 0)
		{
			SaveSystem.SetInt("Death", SaveSystem.GetInt("Death") + 1);
			SaveSystem.SetString("Stage", SceneManager.GetActiveScene().name);
			SceneManager.LoadScene("GameOver");
			SaveSystem.SaveToDisk();
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