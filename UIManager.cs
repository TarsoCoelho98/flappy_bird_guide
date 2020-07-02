using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text CurrentScore;

    internal static UIManager UISingle = null;   

    private void InstanceVerify()
    {
        if (UISingle == null)
            UISingle = this;
        else
            Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        InstanceVerify();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartScore()
    {
        CurrentScore.text = Manager.MgrSingle.CurrentScore.ToString(); 
    }

    

}
