using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_Control : MonoBehaviour
{
    [SerializeField]
    NPC _mission;
    RoomManager _manager;
    int _player_armor;
    // Start is called before the first frame update
    void Start()
    {
        _player_armor = PlayerController.instance.MaxArmor;
        _manager = GetComponent<RoomManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_mission.isAccepted)
        {
            Mission(0);
        }
        if (_manager.isFinished)
        {
            if (_mission.isAccepted)
            {
                Mission(_player_armor);
                _mission.isFinished = true;
            }
        }
    }

    void Mission(int max)
    {
        PlayerController.instance.MaxArmor = max;
        PlayerController.instance.CurrentArmor = max;
        IngameUIController.instance.ChangeMaxArmor(max);
        IngameUIController.instance.ChangeCurrentArmor(max);
    }
}
