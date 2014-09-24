using UnityEngine;
using System.Collections;

/// <summary>
/// Steering agent is a kind of Kinematic agent that interprets the input
/// from the steering algorithm as accelerations rather than velocities
/// </summary>
public class SteeringAgent : KinematicAgent
{
	/// <summary>
	/// The factor to transform between physics and "manual" physics accelerations
	/// </summary>
	public float accelerationfactor = 5.0f;
	
	/// <summary>
	/// True to update position and rotation using physics instead, false to use
	/// the manual update
	/// </summary>
	public bool shouldUsePhysicsInstead = true;
	
	
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
			float time = Time.deltaTime;
			
			// This increment must be done in two steps, because when steering's algorithm modify the velocity
			// the variable velocity is not modified correctly.
			Vector3 increment = steeringAlgorithm.getLinearSteering();
			if (increment.sqrMagnitude > maxAcceleration * maxAcceleration)
			{
				increment = increment.normalized * maxAcceleration;
			}
			velocity += increment * time;
			
			// Cap velocity to be, at max, maxSpeed
			if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
			{
				velocity.Normalize();
				velocity *= maxSpeed;
			}
		
			// Modified version: do not "fly" around
			velocity.y = 0.0f;
			
			// Update position
			if (shouldUsePhysicsInstead)
			{
				rigidbody.AddForce(increment * accelerationfactor * Time.timeScale);
			}
			else
			{
				transform.Translate(velocity * time, Space.World);
			}
			
			// Same for rotation
			increment = steeringAlgorithm.getAngularSteering();
			if (increment.sqrMagnitude > maxAngularAcceleration * maxAngularAcceleration)
			{
				increment = increment.normalized * maxAngularAcceleration;
			}
			rotation += increment * time; 
			
			if (rotation.sqrMagnitude > maxRotation * maxRotation)
			{
				rotation.Normalize();
				rotation *= maxRotation;
			}
			
			// Update rotation
			if (shouldUsePhysicsInstead)
			{
				rigidbody.AddTorque(increment * accelerationfactor);
			}
			else
			{
				transform.Rotate(rotation * time, Space.World);
			}
			
		}
	}
	
	/// <summary>
	/// The limit factor for the maximum speeds, used when converting from physics update
	/// to "manual" update.
	/// 
	/// 1.14 was set comparing several "physics" troops moving with their respective "manual"
	/// counterparts
	/// </summary>
	public float speedLimitFactor = 1.14f;
	
	void FixedUpdate ()
	{
		// Can't update kinematic's velocities
		if (shouldUsePhysicsInstead && !rigidbody.isKinematic)
		{
			if (rigidbody.velocity.magnitude > maxSpeed * speedLimitFactor)
		    {
		           rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed * speedLimitFactor;
		    }
			
			if (rigidbody.angularVelocity.magnitude > maxRotation * speedLimitFactor)
		    {
		           rigidbody.angularVelocity = rigidbody.angularVelocity.normalized * maxRotation * speedLimitFactor;
		    }
		}
	}
	
}
