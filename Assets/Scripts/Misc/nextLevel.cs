using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.CompareTag ("Player")) {

			//SaveLoad.savedGame.firstGame=false;
			SaveLoad.savedGame.level++;
			cameraManager.instance.cameraFade();
			
			SaveLoad.SaveGame();

		}
	}
}
