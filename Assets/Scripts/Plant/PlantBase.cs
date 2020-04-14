using RSG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlantBase : BaseMonoBehaviour
{

    protected float minTimeNextGrowStep=10f;
    protected float maxTimeNextGrowStep=20f;
    PromiseTimer _GrowTimer = new PromiseTimer();

    #region ReadOnly
    public bool ShowReadOnly = false;

    [ConditionalField("ShowReadOnly")]
    public float _NextStepTime;

    #endregion

    protected override void Awake()
    {
        base.Awake();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            gameObject.AddComponent<SpriteRenderer>().sprite = GameManager.Visual.GetSprite("Plant");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Plants";
        gameObject.layer = LayerMask.NameToLayer("Plants");
    }

    public void Seed()
    {
        _NextStepTime = Random.Range(minTimeNextGrowStep, maxTimeNextGrowStep);
        _GrowTimer.WaitFor(_NextStepTime).Then(() => FirstGrowStep());
    }

    // Update is called once per frame
    override public void UpdateNormal()
    {
        
        _GrowTimer.Update(Time.deltaTime * GetCurrentGrowRate());
    }

    protected virtual void FirstGrowStep()
    {
        transform.localScale = new Vector2(transform.localScale.x + 3, transform.localScale.y +3);
        _NextStepTime = Random.Range(minTimeNextGrowStep, maxTimeNextGrowStep);
        _GrowTimer.WaitFor(_NextStepTime).Then(() => SecondGrowStep());
    }

    protected virtual void SecondGrowStep()
    {
        transform.localScale = new Vector2(transform.localScale.x + 3, transform.localScale.y + 3);
    }

    protected virtual float GetCurrentGrowRate()
    {
        return WeatherController.instance.GetCurrentSunLight();
    }

}
