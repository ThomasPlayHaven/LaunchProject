using UnityEngine;
using System.Collections;

public class TitleGuiManager : MonoBehaviour {

	//Gui Elements Start
	[SerializeField]
	private float _offsetW = 0;

	public float OffsetW
	{
		get
		{
			return _offsetW;
		}
		set
		{
			_offsetW = value;
		}
	}

	[SerializeField]
	private int _offsetH = 0;

	public int OffsetH
	{
		get
		{
			return _offsetH;
		}
		set
		{
			_offsetH = value;
		}
	}

	[SerializeField]
	public Texture2D logo;

	[SerializeField]
	public Texture2D optionsTex;

	[SerializeField]
	public Texture2D creditsTex;

	[SerializeField]
	public Texture2D storeTex;

	[SerializeField]
	public Texture2D powerTex;

	[SerializeField]
	public Texture2D projectileTex;
	//Gui Elements End

	[SerializeField]
	private PlayHavenHandler _ourHandler;

	
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

	//Options Elements Start
	[SerializeField]
	private int _musicVolume = 100;

	public int MusicVolume
	{
		get
		{
			return _musicVolume;
		}
		set
		{
			_musicVolume = value;
		}
	}

	[SerializeField]
	private int _soundVolume = 100;

	public int SoundVolume
	{
		get
		{
			return _soundVolume;
		}
		set
		{
			_soundVolume = value;
		}
	}
	//Options Elements End

	//For swipe
	private Vector2 _swipeOrigin = Vector2.zero;
	private Vector2 _swipeDestination = Vector2.zero;
	private bool swipeWasActive = false;

	//A simple enum to know what screen we are currently on
	enum State
	{
		Title,
		Credits,
		Options,
		Store,
		PowerUps,
		SpecialObjects
	};

	State ourState;


	void Init()
	{
		GameObject simpleObject = GameObject.Find("PHHandler");
		ourHandler = simpleObject.GetComponent<PlayHavenHandler>();
		ourState = State.Title;

		OffsetW = 0;
		OffsetH = 0;

	}

