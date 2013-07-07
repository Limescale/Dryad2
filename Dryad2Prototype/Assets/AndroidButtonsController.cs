using UnityEngine;
using System.Collections;

public class AndroidButtonsController : MonoBehaviour {
	
	private void GetInput()
	{
		if ( Input.GetKey(KeyCode.Escape) )
		{
			Application.Quit();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
	}
}
