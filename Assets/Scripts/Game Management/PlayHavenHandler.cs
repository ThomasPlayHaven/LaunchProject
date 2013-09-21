using UnityEngine;
using System.Collections;
using PlayHaven;

public class PlayHavenHandler : MonoBehaviour 
{

	public void callContent(string placementName)
	{
		PlayHaven.PlayHavenManager.instance.ContentRequest(placementName);
	}

	public void doOpen()
	{
		PlayHaven.PlayHavenManager.instance.OpenNotification();
		Debug.Log("Finished doing an Open");
	}
}
