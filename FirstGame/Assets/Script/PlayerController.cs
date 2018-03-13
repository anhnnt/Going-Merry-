using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{	
	//Move
	public float moveSpeed;
	private Rigidbody2D myRigidbody; 

	//Jump
	public float jumpSpeed;
	public bool canDoubleJump;

	//Ground check
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;

	bool facingRight;

	public AudioClip file;
	public AudioSource shoot;

	//Reference
	private Animator myAnim; 

	public Vector3 respawnPosition;

	public LevelManager theLevelManager;

	// For shooting
	public Transform gunTip;
	public GameObject bullet;
	float fireRate = 0.5f;
	float nextFire = 0;

	//range attack
	public bool RangeAttackTrigger;
	private float attackTimer = 0;
	private float attackCd = 0.2f;

	// Use this for initialization
	void Start ()
	{	
	    myRigidbody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();

		respawnPosition = transform.position;

		theLevelManager = FindObjectOfType<LevelManager> ();

		facingRight = true;
		RangeAttackTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (transform.localEulerAngles.z != 0)
		{
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
		}

		if (Input.GetAxisRaw ("Horizontal") > 0f) 
		{
			myRigidbody.velocity = new Vector3 (moveSpeed, myRigidbody.velocity.y, 0f);
			transform.localScale = new Vector3 (1f, 1f, 1f);
			facingRight = true;
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) 
		{
			myRigidbody.velocity = new Vector3 (-moveSpeed, myRigidbody.velocity.y, 0f); 
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			facingRight = false;

		} else 
		{
			myRigidbody.velocity = new Vector3 (0f, myRigidbody.velocity.y, 0f);
		}

		if (Input.GetButtonDown ("Jump")) 
		{
			if (isGrounded) {
				myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, jumpSpeed, 0f);
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, jumpSpeed/ 1.2f, 0f);
				}
			}
		}
		if (canDoubleJump && !isGrounded && Input.GetButtonDown("Jump")) {
			canDoubleJump = false;
			myRigidbody.velocity = new Vector3 (myRigidbody.velocity.x, jumpSpeed/ 1.2f, 0f);
		}

		myAnim.SetFloat ("Speed", Mathf.Abs (myRigidbody.velocity.x));
		myAnim.SetBool ("Grounded", isGrounded);
		myAnim.SetBool ("Range", RangeAttackTrigger);
			
	}

	void FixedUpdate()
	{	
		if (Input.GetAxisRaw ("Fire2") > 0) {
			RangeAttackTrigger = true;
			fireBullet ();
			shoot.PlayOneShot (file);
			attackTimer = attackCd;
		} 

		if (RangeAttackTrigger)
		{
			if (attackTimer > 0) 
			{
				attackTimer -= Time.deltaTime;
			} else 
			{
				RangeAttackTrigger = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "KillPlane") 
		{ 
			//gameObject.SetActive (false);

			//transform.position = respawnPosition;

			theLevelManager.Respawn();
		}

		if (other.tag == "Checkpoint")
		{
			respawnPosition = other.transform.position;  
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "MovingPlatform") 
		{
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "MovingPlatform") 
		{
			transform.parent = null;
		}
	}

	public void PlayerRed()
	{
		gameObject.GetComponent<Animation> ().Play ("PlayerRed");
	}

	// shoot function
	void fireBullet ()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (facingRight) {
				Instantiate (bullet, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));

			} else if (!facingRight) {
				Instantiate (bullet, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 180)));
			}

		}
	}
}
