using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    [SerializeField] private GameObject teleportDestination;
    
    private Vector3 _newPos;

    // Start is called before the first frame update
    void Start()
    {
        _newPos = teleportDestination.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = _newPos;
    }
}
