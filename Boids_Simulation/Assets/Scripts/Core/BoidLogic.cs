using UnityEngine;
using System.Collections.Generic;

public class BoidLogic : MonoBehaviour
{
    Vector3 SeparationAlgorithm(BoidAgent self, List<BoidAgent> otherAgents, float protectedRange, float avoidFactor)
    {
        float CloseX = 0f;
        float CloseY = 0f;

        foreach (BoidAgent agent in otherAgents)
        {
            if (agent == self) continue;
            float distance = Vector3.Distance(self.transform.position , agent.transform.position);
            if(distance <= protectedRange)
            {
                CloseX += self.transform.position.x - agent.transform.position.x;
                CloseY += self.transform.position.y - agent.transform.position.y;
            }
        }
        float DirectX = CloseX * avoidFactor;
        float DirectY = CloseY * avoidFactor;
        return new Vector3(DirectX, DirectY, 0);
    }

    Vector3 AlignmentAlgorithm()
    {
        return new Vector3(0, 0, 0);
    }

    Vector3 CohesionAlgorithm()
    {
        return new Vector3(0, 0, 0);
    }
}
