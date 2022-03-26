using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static HashSet< (GameObject,ScriptableObject) > _mementoObjects;
    private bool _isSaved = false;

    private void SaveState()
    {
        var objects = FindObjectsOfType<MonoBehaviour>().OfType<IMemorable>();

        _mementoObjects = new HashSet< (GameObject,ScriptableObject) >();
        foreach (var obj in objects)
        {
            _mementoObjects.Add( ((obj as MonoBehaviour).gameObject, obj.SaveToMemento()) );
        }
        _isSaved = true;

        SaveTime.text = "Save time: " + Mathf.Round(TimeCounter);
    }

    private void LoadState()
    {
        if (!_isSaved)
        {
            Debug.Log("Nothing to be saved.");
            return;
        }

        foreach (var memento in _mementoObjects)
        {
            GameObject current = memento.Item1;
            current.GetComponent<IMemorable>().RestoreFromMemento(memento.Item2);
        }
    }
    
    public static float TimeCounter = 0;

    public TextMeshProUGUI CurrentTime;
    public TextMeshProUGUI SaveTime;
    private void Start()
    {
        SaveTime.text = "Not saved";
    }

    private void FixedUpdate()
    {
        TimeCounter += Time.fixedDeltaTime;
        CurrentTime.text = "Current time: " + Mathf.Round(TimeCounter);

        if (Input.GetButton("Save"))
        {
            SaveState();
        }
        
        if (Input.GetButton("Load"))
        {
            LoadState();
        }
    }
}
