using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandController : BaseMonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 0);
        GameObject go = gameObject.CreateChildren("Land");
        go.AddComponent<Land>();
    }

    void StartInitialize()
    {

    }


    // Update is called once per frame
    override public void UpdateNormal()
    {
        
    }
}
