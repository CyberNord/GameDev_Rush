using UnityEngine;

public class CamCtr : MonoBehaviour
{

    public Transform target;        // Character
    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - target.position; 
    }

    void LateUpdate()
    {
        transform.position = target.position + offset; 
    }

    // Todo cam Movement
}
