using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{


    public Audio[] audios;
    public float[] audioVolumes;

    private bool isA = true;
    private char m_endingLetter = 'a';
    private int m_pieceNumber = 0;
    private int m_maxHealth = 3;

    public static AudioManager instance;
    private const int c_pieceCount = 7;
    private const string c_level1 = "Level1";
    private const string c_level2 = "Level2";
    private const string c_level3 = "Level3";
    private const string c_level4 = "Level4";
    private const string c_level5 = "Level5";
    private string m_currentSceeneName = "Level1";

    private bool isDistorted = false;


    //deltaTime doesnt work here
    System.Diagnostics.Stopwatch musicTime = new System.Diagnostics.Stopwatch();


    //called when game starts
    void Awake()
    {

        //enables music to keep playing when changing sceenes
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        int i = 0;
        audioVolumes = new float[audios.Length];
        DontDestroyOnLoad(this);
        // Add Audio Source to each Audio file
        foreach (Audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.volume;
            a.source.loop = a.loop;
            audioVolumes[i] = a.volume;
            i++;
            if (a.source.clip.ToString().Contains("Music")) a.source.volume = 0;
        }


        musicTime.Start();
        fadingTime.Start();
        playNextMusic();
        Play("music-level1");
    }

    //plays audio file of <name>
    public void Play(string name)
    {
        Audio a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Couldn't find: " + name);
            return;
        }

        a.source.Play();
    }

    public void Stop(string name)
    {
        Audio a = Array.Find(audios, audio => audio.name == name);
        if (a == null)
        {
            Debug.Log("Couldn't find: " + name);
            return;
        }

        a.source.Stop();
    }

    //find array index of given audio name
    private int getIndexNumber(string name)
    {
        for (int i = 0; i <= audios.Length - 1; i++)
        {
            if (name == audios[i].name) return i;

        }

        Debug.Log("Requested string wasn't found!");
        return 6;
    }

    int a_fadeIn = 0;
    int b_fadeIn = 0;
    int a_fadeOut = 0;
    int b_fadeOut = 0;

    System.Diagnostics.Stopwatch fadingTime = new System.Diagnostics.Stopwatch();
    private float c_FadingTime = 4000f;


    private void startFading()
    {
        a_fadeIn = getIndexNumber(currentMusicStrings[0]);
        b_fadeIn = getIndexNumber(currentMusicStrings[1]);
        a_fadeOut = getIndexNumber(pastMusicStrings[0]);
        b_fadeOut = getIndexNumber(pastMusicStrings[1]);

        audios[a_fadeIn].source.volume = audioVolumes[a_fadeIn] * (1 / c_FadingTime) * fadingTime.ElapsedMilliseconds;
        audios[b_fadeIn].source.volume = audioVolumes[b_fadeIn] * (1 / c_FadingTime) * fadingTime.ElapsedMilliseconds;
        audios[a_fadeOut].source.volume = audioVolumes[a_fadeOut] - audioVolumes[a_fadeOut] * (1 / c_FadingTime) * fadingTime.ElapsedMilliseconds;
        audios[b_fadeOut].source.volume = audioVolumes[b_fadeOut] - audioVolumes[b_fadeOut] * (1 / c_FadingTime) * fadingTime.ElapsedMilliseconds;
    }

    string[] currentMusicStrings = { "garGOyleMusic0a", "garGOyleMusic0b" };
    string[] pastMusicStrings = { "music-level1", "music-level1" };
    //generates strings of the music piece played
    private void generateCurrentString()
    {
        //if healthbar doesnt exist, play menue piece
        if (FindObjectOfType<HealthBarController>() == null)
        {
            if (currentMusicStrings[0] == "garGOyleMusic0a")
                return;
            pastMusicStrings[0] = currentMusicStrings[0];
            pastMusicStrings[1] = currentMusicStrings[1];
            currentMusicStrings[0] = "garGOyleMusic0a";
            currentMusicStrings[1] = "garGOyleMusic0b";
            fadingTime.Restart();
            return;
        }

        //decide if pieceNumer 0,1,2 or 3 is played
        m_currentSceeneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if      (m_currentSceeneName == c_level1 ||
                 m_currentSceeneName == c_level2 ||
                 m_currentSceeneName == c_level3 ||
                 m_currentSceeneName == c_level4 ||
                 m_currentSceeneName == c_level5
                 )
        {
          m_pieceNumber =  1 + m_maxHealth - FindObjectOfType<HealthBarController>().getHealth();
            if (isDistorted) m_pieceNumber += 3;  
          
  

          //avoids input of 0 Health
           if(m_pieceNumber > m_maxHealth + 3)
           {
              m_pieceNumber = 0;
           }
        }
        else
        {
            m_pieceNumber = 0;

        }

        if (currentMusicStrings[0] == "garGOyleMusic" + m_pieceNumber + "a")
            return;

        //Debug.Log("Generated String: " + currentMusicStrings[0]);

        pastMusicStrings[0] = currentMusicStrings[0];
        pastMusicStrings[1] = currentMusicStrings[1];
        

        
        currentMusicStrings[0] = "garGOyleMusic" + m_pieceNumber + "a";
        currentMusicStrings[1] = "garGOyleMusic" + m_pieceNumber + "b";

        fadingTime.Restart();
    }



    //plays all next pieces parallel once current music ends
    private void playNextMusic()
    {

        //decide if piece a or b is played
        if (isA)
        {
            m_endingLetter = 'b';
            isA = false;
        }
        else if (!isA)
        {
            m_endingLetter = 'a';
            isA = true;
        }

        for(int m_pieceNumber = 0; m_pieceNumber < c_pieceCount; m_pieceNumber++)
        {


            Play("garGOyleMusic" + m_pieceNumber + m_endingLetter);
        
            

        }
        musicTime.Restart();
    }

    public void applyDistortion()
    {
        isDistorted = true;
    }

    public void removeDistortion()
    {
        isDistorted = false;
    }


    private void Update()
    {
        //Debug.Log("In: " + doneFadingIn.ToString() + " Out: " + doneFadingOut.ToString());
        if (fadingTime.ElapsedMilliseconds < c_FadingTime) startFading();
        if (fadingTime.ElapsedMilliseconds > c_FadingTime) generateCurrentString();

        if (musicTime.ElapsedMilliseconds > 24000) playNextMusic();
    }
}
