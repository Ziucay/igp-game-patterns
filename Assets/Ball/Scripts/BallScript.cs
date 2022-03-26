using UnityEngine;

public class BallScript : MonoBehaviour, IMemorable
{
    public ScriptableObject SaveToMemento()
    {
        var obj = ScriptableObject.CreateInstance<BallScriptableObject>();
        obj.Position = transform.position;
        return obj;
    }

    public void RestoreFromMemento(ScriptableObject memento)
    {
        if (memento.GetType() != typeof(BallScriptableObject))
            throw new System.ArgumentException("Incorrect type of Scriptable object");
        
        transform.position = ((BallScriptableObject) memento).Position;
    }
    
    public class BallScriptableObject : ScriptableObject
    {
        public Vector3 Position;

        public BallScriptableObject(Vector3 position)
        {
            Position = position;
        }
    }
}
