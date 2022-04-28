using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButton2 : MonoBehaviour
{
    GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(this.name + "ButtonTouched");
        if (collision.gameObject.tag == "Hand" && this.name == "Museum")
        {
            game.ToMuseum();
        }
        else if(collision.gameObject.tag == "Hand" && this.name == "To Main Menu")
        {
            game.ReturnToTitle();
        }
    }

}
