using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public BoidSettings Settings;

    [SerializeField] private Slider CohesionSlider;
    [SerializeField] private Slider SeparationSlider;
    [SerializeField] private Slider AlignmentSlider;

    void Start ()
    {
        CohesionSlider.value = Settings.CohesionWeight;
        SeparationSlider.value = Settings.SeparationWeight;
        AlignmentSlider.value = Settings.AlignmentWeight;

        CohesionSlider.onValueChanged.AddListener(ChangeCohesion);
        SeparationSlider.onValueChanged.AddListener(ChangeSeparation);
        AlignmentSlider.onValueChanged.AddListener(ChangeAlignment);
    }

    void ChangeCohesion(float value)
    {
        Settings.CohesionWeight = value;
    }

    void ChangeSeparation(float value)
    {
        Settings.SeparationWeight = value;
    }

    void ChangeAlignment(float value)
    {
        Settings.AlignmentWeight = value;
    }
}
