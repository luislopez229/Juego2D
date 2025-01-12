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

    public void ReloadLevel()
    {
        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator DelayLoadLevel(int index)
    {
        animator.SetTrigger("trigger");
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(index);
        }
    }


