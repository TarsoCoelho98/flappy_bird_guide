using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D RgbPlayer;

    // Jump Section
     
    [SerializeField]
    private float JumpForce;

    
    // Update is called once per frame
    void Update()
    {
        JumpCheck();
    }

    private void Death()
    {
        this.gameObject.SetActive(false);
    }

    private void Jump()
    {
        RgbPlayer.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);                                                                                            
    }

    private void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckForAction(); 
            Jump();
        }
    }

    private void SetStartPosition()
    {
        this.transform.position = Vector2.zero;
    }

    public void CheckForAction()
    {
        if (!Manager.MgrSingle.IsActionActive)
            Manager.MgrSingle.StartGameAction();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Manager.MgrSingle.IncreasePlayerPontuation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopLimit"))
            return;

        Death();
    }
}
