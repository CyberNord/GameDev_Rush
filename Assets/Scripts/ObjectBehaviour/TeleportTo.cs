using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    [SerializeField] private GameObject teleportDestination;
    [SerializeField] private GameObject Hero;
    [SerializeField] private float RotateX;
    [SerializeField] private float RotateY;
    [SerializeField] private float RotateZ;

    private Vector3 _newPos;

    // Start is called before the first frame update
    void Start()
    {
        _newPos = teleportDestination.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = _newPos;
        collision.transform.Rotate(RotateX, RotateY, RotateZ);
    }
}
