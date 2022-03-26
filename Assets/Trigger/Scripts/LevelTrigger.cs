using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public delegate void TriggerAction();
    public static event TriggerAction OnEnter;

    public Material MaterialTriggered;

    private bool _triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Triggerable"))
        {
            if (!_triggered)
            {
                if (OnEnter != null)
                    OnEnter();
                _triggered = true;
                GetComponent<MeshRenderer>().material = MaterialTriggered;
            }
            
        }
    }
}
