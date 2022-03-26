using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int TriggerCounter;
    public TextMeshProUGUI LevelCompleted;
    void Start()
    {
        LevelTrigger.OnEnter += DecreaseCounter;
    }

    void DecreaseCounter()
    {
        TriggerCounter--;
        if (TriggerCounter <= 0)
        {
            Debug.Log("Sufficient amount of triggers! Level passed.");
            LevelCompleted.enabled = true;
        }
    }
}
