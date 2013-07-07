using UnityEngine;
using System.Collections;

public class MoveCollider : MonoBehaviour {
	
	private void MoveOnTouch()
	{
		foreach ( Touch touch in Input.touches )
		{
			if ( touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled )
			{
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
