using UnityEngine;
using System.Collections;

/// <summary>
/// "Interface" for kinematic algorithms.
/// It is a class for convenience, as it can subclass MonoBehaviour
/// and be used directly in the editor and as a component.
/// Also, some properties can be assigned here
/// </summary>
public class ISteeringAlgorithm : MonoBehaviour
{
	public KinematicAgent agent;
	
	/// <summary>
	/// The target position is used by SteeringSeek and SteeringArrive
	/// is necessary to use in SteeringSeekPath (method getLinearSteering ())
	/// </summary>
	public Vector3 mTargetPos;
	
	/// <summary>
	/// The weight, used by some behavoir "mixers"
	/// </summary>
	public float weight = 1.0f;
	
	
	/// <summary>
	/// Returns the linear velocity from the steering algorithm
	/// </summary>
	/// <returns>
	/// The linear steering as a Vector3
	/// </returns>
	public virtual Vector3 getLinearSteering ()
	{
		return Vector3.zero;
	}
	
	/// <summary>
	/// Returns the angular velocity from the steering algorithm
	/// </summary>
	/// <returns>
	/// The angular steering as a Quaternion
	/// </returns>
	public virtual Vector3 getAngularSteering ()
	{
		return Vector3.zero;
	}
}
