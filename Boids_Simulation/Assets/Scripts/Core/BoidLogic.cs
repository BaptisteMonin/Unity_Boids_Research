using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BoidLogic
{
    public static Vector3 SeparationAlgorithm(BoidAgent self, List<BoidAgent> otherAgents, float protectedRange, float avoidFactor)
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

    public static Vector3 AlignmentAlgorithm(BoidAgent self, List<BoidAgent> otherAgents, float visualRange, float matchingFactor)
    {
        float DirectAvgX = 0f;
        float DirectAvgY = 0f;
        int neighbourNbr = 0;

        foreach (BoidAgent agent in otherAgents)
        {
            if (agent == self) continue;
            float distance = Vector3.Distance(self.transform.position, agent.transform.position);
            if (distance <= visualRange)
            {
                DirectAvgX += agent.Velocity.x;
                DirectAvgY += agent.Velocity.y;
                neighbourNbr += 1;
            }
        }
        if(neighbourNbr > 0)
        {
            DirectAvgX = DirectAvgX / neighbourNbr;
            DirectAvgY = DirectAvgY / neighbourNbr;
        }
        float DirectX = (DirectAvgX - self.Velocity.x) * matchingFactor;
        float DirectY = (DirectAvgY - self.Velocity.y) * matchingFactor;
        return new Vector3(DirectX, DirectY, 0);
    }

    public static Vector3 CohesionAlgorithm(BoidAgent self, List<BoidAgent> otherAgents, float visualRange, float centeringFactor)
    {
        float PosAvgX = 0f;
        float PosAvgY = 0f;
        int neighbourNbr = 0;

        foreach (BoidAgent agent in otherAgents)
        {
            if (agent == self) continue;
            float distance = Vector3.Distance(self.transform.position, agent.transform.position);
            if (distance <= visualRange)
            {
                PosAvgX += agent.transform.position.x;
                PosAvgY += agent.transform.position.y;
                neighbourNbr += 1;
            }
        }
        if (neighbourNbr > 0)
        {
            PosAvgX = PosAvgX / neighbourNbr;
            PosAvgY = PosAvgY / neighbourNbr;
        }
        float DirectX = (PosAvgX - self.transform.position.x) * centeringFactor;
        float DirectY = (PosAvgY - self.transform.position.y) * centeringFactor;
        return new Vector3(DirectX, DirectY, 0);
    }
}
