using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoidAgent : MonoBehaviour
{
    public Vector3 Velocity;

    private BoidSettings Settings;
    private List<BoidAgent> Agents;

    void Update()
    {
        List<BoidAgent> Neighbours = GetNeighbours(this, Agents);

        Vector3 Cohesion = BoidLogic.CohesionAlgorithm(this, Neighbours, Settings.VisualRange, 0.01f);
        Vector3 Alignment = BoidLogic.AlignmentAlgorithm(this, Neighbours, Settings.VisualRange, 0.1f);
        Vector3 Separation = BoidLogic.SeparationAlgorithm(this, Neighbours, Settings.AvoidanceRange, 0.5f);

        Vector3 NewVelocity = (Cohesion * Settings.CohesionWeight + Alignment * Settings.AlignmentWeight + Separation * Settings.SeparationWeight);

        Velocity += NewVelocity * Time.deltaTime;
        Velocity = Vector3.ClampMagnitude(Velocity, Settings.MaxSpeed);
        if(Velocity.magnitude < Settings.MinSpeed)
        {
            Velocity *= 1.5f;
        }

        transform.position += Velocity;
    }

    public void Initialize(BoidSettings settings, List<BoidAgent> agents, Vector3 velocity)
    {
        Settings = settings;
        Agents = agents;
        Velocity = velocity;
    }

    List<BoidAgent> GetNeighbours(BoidAgent self, List<BoidAgent> agents)
    {
        List<BoidAgent> Neighbours = new List<BoidAgent>();
        foreach(BoidAgent agent in agents)
        {
            float distance = (agent.transform.position - self.transform.position).sqrMagnitude;
            if(distance < Settings.VisualRange * Settings.VisualRange)
            {
                Neighbours.Add(agent);
            }
        }
        return Neighbours;
    }
}
