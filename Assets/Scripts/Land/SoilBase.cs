using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilBase : BaseMonoBehaviour
{
    SpriteRenderer _sr;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        // Load sprite
        _sr = gameObject.AddComponent<SpriteRenderer>();
        var vc2d = gameObject.AddComponent<BoxCollider2D>();
        vc2d.size = new Vector2(1, 1);
        Sprite s = GameManager.Visual.GetSprite(this.GetType().ToString());
        _sr.sprite = s;
        _sr.sortingLayerName = "Background";
        gameObject.layer = LayerMask.NameToLayer("Background");
    }

    protected virtual void PlantSeed(System.Type pb)
    {
        if (pb == typeof(PlantBase))
        {
            GameObject go = gameObject.CreateChildren();
            PlantBase plant = (PlantBase)go.AddComponent(pb);
            plant.Seed();
        }
        else
        {
            Debug.LogError("A non plant base type was sent.");
        }

    }
    


}
