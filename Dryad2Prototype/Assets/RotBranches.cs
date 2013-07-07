using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotBranches : MonoBehaviour {
	
	[SerializeField]
	private int _minimumBranchesBeforeRot = 6;
	
	private void ChooseBranchToRot()
	{
		BetterList<Transform> children = new BetterList<Transform>();
		foreach ( Transform child in transform )
		{
			if ( !child.transform.GetComponent<Rot>().HasBranches() )
			{
				children.Add( child );
			}
		}
		for ( int i = 0; i < GameSettings.Instance.AmountOfBranchesToRot(); i++ )
		{
			int _branchNumber = Random.Range( 0, children.size );
			children[_branchNumber].GetComponent<Rot>().RotBranch();
		}
	}
	
	private float _rotTimer = 0.0f;
	private float _rotInterval = 5.0f;
	
	private void UpdateTimer()
	{
		if ( GameSettings.Instance.NumberOfBranches() > _minimumBranchesBeforeRot )
		{
			_rotTimer += Time.deltaTime;
			if ( _rotTimer > _rotInterval )
			{
				_rotTimer = 0.0f;
				ChooseBranchToRot();
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimer();
	
	}
}
