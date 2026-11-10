using UnityEngine;

public abstract class GameObjectBaseType : MonoBehaviour
{
    protected PersonellManager personellManager;
    public PersonellManager PersonellManager { get { return personellManager; } }
}
