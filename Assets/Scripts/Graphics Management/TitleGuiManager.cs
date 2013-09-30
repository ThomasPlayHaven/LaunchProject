using UnityEngine;
using System.Collections;

public class TitleGuiManager : MonoBehaviour {

	[SerializeField]
	private int _offset = 0;

	public int Offset
	{
		get
		{
			return _offset;
		}
		set
		{
			_offset = value;
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

	//A simple enum to know what screen we are currently on
	enum State
	{
		Title,
		Credits,
		Options,
		Store
	};

	State ourState;


	void Init()
	{
		GameObject simpleObject = GameObject.Find("PHHandler");
		ourHandler = simpleObject.GetComponent<PlayHavenHandler>();
		ourState = State.Title;

		Offset = Screen.width / 2;

	}

	// Use this for initialization
	void Start () {
		Init();
		ourHandler.doOpen();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(ourState == State.Title)
		{
			GUI.Label(new Rect(Screen.width/2 - (logo.width/2 - 25), 40, logo.width, logo.height), logo);

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
		if(ourState == State.Credits)
		{
			GUI.Label(new Rect(Screen.width/2 - (creditsTex.width/2 - 25), 40, creditsTex.width, creditsTex.height), creditsTex);
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 50), "Return to Title"))
			{
				ourState = State.Title;
			}
		}
		if(ourState == State.Store)
		{
			GUI.Label(new Rect(Screen.width/2 - (storeTex.width/2 - 25), 40, storeTex.width, storeTex.height), storeTex);
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 50), "Return to Title"))
			{
				ourState = State.Title;
			}
		}
	}
}
