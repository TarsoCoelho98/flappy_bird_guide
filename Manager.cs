using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // UI Section 

    public const byte DefaultScore = 0;

    [SerializeField]
    internal int CurrentScore = DefaultScore;


    // Management Section 

    [SerializeField]
    private float Timer;

    internal static Manager MgrSingle = null;

    internal bool IsGameOver = false;
    internal bool IsActionActive = false;

    // Levels Section 

    [SerializeField]
    private GameObject[] Levels = new GameObject[1];


    // Player Section Position 

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private Rigidbody2D RgbPlayer;

    [SerializeField]
    private int Pontuation = 0;


    // Start is called before the first frame update
    void Start()
    {
        InstanceVerify();
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Time.time;
    }

    private void InstanceVerify()
    {
        if (MgrSingle == null)
            MgrSingle = this;
        else
            Destroy(this.gameObject);
    }

    public void IncreasePlayerPontuation()
    {
        Pontuation++;
    }

    private void Play()
    {
        SetPlayerStartConfiguration();
        Player.SetActive(true);
    }


    public void SetPlayerStartConfiguration()
    {
        Player.transform.position = Vector2.zero;
        RgbPlayer.isKinematic = true;
    }

    internal void StartGameAction()
    {
        StartPlayerAction();
        StartLevelsAction();
    }

    private void StartLevelsAction()
    {
        for (int count = 0; count < Levels.Length; count++)
        {
            Levels[count].SetActive(true);
        }
    }

    private void StartPlayerAction()
    {
        RgbPlayer.bodyType = RigidbodyType2D.Dynamic;
        IsActionActive = true;
    }
}
