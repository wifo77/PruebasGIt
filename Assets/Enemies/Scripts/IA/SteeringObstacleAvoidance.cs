using UnityEngine;
using System.Collections;

public class SteeringObstacleAvoidance : SteeringSeek
{
	/// <summary>
	/// Distance at which the obstacle should be avoided
	/// (i.e: how far from the obstacle the character can pass)
	/// </summary>
	/// <remarks>
	/// It should be greater than character's radius
	/// </remarks>
	public float avoidDistance = 2.0f;
	
	/// <summary>
	/// Distance to check for collisions
	/// </summary>
	public float lookAheadDistance = 2.0f;
	
	/// <summary>
	/// The layer mask to filter physics for casting the ray only
	/// against some layers
	/// </summary>
	public LayerMask layerMask;
	
	
	#region ISteeringAlgorithm implementation
	public override Vector3 getLinearSteering ()
	{
		// Create a ray in front of the character to check for obstacles
		Ray ray = new Ray(transform.position, agent.velocity);
		
		Debug.DrawLine(transform.position, transform.position + agent.velocity);
		
		// Cast the ray to check collisions
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (ray, out hit, lookAheadDistance, layerMask.value))
		{
			// If there is collision, go to (~ seek) a point to avoid it
			base.targetPos = hit.point + hit.normal * avoidDistance;
			Debug.DrawRay(hit.point, hit.normal, Color.red, 3.0f);
			
			return base.getLinearSteering();
		}
		else
		{
			// While there is no collision, just keep walking
			return Vector3.zero;
		}
	}
	#endregion
}
