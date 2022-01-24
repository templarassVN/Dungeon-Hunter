using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_Control : MonoBehaviour
{
    [SerializeField]
    NPC _mission;
    RoomManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GetComponent<RoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_manager.isFinished)
        {
            if (_mission.isAccepted)
                _mission.isFinished = true;
        }
    }
}
