using UnityEngine;
using System.Collections;

public class GrowBranch : MonoBehaviour {
	
	public GameObject branch;
	public GameObject branchPoint;
	
	public GameObject gameSettings;
	
	private float timer = 0.0f;
	public float growthInterval = 2.0f;
	public float outwardGrowthRate = 0.1f;
	
	//public float growthIntervalVariance = 1.0f;
	
	public float rotationRange = 10.0f;
	private Vector3 r;
	
	private Vector3 growthRateUp;
	private Vector3 growthRateOut;
	
	[SerializeField]
	private float _targetScaleX = 1.0f;
	
	[SerializeField]
	private float _targetScaleY = 1.0f;
	
	private int _connectedBranches = 0;
	
	public int maxBranches = 3;
	private int ri;
	
//	void setGrowthInterval()
//	{
//		growthInterval += Random.Range(-growthIntervalVariance, growthIntervalVariance );
//	}
	
	public int ConnectedBranches()
	{
		return _connectedBranches;
	}
	
	void OnTriggerEnter( Collider coll )
	{
		if ( coll.gameObject.tag != "tree" )
		{
			this.enabled = false;
		}
	}
	
	void checkConnectedForCut()
	{
		if ( gameObject.GetComponent<FixedJoint>().connectedBody.useGravity )
		{
			rigidbody.useGravity = true;
			GameSettings.Instance.SetBranches( -1 );
			_connectedBranches--;
			this.enabled = false;
		}
	}
	
	private bool CheckForRotting()
	{
		if ( gameObject.GetComponent<Rot>().IsRotting() )
		{
			return true;
		}
		return false;
	}
	
	public void SetNumberOfConnected( int n )
	{
		_connectedBranches += n;
	}
	
	float getRandomRotationComponent()
	{
		return Random.Range( -rotationRange, rotationRange );
	}
	
	void growUp()
	{
		transform.localScale += growthRateUp;
	}
	
	void growOut()
	{
		transform.localScale += growthRateOut;
	}
	
	void growBranch()
	{
//		if ( gameSettings.GetComponent<GameSettings>().GetBranches() <
//				gameSettings.GetComponent<GameSettings>().GetMaxBranches() )
		if ( !GameSettings.Instance.IsBranchLimitMet() )
		{
			ri = Random.Range( 1, maxBranches );
			for ( int i = 0; i <= ri; i++ )
			{
				if ( _connectedBranches < maxBranches )
				{
					r = new Vector3( getRandomRotationComponent(), getRandomRotationComponent(), getRandomRotationComponent() );
					branchPoint.transform.Rotate( r );
					GameObject branchClone;
					branchClone = Instantiate( branch, branchPoint.transform.position, branchPoint.transform.rotation ) as GameObject;
					branchClone.GetComponent<FixedJoint>().connectedBody = rigidbody;
					branchPoint.transform.rotation = transform.rotation;
					branchClone.transform.parent = GameObject.Find ( "Branches" ).transform;
					GameSettings.Instance.SetBranches( 1 );
					_connectedBranches++;
				}
			}
		}
	}
	
	void GrowBranch2D()
	{
		if ( !GameSettings.Instance.IsBranchLimitMet() )
		{
			ri = Random.Range( 1, maxBranches );
			for ( int i = 0; i <= ri; i++ )
			{
				if ( _connectedBranches < maxBranches )
				{
					r = new Vector3( getRandomRotationComponent(), 0, 0 );
					branchPoint.transform.Rotate( r );
					GameObject branchClone;
					branchClone = Instantiate( branch, branchPoint.transform.position, branchPoint.transform.rotation ) as GameObject;
					branchClone.GetComponent<FixedJoint>().connectedBody = rigidbody;
					branchPoint.transform.rotation = transform.rotation;
					GameSettings.Instance.SetBranches( 1 );
					_connectedBranches++;
				}
			}
		}
	}
	
	void updateTimer()
	{
		timer += Time.deltaTime;
		if ( timer >= growthInterval )
		{
			growBranch();
			//GrowBranch2D();
			timer = 0.0f;
			//this.enabled = false;
		}
	}

	// Use this for initialization
	void Start () {
		//setGrowthInterval();
		transform.localScale = Vector3.one*0.01f;
//		growthRateUp = new Vector3 ( outwardGrowthRate/growthInterval, 1.0f/growthInterval, outwardGrowthRate/growthInterval )*Time.deltaTime;
//		growthRateOut = new Vector3 ( outwardGrowthRate/growthInterval, 0.0f, outwardGrowthRate/growthInterval )*Time.deltaTime;
		growthRateUp = new Vector3 ( 0, _targetScaleY/growthInterval, 0 )*Time.deltaTime;
		growthRateOut = new Vector3 ( _targetScaleX, 0, _targetScaleX )*Time.deltaTime*outwardGrowthRate;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if ( timer < growthInterval )
//		{
//			updateTimer();
//		}
//		if ( transform.localScale.y < 1 )
//		{
//			growUp();
//		}
//		else if ( transform.localScale.x < 1 )
//		{
//			growOut();
//		}
		if ( !rigidbody.useGravity && !CheckForRotting() )
		{
//			if ( timer < growthInterval )
//			{
				updateTimer();
//			}
			if ( transform.localScale.y < _targetScaleY )
			{
				growUp();
			}
			if ( transform.localScale.x < _targetScaleX )
			{
				growOut();
			}
		}
		if ( !rigidbody.useGravity )
		{
			checkConnectedForCut();
		}
	}
}
