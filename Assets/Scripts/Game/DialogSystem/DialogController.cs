using UnityEngine.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//by Frieder
public class DialogController : MonoBehaviour
{
    
    public TextMeshProUGUI dialogtext;
    public SpriteRenderer SpeakerHead;
    public DialogLine[] dialog;
    public string nextscene;
    private int currentline = 0;
    private bool notLoading = true;

    
    public void SkipLine()
    {
        if (currentline >= dialog.Length)
        {
            if(notLoading)
            {
                StartCoroutine(PlayTransition());
                notLoading= false;
            } 
        }
        else
        {
            dialogtext.text = dialog[currentline].text;
            SpeakerHead.sprite = dialog[currentline].speaker;
            currentline++;
           
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
        SkipLine();
    }
}
