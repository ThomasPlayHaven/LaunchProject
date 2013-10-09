using UnityEngine;
using System.Collections;
using PlayHaven;

public class GuiManager : MonoBehaviour {

	#region Fields

	public GameObject defaultObject;
	public GameObject ourLauncher;
	
	public PlayerObject ourPlayer;
	public LevelManager ourLevelManager;

	[SerializeField]
	private GameObject _ourCamera;
	private GameObject _defaultCamera;

	[SerializeField]
	private bool _tracking = false;

	[SerializeField]
	private bool _following = false;

	public ScreenSelect curScreen = 0;
	
	private int _projectiles = 0;

	private int _goal = 0;

	[SerializeField]
	private int _score = 0;

	[SerializeField]
	private PlayHavenHandler _ourHandler;

	[SerializeField]
	private GameObject _projectile;

	private GameObject _pointCamera;

	#endregion Fields

	#region Properties

	public bool Tracking
	{
		get { return _tracking; }
		set { _tracking = value; }
	}

	public bool Following
	{
		get { return _following; }
		set { _following = value; }
	}

	public GameObject OurCamera
	{
		get { return _ourCamera; }
		set { _ourCamera = value; }
	}	
	
	public enum ScreenSelect 
	{ 
		level_select = 0, 
		in_game, pause, 
		settings, 
		projectile_select,
		playhaven_menu,
		camera_menu
	};

	
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

	
	public GameObject Projectile
	{
		get
		{
			return _projectile;
		}
		set
		{
			_projectile = value;
		}
	}

	
	
	public PlayHavenHandler ourHandler
	{
		get
		{
			return _ourHandler;
		}
		set
		{
			_ourHandler = value;
		}
	}

	#endregion

	public void Awake()
	{
		PlayHavenManager.instance.OnRewardGiven += OnPlayHavenRewardGiven; 
	}

	public void OnDestroy()
	{
		//Destroys the reward event
		PlayHavenManager.instance.OnRewardGiven -= OnPlayHavenRewardGiven; 
	}

	void PHInit()
	{
		GameObject simpleObject = GameObject.Find("PHHandler");
		ourHandler = simpleObject.GetComponent<PlayHavenHandler>();

		//ourPlayer = ourLauncher.GetComponent<PlayerObject>();
	}

		// Use this for initialization
	void Start () 
	{
		
		ourLauncher = GameObject.Find("LaunchContainer");
		ourPlayer = ourLauncher.GetComponent<PlayerObject>();
		defaultObject = GameObject.Find("LevelHandler");
		ourLevelManager = defaultObject.GetComponent<LevelManager>();
		Projectile = GameObject.Find("Cone Projectile");
		OurCamera = GameObject.Find("Main Camera");
		_pointCamera = GameObject.Find("Point Camera");
		_defaultCamera = OurCamera;
		DefaultCameraSetting();
		PHInit();
	}

