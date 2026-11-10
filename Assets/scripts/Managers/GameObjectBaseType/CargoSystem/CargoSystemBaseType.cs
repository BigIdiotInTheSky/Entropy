using UnityEngine;

public abstract class CargoSystemBaseType : MonoBehaviour
{
    private GameObjectBaseType gameObjectBaseType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObjectBaseType = GetComponent<GameObjectBaseType>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
