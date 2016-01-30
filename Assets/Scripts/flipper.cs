using UnityEngine;
using System.Collections;

public class flipper : MonoBehaviour {

	bool isLeft = true;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if ((isLeft == true && player.transform.position.x > transform.position.x) || (isLeft == false && player.transform.position.x < transform.position.x))
		{
			Flip();
		}
	
	}
	public void Flip()
	{
		transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
		isLeft = !isLeft;
	}
}
