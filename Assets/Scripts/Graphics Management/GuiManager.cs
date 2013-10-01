using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {


	public GameObject defaultObject;
	public GameObject ourLauncher;
	public GameObject projectile;
	public PlayerObject ourPlayer;
	public LevelManager ourLevelManager;
	
	
	public enum ScreenSelect { level_select = 0, in_game, pause, settings };
	public ScreenSelect curScreen = 0;
	
	private int _projectiles = 0;
	public int Projectiles
	{
		get
		{
			return _projectiles;
		}
		set
		{
			_projectiles = value;
		}
	}
	
	private int _goal = 0;
	public int Goal
	{
		get
		{
			return _goal;
		}
		set
		{
			_goal = value;
		}
	}
	
	[SerializeField]
	private int _score = 0;
	public int Score
	{
		get
		{
			return _score;
		}
		set
		{
			_score = value;
		}
	}

		// Use this for initialization
	void Start () 
	{
		ourLauncher = GameObject.Find("LaunchContainer");
		ourPlayer = ourLauncher.GetComponent<PlayerObject>();
		defaultObject = GameObject.Find("LevelHandler");
		ourLevelManager = defaultObject.GetComponent<LevelManager>();
		projectile = GameObject.Find("Projectile");
	}

	void OnGUI()
	{
		ourPlayer.Yaw = 0;
		ourPlayer.Pitch = 0;
		
		if(curScreen == ScreenSelect.level_select)
		{
			if(GUI.Button(new Rect(10, 130, 50, 50), "1"))
			{
				ourLevelManager.Load(1);
				curScreen = ScreenSelect.in_game;
			}
			if(GUI.Button(new Rect(70, 130, 50, 50), "2"))
			{
				ourLevelManager.Load(2);
				curScreen = ScreenSelect.in_game;
			}
		}
		
		if(curScreen == ScreenSelect.in_game)
		{
			if (GUI.RepeatButton(new Rect(10, 10, 100, 30), "Down"))
			{
				
				ourPlayer.Pitch =0.5f;
				ourPlayer.updateRotation();
				//ourLauncher.Pitch += 1;
			}
			if (GUI.RepeatButton(new Rect(140, 10, 100, 30), "Left"))
			{
				
				ourPlayer.Yaw =-0.5f;
				ourPlayer.updateRotation();
				//ourLauncher.Pitch += 1;
			}
			if (GUI.RepeatButton(new Rect(10, 50, 100, 30), "Up"))
			{
				ourPlayer.Pitch =-0.5f;
				ourPlayer.updateRotation();
			}
			if (GUI.RepeatButton(new Rect(140, 50, 100, 30), "Right"))
			{
				ourPlayer.Yaw =0.5f;
				ourPlayer.updateRotation();
			}
			
			GUI.enabled = Projectiles > 0;
			if (GUI.Button(new Rect(10, 90, 100, 30), "Fire"))
			{
				GameObject ourThrowableObject = GameObject.Find("Projectile3");
				ourThrowableObject.transform.position = ourLauncher.transform.position + ourPlayer.LaunchVector * 2.8f;
				//Vector3 supertest = new Vector3(0,1000,0);
				ourThrowableObject.rigidbody.velocity = Vector3.zero;
				ourThrowableObject.rigidbody.AddForce(ourPlayer.LaunchVector * 1000);
				//PlayerObject ourThrownObject = ourLauncher.GetComponent<PlayerObject>();
				Projectiles--;
			}
			GUI.enabled = true;
			
			GUI.Box(new Rect(270,10,100,30),"");
			GUI.Label(new Rect(285,15,80,30),"Score: " + Score);
			
			GUI.Box(new Rect(380,10,100,30),"");
			GUI.Label(new Rect(395,15, 80,30),"Goal: " + Goal);
			
			GUI.Box(new Rect(490,10,100,30),"");
			GUI.Label(new Rect(505,15, 80,30),"Projectiles: " + Projectiles);
			
			if(GUI.Button(new Rect(Screen.width - 60, 10, 50, 50), "Pause"))
				curScreen = ScreenSelect.pause;
			
			if(GUI.Button(new Rect(10, 200, 100, 50), "PRIME"))
			{
				if(projectile)
				{
					Explosive exp = projectile.GetComponent<Explosive>();
					exp.Primed = true;
				}
			}
		}
		
		if(curScreen == ScreenSelect.pause)
		{
			if(GUI.Button(new Rect(10, 10, 100, 30), "Resume"))
				curScreen = ScreenSelect.in_game;
			if(GUI.Button(new Rect(10, 50, 100, 30), "Level Select"))
				curScreen = ScreenSelect.level_select;
			if(GUI.Button(new Rect(10, 90, 100, 30), "Restart"))
			{
				curScreen = ScreenSelect.in_game;
				ourLevelManager.ReloadLevel();
			}
			if(GUI.Button(new Rect(10, 130, 100, 30), "Main Menu"))
				Application.LoadLevel("TitleScene");
		}
		
	}


	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()
	{
		//Gizmos.color = Color.yellow;
		//Gizmos.DrawRay(ourLauncher.transform.position, ourPlayer.LaunchVector *3);
	}
}
