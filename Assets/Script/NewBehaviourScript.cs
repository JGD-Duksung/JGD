using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.SetBool("buttonpush", false);
    }

    // Update is called once per frame
    public void buttonpush()
    {
        animator.SetBool("buttonpush", true);
        Invoke("GotoMain", 3.0f);
    }
    void GotoMain()
    {
        SceneManager.LoadScene("Mainpage");
    }
}