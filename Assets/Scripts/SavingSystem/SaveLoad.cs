using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad
{

	public static string SAVING_PATH = Application.persistentDataPath + "/savedGames.gd";
	public static Game savedGame = new Game ();
	public static GameObject player;
	public static Camera cam;


	//it's static so we can call it from anywhere
	public static  void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (SAVING_PATH); //you can call it anything you want
		bf.Serialize (file, savedGame);
		file.Close ();
	}
	
	public static void Load ()
	{
		if (File.Exists (SAVING_PATH)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (SAVING_PATH, FileMode.Open);
			savedGame = (Game)bf.Deserialize (file);
			file.Close ();
		}
	}

	public static void ContinueGame ()
	{
		Load ();
	}

	public static void SaveGame ()
	{
		Save ();		
	}

	public static void getPlayer ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	public static void newGame ()
	{
		File.Delete (SAVING_PATH);
	}
	
}