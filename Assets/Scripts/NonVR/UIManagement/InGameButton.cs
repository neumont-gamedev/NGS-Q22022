using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButton : MonoBehaviour
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
        else if (collision.gameObject.tag == "Hand" && this.name == "Back To Game")
        {
            game.StartGameMountain();
        }
        else if (collision.gameObject.tag == "Hand" && this.name == "To Main Menu")
        {
            game.ReturnToTitle();
        }
        else if (collision.gameObject.tag == "Hand" && this.name == "Start")
        {
            game.SelectBiome();
        }
        else if (collision.gameObject.tag == "Hand" && this.name == "About")
        {
            game.AboutPage();
        }
        else if (collision.gameObject.tag == "Hand" && this.name == "AboutBack")
        {
            game.MainMenuOpen();
        }
        else if (collision.gameObject.tag == "Hand" && this.name == "Mountain Back")
        {
            game.MainMenuOpen();
        }
        else if (collision.gameObject.tag == "Hand" && this.name == "Mountain")
        {
            game.StartGameMountain();
        }
        else if (collision.gameObject.tag == "Hand" && this.name == "Quit")
        {
            Debug.Log("Application Exited");
            Application.Quit();
        }

    }

}
