using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public abstract class SteeringBehaviours : ScriptableObject
{
    [Slider(0f, 1f)] public float weighting = 1f;
    public abstract Vector3 GetForce(AI owner);
    public virtual void OnDrawGizmosSelected(AI owner) { }
}
