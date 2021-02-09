using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
      public void mainMenu () {

       SceneManager.LoadScene("Menu");
   }
      public void PlayGame () {

       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void OptionMenu () {

       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
   }

   public void CreditsMenu () {

       SceneManager.LoadScene("CreditsMenu");
   }

   public void QuitGame () {

       Debug.Log ("Quit!!!!!");
       Application.Quit();
   }

}
