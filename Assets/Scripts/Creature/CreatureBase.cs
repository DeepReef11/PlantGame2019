using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CreatureBase : BaseMonoBehaviour
{
    #region Stats
    public bool ShowStats = false;
    [ConditionalField("ShowStats")]
    public float Speed = 5f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Creatures");
        GetComponent<SpriteRenderer>().sortingLayerName = "Creatures";
    }

    public override void UpdateFixed()
    {
        Movement(_direction, Speed);
    }

    protected Vector2 _direction = new Vector2();
    virtual protected void Movement(Vector2 direction, float speed)
    {
        transform.Translate(direction * speed);
    }

}
