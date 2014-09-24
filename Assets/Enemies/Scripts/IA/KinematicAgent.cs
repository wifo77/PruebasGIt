using UnityEngine;
using System.Collections;

public class KinematicAgent : MonoBehaviour {
	
	public Vector3 rotation;
	public Vector3 velocity;
	
	
	/// <summary>
	/// The max speed at which the character can travel
	/// </summary>
	public float maxSpeed = 5.0f;
	
	/// <summary>
	/// The max acceleration for the character
	/// </summary>
	public float maxAcceleration = 5.0f;
	
	/// <summary>
	/// The max rotation at which the character can turn
	/// </summary>
	public float maxRotation = 80.0f;
	
	/// <summary>
	/// The max angular acceleration for the character
	/// </summary>
	public float maxAngularAcceleration = 5.0f;
	
	/// <summary>
	/// The steering algorithm used to move the character
	/// </summary>
	public ISteeringAlgorithm steeringAlgorithm;
	
	/// <summary>
	/// True if the instance is stopped and not updating with
	/// the algorithm output, false otherwise (default)
	/// </summary>
	protected bool mIsStopped = false;
	public bool isStopped
	{
		get { return mIsStopped; }
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		if (isStopped)
		{
			return;
		}
		
		
		// Update velocity
		if (steeringAlgorithm != null)
		{
			velocity = steeringAlgorithm.getLinearSteering();
			
			// Cap velocity to be, at max, maxSpeed
			if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
			{
				velocity.Normalize();
				velocity *= maxSpeed;
			}
			
			rotation = steeringAlgorithm.getAngularSteering();
			if (rotation.sqrMagnitude > maxRotation * maxRotation)
			{
				rotation.Normalize();
				rotation *= maxRotation;
			}
		
			float time = Time.deltaTime;
			
			// Update position and rotation
			transform.Translate(velocity * time, Space.World);
			transform.Rotate(rotation * time, Space.World);
		}
	}
	
	public virtual void SimulatePositionUpdate (out Vector3 nextPosition)
	{
		// Store temporary values
		Vector3 previousVelocity = velocity;
		
		bool previouslyStopped = mIsStopped;
		mIsStopped = false;
		Update();
		mIsStopped = previouslyStopped;
		
		float time = Time.deltaTime;
		nextPosition = transform.position;
		
		transform.Translate(-velocity * time, Space.World);
		velocity = previousVelocity;
	}
	
	
	/// <summary>
	/// Stop updating the agent with its steering algorithm and stops the moving.
	/// </summary>
	public void Stop ()
	{
		mIsStopped = true;
		
		velocity = Vector3.zero;
		rotation = Vector3.zero;
	}
	
	/// <summary>
	/// Starts moving again after being stopped, updating with the steering
	/// algorithm's output.
	/// </summary>
	public void Play ()
	{
		mIsStopped = false;
	}
}
