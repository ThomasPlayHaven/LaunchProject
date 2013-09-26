using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public List<GameObject> Levels = new List<GameObject>();

	public GameObject currentLevel;
	public GuiManager guiMan;

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
			
			//Get level information and set level score.
			LevelInformation li = currentLevel.GetComponent<LevelInformation>();
			guiMan.Goal = li.goalScore;
			guiMan.Score = 0;
			guiMan.Projectiles = li.shots;
			
		}
		else
		{
			Debug.Log("Trying to load a level that does not exist.");
		}
		
		
	}

	// Use this for initialization
	void Start () {
		currentLevel = new GameObject();
		
		GameObject guiManObj = GameObject.Find("GraphicsManager");
		guiMan = guiManObj.GetComponent<GuiManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
