using UnityEngine;
using System.Collections;

public class DestroyOnClicked : MonoBehaviour {
	
	private Ray touchRay;
	
	private GameObject _connectedBody;
	
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
		print ( "cut ");
		BreakBranch();
		//gameObject.GetComponent<FixedJoint>().connectedBody = null;
		//gameObject.GetComponent<GrowBranch>().enabled = false;
	}
	
	private void BreakBranchOnTouch()
	{
		foreach ( Touch touch in Input.touches )
		{
			if ( touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled )
			{
				touchRay = Camera.main.ScreenPointToRay( touch.position );
				RaycastHit hitinfo;
				if ( collider.Raycast( touchRay, out hitinfo, 100.0f ) )
				{
					BreakBranch();
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		_connectedBody = gameObject.GetComponent<FixedJoint>().connectedBody.gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
