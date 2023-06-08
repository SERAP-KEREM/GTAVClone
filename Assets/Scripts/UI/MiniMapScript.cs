using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Transform player;
    public Transform car;
    public GameObject playerCharacter;
    bool isActivePlayer;

    private void LateUpdate()
    {
        isActivePlayer = playerCharacter.active;
        if(isActivePlayer)
        {
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(90, player.eulerAngles.y, 0f);
        }
        else
        {
            Vector3 newPosition = car.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(90, car.eulerAngles.y, 0f);
        }
    }
}
