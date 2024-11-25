using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class transition : MonoBehaviour
{
    public Animator animator;
    public float transitionDelayTime = 1.0f;
void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    public void LoadLevel()
    {
        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator DelayLoadLevel(int index)
    {
        animator.SetTrigger("trigger");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(index);
    }
}
