using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {
	public Transform Target;
	public GameObject bullet;
	public bool interact;
	public bool interactItemGrabbed;
	public bool rockGrabbed;
	public bool canInteractBool;
	public float firingAngle = 45.0f;
	public float gravity = 9.8f;
	Color normalColor;
	public GameObject sprite1;
	public GameObject sprite2;    
	public Transform myTransform;
	public float maxSpeed;
	public int hp = 3;
	public int energy = 0;
	bool facingRight = true;
	Rigidbody2D rb;
	bool groundedLeft = false;
	bool groundedRight = false;
	public bool grounded = false;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	bool Move;
	public bool canHide;
	public bool hidden;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround; //cosa il character deve considerare ground es. il terreno, i nemici...
	public float jumpForce;	

	void Awake () {
		normalColor = GetComponentInChildren<SpriteRenderer> ().color;
		Target.GetComponentInChildren<SpriteRenderer> ().enabled = false;
		rb = GetComponent<Rigidbody2D> ();
		Move = true;
		canHide = false;
		hidden = false;
		canInteractBool = false;
		interact = false;
		rockGrabbed = false;

	}

	
	// Update is called once per frame
	void Update () {
		if (rockGrabbed) {
			Target.GetComponentInChildren<SpriteRenderer> ().enabled = true;
		} else {
			Target.GetComponentInChildren<SpriteRenderer> ().enabled = false;
		}
	
		Movement ();
		RockThrow ();
		Interact ();

	}


	void RockThrow(){
		if (Input.GetKeyDown (KeyCode.G) && !hidden && rockGrabbed) {
			rockGrabbed = false;

			rb.velocity = new Vector2(0,0);
			Move = false;
			StartCoroutine(SimulateProjectile());
		}
	}


	void Interact(){
		if (Input.GetKeyDown (KeyCode.H) && canInteractBool == true) {
			interact = true;
			canInteractBool = false;
		} else {
			interact = false;
		}
	}

	void Movement () {
		if(Input.GetKey(KeyCode.F) && grounded){
			maxSpeed = 1;
		}
			else {
			maxSpeed = 3;
		}
		/*
		if (Input.GetKeyDown (KeyCode.H)) {
			anim.Play("respawn");
		}
		if (Input.GetKeyDown (KeyCode.J)) {
			anim.Play("flare");
		}	
		*/

		if(Input.GetKeyDown(KeyCode.UpArrow) && canHide){
			GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Middleground";
			gameObject.layer = 8;
			hidden = true;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Foreground";
			gameObject.layer = 9;
			hidden = false;
		}
		/*if ( grounded  && (Input.GetKeyDown (KeyCode.Joystick1Button0) || Input.GetKeyDown (KeyCode.Space)) && rb.velocity.y<=0.5) {

			rb.AddForce (new Vector2 (0, jumpForce));
		}*/

			groundedLeft = Physics2D.OverlapCircle (groundCheckLeft.position, groundRadius, whatIsGround);
			groundedRight = Physics2D.OverlapCircle (groundCheckRight.position, groundRadius, whatIsGround);
			grounded = groundedLeft || groundedRight;
		
			float move = Input.GetAxis ("Horizontal");
			// e quindi a far cambiare l'animazione da idle a run
			if (Move) {
			rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);
		}
			if (move > 0 && !facingRight) {
				Flip ();
			} else if (move < 0 && facingRight) {
				Flip ();
			}
		}



	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public bool isSlow(){
		if (maxSpeed == 3) {
			return false;
		} else {
			return true;
		}
	}


	IEnumerator SimulateProjectile()
	{

		GameObject bulletClone;
		bulletClone = Instantiate(bullet, myTransform.position, myTransform.rotation)as GameObject;
		// Short delay added before Projectile is thrown
		//yield return new WaitForSeconds(1.5f);
		
		// Move projectile to the position of throwing object + add some offset if needed.
		bulletClone.transform.position = myTransform.position + new Vector3(0, 0.0f, 0);
		// Calculate distance to target
		float target_Distance = Vector3.Distance(bulletClone.transform.position, Target.position);
		
		// Calculate the velocity needed to throw the object to the target at specified angle.
		float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
		
		// Extract the X  Y componenent of the velocity
		float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
		float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
		
		// Calculate flight time.
		float flightDuration = target_Distance / Vx;
		
		// Rotate projectile to face the target.
		bulletClone.transform.rotation = Quaternion.LookRotation(Target.position - bulletClone.transform.position);
		
		float elapse_time = 0;
		
		while (elapse_time < flightDuration)
		{
		
			bulletClone.transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
			
			elapse_time += Time.deltaTime;
			
			yield return null;
		}
		bulletClone.GetComponent<Rigidbody2D> ().isKinematic = false;

	}  

	/*
	public void changeSprite(){
		if (sprite1.activeSelf) {
			sprite1.SetActive(false);
			sprite2.SetActive(true);
		} else {
			sprite1.SetActive(true);
			sprite2.SetActive(false);
		
		}
	}*/
	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("HidePlace")) {
			canHide = true;
		}
	
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("HideTrigger")) {
			canHide = false;
			GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Foreground";
			gameObject.layer = 9;
			hidden = false;
		}
		
	}
	public void canMove(bool move){
		Move = move;
	}

	public void canInteract(bool trigger){
		canInteractBool = trigger;
	}

	public bool checkInteract(){
		return interact;
	}

	public void setInteract(bool trigger){
		interact = trigger;
	}

	public bool checkItemGrabbed(){
		return !(rockGrabbed || interactItemGrabbed);
	}
	public void setRockGrabbed(){
		rockGrabbed = true;
	}






	
}
