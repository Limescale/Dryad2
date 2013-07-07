using UnityEngine;
using System.Collections;

public class DestroyOnClicked : MonoBehaviour {
	
	private Ray touchRay;
	
	private GameObject _connectedBody;
	
	[SerializeField]
	private GameObject _cube;
	
	void OnCollisionEnter( Collision other )
	{
		if ( other.gameObject.tag == "floor" )
		{
			Destroy( gameObject, 1 );
			//Destroy( gameObject );
		}
	}
	
	private void BreakBranch()
	{
		rigidbody.useGravity = true;
		Destroy( gameObject.GetComponent<FixedJoint>() );
		GameSettings.Instance.SetBranches( -1 );
		_connectedBody.GetComponent<GrowBranch>().SetNumberOfConnected( -1 );
	}
	
	void OnMouseDown()
	{
		print ( "working?" );
		if ( gameObject.GetComponent<Rot>().IsRotting() )
		{
			print ( "cut ");
			BreakBranch();
			gameObject.GetComponent<FixedJoint>().connectedBody = null;
			gameObject.GetComponent<GrowBranch>().enabled = false;
		}
	}
	
	private void BreakBranchOnTouch()
	{
		foreach ( Touch touch in Input.touches )
		{
			if ( touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled && gameObject.GetComponent<Rot>().IsRotting() )
			{
				touchRay = Camera.main.ScreenPointToRay( new Vector3( touch.position.x, touch.position.y, Camera.main.nearClipPlane ) );
				RaycastHit hitinfo;
				if ( _cube.collider.Raycast( touchRay, out hitinfo, 10000.0f ) )
				{
					BreakBranch();
					Handheld.Vibrate();
				}
				Debug.DrawRay( touchRay.origin, touchRay.direction*200, Color.green, 0 );	
			}
		}
	}

	// Use this for initialization
	void Start () {
		_connectedBody = gameObject.GetComponent<FixedJoint>().connectedBody.gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
		BreakBranchOnTouch();
	
	}
}
