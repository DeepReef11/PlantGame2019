using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : BaseMonoBehaviour
{
    Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    public override void UpdateLate()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
    }
}
