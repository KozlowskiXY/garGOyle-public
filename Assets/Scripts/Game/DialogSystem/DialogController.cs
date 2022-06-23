using UnityEngine.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//by Frieder
public class DialogController : MonoBehaviour
{
    public AudioSource player;
    public TextMeshProUGUI dialogtext;
    public DialogLine[] dialog;
    public string nextscene;
    private int currentline = 0;


    private void PlayNextLine()
    {
        if(currentline < dialog.Length)
        {
            player.Stop();
            player.clip = dialog[currentline].clip;
            player.Play();
            dialogtext.text = dialog[currentline].text;
            currentline++;
        }        
    }
    public void SkipLine()
    {
        if (currentline == dialog.Length)
        {
            player.Stop();
            StartCoroutine(PlayTransition());
        }
        else
        {
            PlayNextLine();
        }
    }
    void Update()
    {
        if (player.isPlaying)
        {
            return;
        }
        else
        {
            PlayNextLine();
        }
    }
    //=========================================================================
    //Code for scene transition
    public GameObject transition_bg;
    public GameObject transition_sammy;
    private AsyncOperation op;
    private Animator sammy_anim;
    private IEnumerator LoadAsync()
    {
        op = SceneManager.LoadSceneAsync(nextscene);
        op.allowSceneActivation = false;
        Debug.Log("Loading...");
        yield return null;
    }
    private IEnumerator PlayTransition()
    {
        StartCoroutine(LoadAsync());
        transition_bg.SetActive(true);
        sammy_anim.SetTrigger("play");
        yield return new WaitForSeconds(5);
        op.allowSceneActivation = true;
    }

    private void Start()
    {
        sammy_anim = transition_sammy.GetComponent<Animator>();
    }
}
