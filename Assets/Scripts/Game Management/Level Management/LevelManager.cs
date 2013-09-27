using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public List<GameObject> Levels = new List<GameObject>();

	public GameObject currentLevel;
	public GuiManager guiMan;
	public int currentLevelNumber = 0;

	public void Load(int levelNumber)
	{
		levelNumber--;
		if (levelNumber >= 0 && levelNumber < Levels.Count)
		{
			//Need to increment back up to 1 because we're silly and already decremented to index approprate numbers
			currentLevelNumber = levelNumber+1;
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
			Debug.Log("Trying to Load a level that does not exist.");
		}
	}
	
	public void ReloadLevel()
	{
		Load(currentLevelNumber);
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
