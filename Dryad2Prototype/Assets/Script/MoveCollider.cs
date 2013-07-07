using UnityEngine;
using System.Collections;

public class MoveCollider : MonoBehaviour {
	
	private void MoveOnTouch()
	{
		foreach ( Touch touch in Input.touches )
		{
			if ( touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled )
			{
				Ray touchRay = Camera.main.ScreenPointToRay( new Vector3( touch.position.x, touch.position.y, Camera.main.nearClipPlane ) );
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//MoveOnTouch();
	
	}
}
