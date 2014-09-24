using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Blended steering: fetches all the ISteeringAlgorithms the gameObject has, and
/// calculates a weighted blend of the results
/// </summary>
/// <warning>
/// If there are two or more BlendedSteering, getLinearSteering will enter in an
/// infinite loop
/// </warning>
public class WeightedBlendedSteering : ISteeringAlgorithm
{
	public List<ISteeringAlgorithm> steeringAlgorithms = new List<ISteeringAlgorithm>();
	
	#region ISteeringAlgorithm implementation
	public override Vector3 getLinearSteering ()
	{

		Vector3 result = Vector3.zero;
		if (steeringAlgorithms.Count > 0)
		{
			foreach (ISteeringAlgorithm steeringAlgorithm in steeringAlgorithms)
			{
				// Do not take into account the BlendedSteering
				// warning
				if (steeringAlgorithm == this)
				{
					// Do not take into account the BlendedSteering
					continue;
				}
				
				result += steeringAlgorithm.getLinearSteering() * steeringAlgorithm.weight;
			}
		}
		return result;
	}
	#endregion
}
