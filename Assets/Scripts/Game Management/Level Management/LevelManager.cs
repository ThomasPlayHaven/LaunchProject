using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public List<GameObject> Levels = new List<GameObject>();

	public GameObject currentLevel;

	public void load(int levelNumber)
	{
		levelNumber--;
		if (levelNumber >= 0 && levelNumber < Levels.Count)
		{
			if(currentLevel != null)
			{
				Destroy(currentLevel);
			}
			currentLevel = (GameObject)Instantiate(Levels[levelNumber]);
			currentLevel.SetActive(true);
		}
		else
		{
			Debug.Log("Trying to load a level that does not exist.");
		}

	}

	// Use this for initialization
	void Start () {
		currentLevel = new GameObject();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
