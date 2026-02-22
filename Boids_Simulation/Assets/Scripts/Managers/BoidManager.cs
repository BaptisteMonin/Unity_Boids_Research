using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BoidManager : MonoBehaviour
{
    [Header("Settup")]
    public BoidSettings AgentsSettings;
    public GameObject AgentPrefab;
    public int AgentNumber = 50;
    public float SpawnRadius = 20.0f;

    private List<BoidAgent> Agents;

    void Start()
    {
        Agents = new List<BoidAgent>();

        for(int i = 0; i < AgentNumber; i++)
        {
            GameObject agent = Instantiate(AgentPrefab);
            BoidAgent agentComponent = agent.GetComponent<BoidAgent>();
            Agents.Add(agentComponent);

            Vector2 cerclePoint = (Random.insideUnitCircle * SpawnRadius);
            Vector3 agentPosition = new Vector3(cerclePoint.x, cerclePoint.y, 0);
            Vector3 agentRotation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

            agent.transform.position = agentPosition;
            agent.transform.rotation = Quaternion.LookRotation(agentRotation);
        }
    }
}
