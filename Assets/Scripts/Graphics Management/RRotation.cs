using UnityEngine;
using System.Collections;

public class RRotation : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
			this.transform.Rotate(Random.value,Random.value,Random.value);

	}
}
