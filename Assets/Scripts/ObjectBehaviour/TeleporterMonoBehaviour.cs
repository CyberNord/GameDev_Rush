using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class TeleporterMonoBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject teleportDestination;
    [SerializeField] private Audio_Teleporter audioTeleporter; 

    private Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        newPos = teleportDestination.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = newPos;
        audioTeleporter.t_port.PlayDelayed(0.1f);
    }
}