	///
	//This is the meat of this class. Contains all code related to drawing on the screen.
	///
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
			if(GUI.Button(new Rect(130, 130, 50, 50), "3"))
			{
				ourLevelManager.Load(3);
				curScreen = ScreenSelect.in_game;
			}
			if(GUI.Button(new Rect(190, 130, 50, 50), "4"))
			{
				ourLevelManager.Load(4);
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
				Tracking = true;
				Following = true;

				ResetProjectile(Projectile.name);
				//Thread.Sleep(10);
				FireProjectile(Projectile.name);
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
				if(Projectile)
				{
					Explosive exp = Projectile.GetComponent<Explosive>();
					exp.Primed = true;
				}
			}
		}
		
		if(curScreen == ScreenSelect.pause)
		{
			if(GUI.Button(new Rect(10, 10, 100, 30), "Resume"))
			{
				curScreen = ScreenSelect.in_game;
			}
			if(GUI.Button(new Rect(10, 50, 100, 30), "Level Select"))
			{
				curScreen = ScreenSelect.level_select;
				ResetProjectile(Projectile.name);
			}
			if(GUI.Button(new Rect(10, 90, 100, 30), "Restart"))
			{
				curScreen = ScreenSelect.in_game;
				ResetProjectile(Projectile.name);
				ourLevelManager.ReloadLevel();
			}
			if(GUI.Button(new Rect(10, 130, 100, 30), "Main Menu"))
			{
				Application.LoadLevel("TitleScene");
			}
			if(GUI.Button(new Rect(10, 170, 120, 30), "Projectile Select"))
			{
				ResetProjectile(Projectile.name);
				curScreen = ScreenSelect.projectile_select;
			}
			if(GUI.Button(new Rect(10, 210, 120, 30), "Playhaven Debug"))
			{
				curScreen = ScreenSelect.playhaven_menu;
			}
			if(GUI.Button(new Rect(10, 250, 120, 30), "Camera Debug"))
			{
				curScreen = ScreenSelect.camera_menu;
			}
		}
		if(curScreen == ScreenSelect.projectile_select)
		{
			if(GUI.Button(new Rect(10, 10, 100, 30), "Resume"))
			{
				curScreen = ScreenSelect.in_game;
			}
			if(GUI.Button(new Rect(10, 50, 100, 30), "Cone"))
			{
				Projectile = GameObject.Find("Cone Projectile");
				//curScreen = ScreenSelect.in_game;
			}
			if(GUI.Button(new Rect(10, 90, 100, 30), "Sphere"))
			{
				Projectile = GameObject.Find("Sphere Projectile");
				//curScreen = ScreenSelect.in_game;
			}
		}
		if(curScreen == ScreenSelect.playhaven_menu)
		{
			if(GUI.Button(new Rect(10, 10, 100, 30), "Resume"))
			{
				curScreen = ScreenSelect.in_game;
			}

			if(GUI.Button(new Rect(10, 50, 100, 30), "Announcement"))
			{
				ourHandler.callContent("just_announcements");
			}

			if(GUI.Button(new Rect(10, 90, 100, 30), "Interstitial Ad"))
			{
				ourHandler.callContent("just_ads");
			}

			if(GUI.Button(new Rect(10, 130, 100, 30), "More Games"))
			{
				ourHandler.callContent("just_more_games");
			}

			if(GUI.Button(new Rect(10, 170, 100, 30), "Reward"))
			{
				ourHandler.callContent("just_rewards");
			}

			if(GUI.Button(new Rect(10, 210, 100, 30), "VGP"))
			{
				ourHandler.callContent("just_vgp");
			}
		}
		if(curScreen == ScreenSelect.camera_menu)
		{
			if(GUI.Button(new Rect(10, 10, 100, 30), "Resume"))
			{
				curScreen = ScreenSelect.in_game;
			}

			if(GUI.Button(new Rect(10, 50, 170, 30), "Toggle Camera Tracking"))
			{
				Tracking = !Tracking;
			}

			if(GUI.Button(new Rect(10, 90, 170, 30), "Toggle Camera Following"))
			{
				Following = !Following;
			}

			if(GUI.Button(new Rect(10, 130, 100, 30), "Camera Reset"))
			{
				Tracking = false;
				Following = false;
				DefaultCameraSetting();
			}


		}
		
	}

	///
	//Resets a number of parameters about a game object, thus preventing unwanted results.
	//
	//ProjectileName - String - Should be the gameobject name of what you want to reset.
	///
	public void ResetProjectile(string ProjectileName)
	{
		GameObject ourThrowableObject = GameObject.Find(ProjectileName);
		ourThrowableObject.transform.position = new Vector3(43,4,-15);
		ourThrowableObject.transform.rotation = ourPlayer.transform.rotation;
		ourThrowableObject.rigidbody.velocity = Vector3.zero;
		ourThrowableObject.rigidbody.angularVelocity = Vector3.zero;
		
	}

	public void FireProjectile()
	{
		GameObject ourThrowableObject = GameObject.Find("Sphere Projectile");
		ourThrowableObject.transform.position = new Vector3();
		ourThrowableObject.transform.rotation = ourPlayer.transform.rotation;
		ourThrowableObject.transform.position = ourLauncher.transform.position + ourPlayer.LaunchVector * 2.8f;
		ourThrowableObject.rigidbody.velocity = Vector3.zero;
		ourThrowableObject.rigidbody.AddForce(ourPlayer.LaunchVector * 1000);
		Projectiles--;
	}

	///
	//Used for firing an object based upon the name of the object.
	//
	//ProjectileName - String - Should be the gameobject name of what you want to throw.
	///
	public void FireProjectile(string ProjectileName)
	{

		//change force based on the type of object
		int forceMultipler = 0;
		if(ProjectileName == "Cone Projectile")
		{
			forceMultipler = 2000;
		}
		else
		{
			forceMultipler = 1000;
		}
		GameObject ourThrowableObject = GameObject.Find(ProjectileName);

		ourThrowableObject.transform.position = ourLauncher.transform.position + ourPlayer.LaunchVector * 2.8f;
		
		if(ProjectileName == "Cone Projectile")
		{
			ourThrowableObject.transform.Rotate(270,0,0);
		}
		
		//Investigate this
		ourThrowableObject.rigidbody.AddForce(ourPlayer.LaunchVector * forceMultipler);
		Projectiles--;
	}


	//Should handle all reward stuff
	public void OnPlayHavenRewardGiven(int id,PlayHaven.Reward reward)
	{
  		Debug.Log("Reward recieved: " + reward.name);
  		if(reward.name == "projectile_count")
  		{
  			Projectiles += reward.quantity;	
  		}
	}

	public void DefaultCameraSetting()
	{
		//OurCamera.transform.position = new Vector3(31f,4f,3f);
		/*
		if(Tracking)
		{
			Tracking = !Tracking;
		}
		if(Following)
		{
			Following = !Following;
		}
		*/
		OurCamera.transform.position = Vector3.Lerp(OurCamera.transform.position,new Vector3(31f,4f,3f), Time.deltaTime);

		OurCamera.transform.LookAt(_pointCamera.transform);
	}

	public void CameraLookAt(GameObject look)
	{
		OurCamera.transform.LookAt(look.transform);
	}

	public void CameraFollow(GameObject follow)
	{

		Vector3 followAltered =  new Vector3(follow.transform.position.x + 5, follow.transform.position.y + 5,follow.transform.position.z);
		OurCamera.transform.position = Vector3.Lerp(OurCamera.transform.position,followAltered, Time.deltaTime);
	}

	public void CameraDetermine(GameObject firedObject)
	{
		//Debug.Log("Velocity X is: " + firedObject.rigidbody.velocity.x);
		//Debug.Log("Velocity Y is: " + firedObject.rigidbody.velocity.y);
		//Debug.Log("Velocity Z is: " + firedObject.rigidbody.velocity.z);
		if(firedObject.rigidbody.velocity.x < 0.2f && firedObject.rigidbody.velocity.x > -0.2f)
		{
			if(firedObject.rigidbody.velocity.y < 0.2f && firedObject.rigidbody.velocity.y > -0.2f)
			{
				if(firedObject.rigidbody.velocity.z < 0.2f && firedObject.rigidbody.velocity.z > -0.2f)
				{
					//Debug.Log("Determined to be not moving");
					Tracking = false;
					Following = false;
					DefaultCameraSetting();
				}
				else
				{
					Tracking = true;
					Following = true;
				}
			}
			else
				{
					Tracking = true;
					Following = true;
				}
		}
		else
				{
					Tracking = true;
					Following = true;
				}
	}


	
	// Update is called once per frame
	void Update () 
	{
		CameraDetermine(Projectile);
		if(Tracking)
		{
			CameraLookAt(Projectile);
		}
		if(Following)
		{
			CameraFollow(Projectile);
		}
		if(Tracking == false && Following == false)
		{
			DefaultCameraSetting();
		}
	}

	void OnDrawGizmos()
	{
		//Gizmos.color = Color.yellow;
		//Gizmos.DrawRay(ourLauncher.transform.position, ourPlayer.LaunchVector *3);
	}
}
