using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class cameraManager : MonoBehaviour
{

	public float height;
	public float width;
	Camera cam;
	float currentX;
	public float nextX;
	float playerY;
	float playerX;
	float cameraX;
	float cameraY;
	float cameraZ;
	float scaleX;
	float scaleY;
	float scaleZ;
	public float moveSpeed = 1;
	float alpha;
	bool fading;
	float t;
	float levelPassageDuration = 1.25f;
	float deathDuration = 1f;
	
	bool moved;
	SpriteRenderer levelSprite;
	GameObject deathObject;
	SpriteRenderer deathSprite;
	public static cameraManager instance = null;
	bool death;
	GameObject player;
	public float playerDimension;

	// Use this for initialization
	void Start ()
	{
		// singleton
		if (instance == null) {
			instance = this;
			//DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
		player=GameObject.FindGameObjectWithTag("Player");
		death = false;
		deathObject = gameObject.transform.FindChild ("deathSprite").gameObject;
		deathSprite = deathObject.GetComponent<SpriteRenderer> ();
		changeAlpha (deathSprite, 0f);
		levelSprite = gameObject.transform.FindChild ("levelSprite").GetComponent<SpriteRenderer> ();
		changeAlpha (levelSprite, 0f);
		t = 0f;
		cam = Camera.main;
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;

		scaleX = deathObject.transform.localScale.x;
		scaleY = deathObject.transform.localScale.y;
		scaleZ = deathObject.transform.localScale.z;

		setCamera();
	}
	
	// Update is called once per frame
	void Update ()
	{
		cameraX = transform.position.x;
		cameraY = transform.position.y;
		cameraZ = transform.position.z;

		if (Input.GetKeyDown (KeyCode.Escape)) {
			cameraDeath();
		}
		/*
		if(Input.GetKeyDown(KeyCode.F)){
			cameraFade();
		}
		*/
		if (fading) {
			t += Time.deltaTime / levelPassageDuration;
			alpha = nextGaussian (t);
			Debug.Log (nextGaussian (t));
				
			if (t >= 1f) {
				t = 0f;
				fading = false;
			}

			if (t > 0.5f && !moved) {
				transform.position = new Vector3 (nextX, cameraY, cameraZ);
				moved = true;
			}
			changeAlpha (levelSprite, alpha);
		}

		if (death) {
			if(t<1f){
			t += Time.deltaTime / deathDuration;
			deathObject.transform.localScale = new Vector3 (scaleX-9.3f*t,scaleY-9.3f*t,scaleZ);
			}

			if(t>=1f){
				changeAlpha(levelSprite,1f);
			}
			
		}



	}

	public void cameraFade ()
	{
		fading = true;
		moved=false;
		nextX = cameraX + width -playerDimension;


	}

	public void cameraDeath(){
		changeAlpha(deathSprite,1f);
		deathObject.transform.position=player.transform.position;
		death = true;
	}
	
	void changeAlpha (SpriteRenderer sprite, float a)
	{
		Color color = sprite.color;
		color.a = a;
		sprite.color = color;
	}

	float nextGaussian (float x)
	{
		double sigma = 0.15;
		double mu = 0.5;
		double n1 = 1 / Math.Sqrt (2 * Math.PI * Math.Pow (sigma, 2));
		
		double n2_1 = (x - mu) / sigma;
		double n2_2 = Math.Exp (-0.5 * Math.Pow (n2_1, 2));
		
		return (float)(n1 * n2_2);
	}

	public void setCamera(){
		Vector3 cameraPos = new Vector3(player.transform.position.x+width/2-playerDimension, transform.position.y, transform.position.z);
		transform.position=cameraPos;
	}
}

