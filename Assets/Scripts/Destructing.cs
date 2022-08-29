using UnityEngine;

public class Destructing : MonoBehaviour
{
    public float destructionTime = 1f;

    private void Start()
    {
        Destroy(gameObject, destructionTime);
    }
}
