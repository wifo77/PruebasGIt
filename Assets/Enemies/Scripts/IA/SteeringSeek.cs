using UnityEngine;
using System.Collections;

public class SteeringSeek : ISteeringAlgorithm
{
	public GameObject t;
	public Transform target;
	public float radius;

	void Start () {
		t=GameObject.FindGameObjectWithTag("coche");
		target = t.transform;
		//target = GameObject.Find("coche")as Transform;
	}

	
	/// <summary>
	/// A bit hack here: subclasses can set target to null and
	/// indicate a targetPos to seek instead
	/// </summary>
	public Vector3 targetPos
	{
		get
		{
			return mTargetPos;
		}
		set
		{
			mTargetPos = value;
			mTargetPos.y = 0;
		}
	}
	
	#region ISteeringAlgorithm implementation
	public override Vector3 getLinearSteering ()
	{
		Vector3 result;
		if (target == null)
		{
			result = targetPos - agent.transform.position;
		}
		else
		{
			result = target.position - agent.transform.position;
		}
		
		float distance = result.magnitude;
		if (distance < radius)
		{
			// If so, we shouldn't move
			return Vector3.zero;
		}
		
		result.Normalize();
		
		if (agent != null)
		{
			result = result * agent.maxAcceleration;
		}
		
		return result;
	}
	#endregion
}
