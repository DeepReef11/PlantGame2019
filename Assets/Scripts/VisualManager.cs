using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualManager : MonoBehaviour
{
    List<Sprite> _sprites;

    private void Awake()
    {
        _sprites = new List<Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites");
        _sprites.AddRange(sprites);

    }

    public Sprite GetSprite(string name)
    {

        Sprite s = _sprites.Find(x => x.name == name);
        if(s == null)
        {
            s = _sprites.Find(x => x.name == "Undefined");
        }
        return s;
    }
}
