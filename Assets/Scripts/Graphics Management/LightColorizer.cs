using UnityEngine;
using System.Collections;

public class LightColorizer : MonoBehaviour {

	public float duration = 1.0F;
	public float t = 0.0f;
	public float effector = 0.0f;
    public Color color0 = Color.red;
    public Color color1 = Color.blue;
    public Color color2 = Color.green;
    public Color lastColor;
 

    public enum colorState
    {
    	Red,
    	Purple,
    	Blue,
    	Teal,
    	Green,
    	Yellow
    };

    public colorState ourCS;

    void start()
    {
    	ourCS = colorState.Red;
    	//light.color = color0;
    	lastColor = color2;
    }

    void Update() {
    	//Gives a cool bounce effect
        effector = Mathf.PingPong(((Time.time)/2), duration) / duration;
        //Determines how long it takes to switch colors
        t = ((Time.time/16) % duration*3)/ duration;

        //Calculates when to switch color state
        if((int)(t % 3) == 0)
        {
        	if(ourCS == colorState.Red)
        	{

        	}
        	else
        	{
        		ourCS = colorState.Red;
        		lastColor = light.color;
        	}
    	}
    	else if((int)(t % 3) == 1)
        {
        	if(ourCS == colorState.Blue)
        	{

        	}
        	else
        	{
        		ourCS = colorState.Blue;
        		lastColor = light.color;
        	}
    	}
    	else if((int)(t % 3) == 2)
        {
        	if(ourCS == colorState.Green)
        	{

        	}
        	else
        	{
        		ourCS = colorState.Green;
        		lastColor = light.color;
        	}
    	}


    	//tells the system what color to lerp
    	if(ourCS == colorState.Red)
    	{
    		light.color = Color.Lerp(lastColor, color0, effector);
    		
    	}

    	else if(ourCS == colorState.Blue)
    	{
    		light.color = Color.Lerp(lastColor, color1, effector);
    		
    	}

    	else if(ourCS == colorState.Green)
    	{
    		light.color = Color.Lerp(lastColor, color2, effector);
    	
    	}



    	
    }
}
