using UnityEngine;

public class EdgesManager : MonoBehaviour
{
    public enum EdgeChoice
    {
        SOFT_EDGE,
        EDGE
    }

    public BoidSettings Settings;
    public LineRenderer Edge;

    public EdgeChoice Type = EdgeChoice.EDGE;

    float HorRadius;
    float VerRadius;

    void Update()
    {
        if(Type == EdgeChoice.SOFT_EDGE)
        {
            HorRadius = Settings.PreHorRadius;
            VerRadius = Settings.PreVerRadius;
            Edge.SetPosition(0, new Vector3(-HorRadius, -VerRadius + 5, 0));
            Edge.SetPosition(1, new Vector3(HorRadius, -VerRadius + 5, 0));
            Edge.SetPosition(2, new Vector3(HorRadius, VerRadius + 5, 0));
            Edge.SetPosition(3, new Vector3(-HorRadius, VerRadius + 5, 0));
        }

        if (Type == EdgeChoice.EDGE)
        {
            HorRadius = Settings.EdgeHorRadius;
            VerRadius = Settings.EdgeVerRadius;
            Edge.SetPosition(0, new Vector3(-HorRadius, -VerRadius + 5, 0));
            Edge.SetPosition(1, new Vector3(HorRadius, -VerRadius + 5, 0));
            Edge.SetPosition(2, new Vector3(HorRadius, VerRadius + 5, 0));
            Edge.SetPosition(3, new Vector3(-HorRadius, VerRadius + 5, 0));
        }
    }
}
