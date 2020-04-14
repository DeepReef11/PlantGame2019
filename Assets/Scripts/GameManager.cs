using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public static WeatherController Weather;
    public static VisualManager Visual;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        Weather = GetComponent<WeatherController>();
        Visual = GetComponent<VisualManager>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


}
