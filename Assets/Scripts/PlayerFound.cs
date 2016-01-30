using UnityEngine;
using System.Collections;

public class PlayerFound : MonoBehaviour {
	GameObject player;
	public GameObject enemy;
	float moveSpeed = 3f;
	bool attack;
	// Use this for initialization
	void Start () {
		attack = false;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (attack) {
			if (player.transform.position.x > enemy.gameObject.transform.position.x) {
				enemy.gameObject.transform.position = Vector3.MoveTowards (enemy.gameObject.transform.position, new Vector3 (player.transform.position.x - 3 , enemy.gameObject.transform.position.y, player.transform.position.z), Time.deltaTime * moveSpeed);
				enemy.GetComponent<EnemyControllerScript>().Attack();
				GameObject[] lights = GameObject.FindGameObjectsWithTag("Lights");
				for(int i=0; i<lights.Length;i++){
					lights[i].SetActive(false);
				}
				enemy.GetComponent<EnemyControllerScript>().playerFound(true);
			}else{
				enemy.gameObject.transform.position = Vector3.MoveTowards (enemy.gameObject.transform.position, new Vector3 (player.transform.position.x + 3, enemy.gameObject.transform.position.y, player.transform.position.z), Time.deltaTime * moveSpeed);
					enemy.GetComponent<EnemyControllerScript>().Attack();
				GameObject[] lights = GameObject.FindGameObjectsWithTag("Lights");
				for(int i=0; i<lights.Length;i++){
					lights[i].SetActive(false);
				}
					enemy.GetComponent<EnemyControllerScript>().playerFound(true);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			attack = true;
			player.GetComponent<CharacterControllerScript>().canMove(false);
			player.GetComponent<Rigidbody2D>().isKinematic = true;
			player.GetComponent<CharacterControllerScript>().GameOver();
			//enemy.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;


		}
	}
}
