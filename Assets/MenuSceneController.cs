using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour {

    public void ChangeAcetatoScene(){
        SceneManager.LoadScene("Acetato");
    }

    public void ChangeAnimationScene(){
        SceneManager.LoadScene("Animation");
    }
}