	// Use this for initialization
	void Start () {
		Init();
		ourHandler.doOpen();
		Input.multiTouchEnabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {

		//OffsetW++;

		 if (Input.touchCount == 1) 
		{
            ProcessSwipe();
            //OffsetW = _swipeDestination.x;
        }
        /*		
		else if(Input.GetMouseButton(1))
		{

			//OffsetW--;
			OffsetW -= Mathf.Clamp(Input.mousePosition.x,-20.0f,20.0f);
			//OffsetW -= Input.mousePosition.x;
			Debug.Log("Mouse X: " + (int)Input.mousePosition.x);
		}
		*/
		OffsetW = Mathf.Clamp(OffsetW,-900,0);
	}

	
	//Basically one giant state machine.

	void OnGUI()
	{
		GUI.BeginGroup(new Rect(0 + OffsetW,0 + OffsetH,Screen.width,Screen.height));
		//Default State aka Title Screen
		if(ourState == State.Title)
		{
			GUI.Label(new Rect(Screen.width / 2 - (logo.width/2 - 25), 40, logo.width, logo.height), logo);

			if (GUI.Button(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 80, 50, 50), "Play"))
			{
				Application.LoadLevel("GameScene");
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 20 , 60, 50), "Options"))
			{
				ourState = State.Options;
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 40, 60, 50), "Store"))
			{
				ourState = State.Store;
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 100, 60, 50), "Credits"))
			{
				ourState = State.Credits;
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 45, Screen.height / 2 + 160, 90, 50), "More Games"))
			{
				ourHandler.callContent("more_games");
			}

		}
		//Options Screen
		if(ourState == State.Options)
		{
			GUI.Label(new Rect(Screen.width/2 - (optionsTex.width/2 - 25), 40, optionsTex.width, optionsTex.height), optionsTex);
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 100, 50), "Return to Title"))
			{
				ourState = State.Title;
			}

			//Music Volume Start
			if (GUI.RepeatButton(new Rect(Screen.width / 2 - 85, Screen.height / 2, 20, 50), "-"))
			{
				if(MusicVolume != 0)
				{
					MusicVolume--;
				}
			}

			GUI.Box(new Rect(Screen.width / 2 - 60, Screen.height / 2, 120, 50), "Music Volume:" + MusicVolume);

			if (GUI.RepeatButton(new Rect(Screen.width / 2 + 65, Screen.height / 2, 20, 50), "+"))
			{
				if(MusicVolume != 100)
				{
					MusicVolume++;
				}
			}
			//Music Volume End


			//Sound Volume Start
			if (GUI.RepeatButton(new Rect(Screen.width / 2 - 85, Screen.height / 2 + 65, 20, 50), "-"))
			{
				if(SoundVolume != 0)
				{
					SoundVolume--;
				}
			}

			GUI.Box(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 65, 120, 50), "Sound Volume:" + SoundVolume);

			if (GUI.RepeatButton(new Rect(Screen.width / 2 + 65, Screen.height / 2 + 65, 20, 50), "+"))
			{
				if(SoundVolume != 100)
				{
					SoundVolume++;
				}
			}
			//Sound Volume End
		}
		//Credits Screen
		if(ourState == State.Credits)
		{
			GUI.Label(new Rect(Screen.width/2 - (creditsTex.width/2 - 25), 40, creditsTex.width, creditsTex.height), creditsTex);
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 50), "Return to Title"))
			{
				ourState = State.Title;
			}
		}
		//Store Screen
		if(ourState == State.Store)
		{
			GUI.Label(new Rect(Screen.width/2 - (storeTex.width/2 - 25), 40, storeTex.width, storeTex.height), storeTex);
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 50), "Return to Title"))
			{
				ourState = State.Title;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 30, 100, 50), "Power Ups"))
			{
				ourState = State.PowerUps;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 90, 100, 50), "Special Throwables"))
			{
				ourState = State.SpecialObjects;
			}
		}
		//Store Subscreen - Power Ups Screen
		if(ourState == State.PowerUps)
		{
			GUI.Label(new Rect(Screen.width/2 - (storeTex.width/2 - 25), 40, powerTex.width, powerTex.height), powerTex);
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 50), "Return to Store"))
			{
				ourState = State.Store;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 30, 100, 50), "Buy Explosion"))
			{
				//Handle Buy Code
			}
		}
		//Store Subscreen - Special Objects Screen
		if(ourState == State.SpecialObjects)
		{
			GUI.Label(new Rect(Screen.width/2 - (storeTex.width/2 - 25), 40, projectileTex.width, projectileTex.height), projectileTex);
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 50), "Return to Store"))
			{
				ourState = State.Store;
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 30, 100, 50), "Buy Cone"))
			{
				//Handle Buy Code
			}
		}
		GUI.EndGroup();
	}

	//This is where we calculate how much to swipe
	public void ProcessSwipe()
	{	 

		//Makes sure that we are at exactly 2 touch inputs
		if(Input.touchCount < 1)
		{
			Debug.Log("Less than 2 inputs");
			return;
		}

		//YOU'VE GOT THE TOUCH
		Touch theTouch = Input.touches[0];
		//If for whatever reason the delta is zero cancel out
		/*
		if(theTouch.deltaPosition == Vector2.zero)
		{
			Debug.Log("The Touch contained no delta");
			return;
		}
		*/

		/*
		Vector2 speedVector = theTouch.deltaPosition * theTouch.deltaTime;

		float currentSpeed = speedVector.magnitude * 300;

		bool swipeActive = (currentSpeed > 1.0f);

		Debug.Log("Current swipe speed is: " +currentSpeed);
		Debug.Log("Is swipe active?: " + swipeActive);

		if(swipeActive)
		{
			if( !swipeWasActive) 
			{
				Debug.Log("Swipe origin updated");
				_swipeOrigin = theTouch.position;
			}
		}
		else
		{
			if(swipeWasActive)
			{
				_swipeDestination = theTouch.position;
				Debug.Log("Swipe Complete");
			}
		}

		swipeWasActive = swipeActive;
		*/
		
		Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition * 20;
        if(touchDeltaPosition.x > 2.0f || touchDeltaPosition.x < -2.0f)
        {
          	OffsetW += Mathf.Clamp(touchDeltaPosition.x,-50.0f,50.0f);
        }
        
        Debug.Log("Touch Delta Position X: " + touchDeltaPosition.x);
        Debug.Log("OffsetW: " + OffsetW);
	}
}
