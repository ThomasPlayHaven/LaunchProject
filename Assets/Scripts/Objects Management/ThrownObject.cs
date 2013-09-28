using UnityEngine;
using System.Collections;

public class ThrownObject : MonoBehaviour {

	[SerializeField]
	private bool explosionPowerUp = false;

	public bool ExplosionPowerUp
	{
		get
		{
			return explosionPowerUp;
		}
		set
		{
			explosionPowerUp = value;
		}
	}

	private GameObject ourPS_Obj;
	private ParticleSystem ourPS_PS;

	// Use this for initialization
	void Start () {
		ourPS_Obj = this.gameObject;
		//ourPS_Obj.FindChild
		ourPS_PS = ourPS_Obj.GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ExplosionPowerUp)
		{
			if(ourPS_PS.isPlaying)
			{
				//do nothing
			}
			else if(ourPS_PS.isStopped || ourPS_PS.isPaused)
			{
				ourPS_PS.Play();
			}
		}
		if(!ExplosionPowerUp)
		{
			if(ourPS_PS.isPlaying)
			{
				ourPS_PS.Stop();
			}
			else if(ourPS_PS.isStopped || ourPS_PS.isPaused)
			{
				//Do nothing
			}
		}
	
	}
}
