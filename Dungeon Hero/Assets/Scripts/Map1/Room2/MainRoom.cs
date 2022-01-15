using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoom : MonoBehaviour
{
    [SerializeField]
    NPC _npc;
    [SerializeField]
    RoomManager roomManager;

    private void Update()
    {
        if (roomManager.isFinished && _npc.isAccepted)
            _npc.isFinished = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
