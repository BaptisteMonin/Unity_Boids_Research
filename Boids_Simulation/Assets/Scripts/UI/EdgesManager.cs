using UnityEngine;

public class EdgesManager : MonoBehaviour
{
    public BoidSettings Settings;
    public LineRenderer Edge;

    float Radius;

    private void Start()
    {
        Radius = Settings.EdgeRadius;
    }

    void Update()
    {
        Edge.SetPosition(0, new Vector3(-Radius, -Radius, 0));
        Edge.SetPosition(1, new Vector3(Radius, -Radius, 0));
        Edge.SetPosition(2, new Vector3(Radius, Radius, 0));
        Edge.SetPosition(3, new Vector3(-Radius, Radius, 0));
    }
}
