using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonoBehaviour : MonoBehaviour
{

    protected virtual void Awake()
    {
        UpdateManager.AddBehaviour(this);
    }



    /// <summary>
    /// Normal Update
    /// </summary>
    public virtual void UpdateNormal() { }

    public virtual void UpdateFixed() { }

    public virtual void UpdateLate() { }



    /// <summary>
    /// Only executed in debug build (for testing purpose), is executed right after <see cref="UpdateNormal"/>
    /// </summary>
    public virtual void UpdateDebug() { }

    protected virtual void OnDestroy()
    {
        UpdateManager.RemoveBehaviour(this);
    }
}
