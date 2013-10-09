using UnityEngine;
using System.Collections;
using PlayHaven;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private PlayHavenHandler _ourHandler;

	private bool paused;
	private bool dismissed = false;

	
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

	void init()
	{
		GameObject simpleObject = GameObject.Find("PHHandler");
		ourHandler = simpleObject.GetComponent<PlayHavenHandler>();

		//ourPlayer = ourLauncher.GetComponent<PlayerObject>();
	}

	// Use this for initialization
	void Start () {
		init();
		ourHandler.doOpen();
		ourHandler.callContent("just_ads");

		PlayHaven.PlayHavenManager.instance.OnDismissContent += WasDismissed;
	//CHANGES
	}

	void OnApplicationPause(bool pauseStatus)
	{
		paused = pauseStatus;
		if(!paused && !dismissed)
		{
			//ourHandler.doOpen();
			//ourHandler.callContent("just_ads");
		}

		if(dismissed)
			dismissed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void WasDismissed(int id, PlayHaven.DismissType type)
	{
		Debug.Log("Dismissed ID: " + id + " Dismissed Type: " + type);
	}
}
