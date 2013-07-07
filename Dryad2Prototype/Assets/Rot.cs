using UnityEngine;
using System.Collections;

public class Rot : MonoBehaviour {
	
	[SerializeField]
	private GameObject _cube;
	
	[SerializeField]
	private bool _rotting = false;
	
	private float _timer = 0.0f;
	[SerializeField]
	private float _rotTimer = 4.0f;
	
	[SerializeField]
	private bool _isTrunk = false;
	
	public bool IsRotting()
	{
		if ( _rotting )
		{
			return true;
		}
		return false;
	}
	
	public bool HasBranches()
	{
		if ( gameObject.GetComponent<GrowBranch>().ConnectedBranches() == 0 )
		{
			return false;
		}
		else
		{
			return true;
		}
	}
	
	private void SetCubeColour( Color color )
	{
		_cube.gameObject.renderer.material.color = color;
	}
	
	void CheckConnectedForRot()
	{
		if ( !_isTrunk )
		{
			if ( gameObject.GetComponent<FixedJoint>().connectedBody.GetComponent<Rot>().IsRotting() )
			{
				//RotBranch();
				Destroy( gameObject.GetComponent<FixedJoint>() );
				rigidbody.useGravity = true;
				GameSettings.Instance.SetBranches( -1 );
				//_connectedBranches--;
				this.enabled = false;
			}
		}
	}
	
	public void RotBranch()
	{
		_rotting = true;
		SetCubeColour( Color.red );	
	}
	
	public void RotConnectedBranch()
	{
		if ( !_isTrunk )
		{
			gameObject.GetComponent<FixedJoint>().connectedBody.GetComponent<Rot>().RotBranch();
		}
	}
	
	public void UpdateTimer()
	{
		if ( _rotting )
		{
			_timer += Time.deltaTime;
			if ( _timer > _rotTimer )
			{
				_timer = 0.0f;
				RotConnectedBranch();
			}
		}
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if ( !_rotting )
		{
			CheckConnectedForRot();
		}
		if ( _isTrunk && _rotting )
		{
			print ( "Game over, ye twat" );
		}
		
		UpdateTimer();
		
		if ( rigidbody.useGravity )
		{
			this.enabled = false;
		}	
	}
}
