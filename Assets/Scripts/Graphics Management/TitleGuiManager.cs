using UnityEngine;
using System.Collections;

public class TitleGuiManager : MonoBehaviour {

	[SerializeField]
	public Texture2D logo;

	[SerializeField]
	public Texture2D optionsTex;

	[SerializeField]
	public Texture2D creditsTex;

	[SerializeField]
	public Texture2D storeTex;

	private PlayHavenHandler _ourHandler;

	[SerializeField]
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

			if (GUI.Button(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 40, 50, 50), "Play"))
			{
				Application.LoadLevel("GameScene");
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 20, 60, 50), "Options"))
			{
				ourState = State.Options;
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 80, 60, 50), "Store"))
			{
				ourState = State.Store;
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 140, 60, 50), "Credits"))
			{
				ourState = State.Credits;
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 + 180, 60, 50), "More Games"))
			{
				ourHandler.callContent("more_games");
			}

		}
		if(ourState == State.Options)
		{
			GUI.Label(new Rect(Screen.width/2 - (optionsTex.width/2 - 25), 40, optionsTex.width, optionsTex.height), optionsTex);
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 50), "Return to Title"))
			{
				ourState = State.Title;
			}
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
