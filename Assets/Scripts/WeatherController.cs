using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : BaseMonoBehaviour
{
    static public WeatherController instance;
    float _currentSunLight = 0f;

    
    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float GetCurrentSunLight()
    {
        return _currentSunLight;
    }

    public override void UpdateDebug()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            _currentSunLight = 0f;
            Debug.Log($"Sun Light: {_currentSunLight}");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentSunLight = .5f;
            Debug.Log($"Sun Light: {_currentSunLight}");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currentSunLight = 1f;
            Debug.Log($"Sun Light: {_currentSunLight}");
        }
    }
}
