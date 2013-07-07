using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {
 
    // Static singleton property
    public static GameSettings Instance { get; private set; }
 
    void Awake()
    {
        // First we check if there are any other instances conflicting
        if(Instance != null && Instance != this)
        {
            // If that is the case, we destroy other instances
            Destroy(gameObject);
        }
 
        // Here we save our singleton instance
        Instance = this;
 
        // Furthermore we make sure that we don't destroy between scenes (this is optional)
        DontDestroyOnLoad(gameObject);
    }
	
	//=======================================================================
	
	private float _timer = 0.0f;
	
	//[SerializeField]
	//private float _growthInterval = 1.0f;
	
	[SerializeField]
	private int _maxNumberOfBranches = 30;
	
	private int _numberOfBranches = 0;
	
//	public float GetTime()
//	{
//		return _timer;
//	}
//	
//	private void ResetTimer()
//	{
//		_timer = 0.0f;
//	}
//	
//	public bool UpdateTimer()
//	{
//		_timer += Time.deltaTime;
//		if ( _growthInterval < _timer )
//		{
//			_timer = 0.0f;
//			return true;
//		}
//		return false;
//	}
	
	public bool IsBranchLimitMet()
	{
		if ( _numberOfBranches < _maxNumberOfBranches )
		{
			return false;
		}
		return true;
	}
	
	public int GetBranches()
	{
		return _numberOfBranches;
	}
	
	public void SetBranches( int n )
	{
		_numberOfBranches += n;
	}
	
	public int GetMaxBranches()
	{
		return _maxNumberOfBranches;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKey( KeyCode.A ) )
		{
			print ( _numberOfBranches );
		}
		//UpdateTimer();	
	}
}
