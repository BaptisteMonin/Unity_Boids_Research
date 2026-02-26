using UnityEngine;

[CreateAssetMenu(fileName = "BoidSettings", menuName = "Scriptable Objects/BoidSettings")]
public class BoidSettings : ScriptableObject
{
    [Header("Speed")]
    public float MaxSpeed = 6.0f;
    public float MinSpeed = 3.0f;
    public float MaxSteerSpeed = 1.0f;

    [Header("Weight")]
    public float CohesionWeight = 1.0f;
    public float AlignmentWeight = 1.0f;
    public float SeparationWeight = 1.5f;

    [Header("Edge")]
    public float EdgeHorRadius = 50.0f;
    public float EdgeVerRadius = 50.0f;
    public float PreHorRadius = 40.0f;
    public float PreVerRadius = 40.0f;
    public float EdgeWeight = 10.0f;
    public float PreEdgeWeight = 2.0f;

    [Header("Distance")]
    public float VisualRange = 5.0f;
    public float AvoidanceRange = 1.0f;
}
