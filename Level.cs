using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // aspect n tá preservando ao dar scale, tem que colocar sprite dentro dum image


    // Initial Level Transform Section

    //[SerializeField]
    //private byte XInitialPosition;

    //[SerializeField]
    //private float TopPartInitialYScale;

    //[SerializeField]
    //private float DownPartInitialYScale;

    //[SerializeField]

    //private float YInitialTargetPosition;

    // Variation Section 

    private const float MaxVariationPositionValue = 1.92f;
    private const float MinYVariationPositionValue = -2.9f;

    [SerializeField ]
    private const float XPositionStartValue = 1.15f;
    private const float XNegativeLimitPositionValue = -5.45f;
 
    [SerializeField]
    private float Velocity;   

    
    [SerializeField]
    private Target Target;
    
    void Update()
    {
        if (Manager.MgrSingle.IsGameOver)
            return;

        Move();
        CheckChangeLevelTransform();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * Velocity * Time.deltaTime);
    }

    private void CheckChangeLevelTransform()
    {
        if (this.gameObject.transform.position.x <= XNegativeLimitPositionValue)
            ChangeLevelTransfom();
    }

    private void ChangeLevelTransfom()
    {
        SetXDefaultTransformPosition();
        SetYTransformPosition();
        Target.Align();
    }

    private void SetXDefaultTransformPosition()
    {
        this.gameObject.transform.position = new Vector2(XPositionStartValue, this.gameObject.transform.position.y);
    }
    
    private void SetYTransformPosition()
    {
        var newYTransformPositionValue = GetRandomYTransformPositionLevel();
        this.transform.position = new Vector2(this.transform.position.x, newYTransformPositionValue);
    }

    private float GetRandomYTransformPositionLevel()
    {
        return Random.Range(MinYVariationPositionValue, MaxVariationPositionValue);
    }
        
    private void HideLevel() 
    {
        this.gameObject.SetActive(false); 
    }
}
