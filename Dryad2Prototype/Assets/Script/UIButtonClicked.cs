using UnityEngine;
using System.Collections;

public class UIButtonClicked : MonoBehaviour
{
	public enum Action
	{
		Story,
		Arcade,
		Endless,
		HighScore,
		Achivements,
		Music,
		SFX,
		Facebook,
		Twitter,
	}
	
	public Action action;

	void OnClick ()
	{
		if ( action == Action.Story )
		{
			Debug.Log ("Story Mode Start");
		}
		else if ( action == Action.Arcade )
		{
			Debug.Log ("Arcade Mode Start");	
		}
		else if ( action == Action.Endless )
		{
			Debug.Log ("Endless Mode Start");	
		}
		else if ( action == Action.HighScore )
		{
			Debug.Log ("Highscore Table");	
		}
		else if ( action == Action.Achivements )
		{
			Debug.Log ("Achivements");	
		}
		else if ( action == Action.Music )
		{
			Debug.Log ("Music Toggle");	
		}
		else if ( action == Action.SFX )
		{
			Debug.Log ("SFX Toggle");	
		}
		else if ( action == Action.Facebook )
		{
			Application.OpenURL ("http://www.facebook.com");
			Debug.Log ("Open Facebook");	
		}
		else if ( action == Action.Twitter )
		{
			Application.OpenURL ("http://www.Twitter.com");
			Debug.Log ("Open Twitter");	
		}
		else
		{
			Debug.Log ("You've not set an action on this button dickhead");	
		}
	}
}
