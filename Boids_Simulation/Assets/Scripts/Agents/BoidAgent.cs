using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoidAgent : MonoBehaviour
{
    public Vector3 Velocity = Vector3.zero;

    private BoidSettings Settings;
    private List<BoidAgent> Agents;

    void Update()
    {
        List<BoidAgent> Neighbours = GetNeighbours(this, Agents);

        Vector3 Cohesion = BoidLogic.CohesionAlgorithm(this, Neighbours, Settings.VisualRange, 1f);
        Vector3 Alignment = BoidLogic.AlignmentAlgorithm(this, Neighbours, Settings.VisualRange, 1f);
        Vector3 Separation = BoidLogic.SeparationAlgorithm(this, Neighbours, Settings.AvoidanceRange, 1f);

        Vector3 NewVelocity = (Cohesion * Settings.CohesionWeight + Alignment * Settings.AlignmentWeight + Separation * Settings.SeparationWeight);

        Velocity += NewVelocity * Time.deltaTime;

        float margin = Settings.EdgeRadius;
        float turn = Settings.EdgeWeight;

        if (transform.position.x < -margin) Velocity.x += turn * Time.deltaTime;
        if (transform.position.x > margin) Velocity.x -= turn * Time.deltaTime;
        if (transform.position.y < -margin) Velocity.y += turn * Time.deltaTime;
        if (transform.position.y > margin) Velocity.y -= turn * Time.deltaTime;

        float speed = Velocity.magnitude;
        if (speed > Settings.MaxSpeed)
            Velocity = Velocity.normalized * Settings.MaxSpeed;
        else if (speed < Settings.MinSpeed)
            Velocity = Velocity.normalized * Settings.MinSpeed;

        Velocity.z = 0;

        transform.position += Velocity * Time.deltaTime;
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
