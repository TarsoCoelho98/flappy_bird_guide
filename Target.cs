using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private Transform Reference;

    [SerializeField]
    private const float MiddleDistanceBetweenLevelParts = 1.4f;

    internal void Align()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x, ReferenceTipPoint() + MiddleDistanceBetweenLevelParts);
    }

    private float ReferenceTipPoint()
    {
        return Reference.transform.position.y + Reference.transform.localScale.y;
    }
}
