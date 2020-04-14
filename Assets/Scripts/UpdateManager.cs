using RSG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    private int behaviourCount;
    private List<BaseMonoBehaviour> _behaviours;
    private static UpdateManager instance;
    bool _gameLoaded = false;
    bool _onPause = false;

    private void Awake()
    {
        if(instance ==  null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("UpdateManager already exists!");
            Destroy(this);
        }
        _behaviours = new List<BaseMonoBehaviour>();
    }


    // Start is called before the first frame update
    void Start()
    {
        _gameLoaded = true;  
        
    }

    PromiseTimer promiseTimer = new PromiseTimer();
    /*
    IPromise WaitFor(float timeToWait)
    {
        Debug.Log("in");
        return promiseTimer.WaitFor(timeToWait);
    }*/



    // Update is called once per frame
    void Update()
    {

        if (_gameLoaded && !_onPause)
        {
            foreach (BaseMonoBehaviour bmb in _behaviours)
            {
                bmb.UpdateNormal();
#if UNITY_EDITOR
                bmb.UpdateDebug();
#endif
            }
        }
    }

    private void FixedUpdate()
    {
        if (_gameLoaded && !_onPause)
        {
            foreach (BaseMonoBehaviour bmb in _behaviours)
            {
                bmb.UpdateFixed();
            }
        }
    }

    private void LateUpdate()
    {
        if (_gameLoaded && !_onPause)
        {
            foreach (BaseMonoBehaviour bmb in _behaviours)
            {
                bmb.UpdateLate();
            }
        }
    }

    public static void AddBehaviour(BaseMonoBehaviour behaviour)
    {
        instance._behaviours.Add(behaviour);
    }

    public static void RemoveBehaviour(BaseMonoBehaviour behaviour)
    {
        instance._behaviours.Remove(behaviour);
    }
}
