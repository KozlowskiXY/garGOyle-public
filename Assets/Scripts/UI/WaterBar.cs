using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBar : MonoBehaviour
{
    public Material ma;

    private const float c_maxWaterLevel = 48;
    private const float c_colorFlashingDuration = 20f;
    private float m_colorTime = 0;
    private bool isBlue = true;
    private string m_currentSceeneName = "Level1";

    private const int c_fillSpeed = 1;
    private const int c_reduceAmount = 20;
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 11);
        Physics.IgnoreLayerCollision(6, 12);
        
    }

    public float getWaterLevel()
    {   
        //Debug.Log(this.transform.localScale.y);
        return this.transform.localScale.y;
    }

    public float getReduceAmount()
    {
        return c_reduceAmount;
    }

    public float getMaxWaterLevel()
    {
        return c_maxWaterLevel;
    }

    public void setMaxWaterLevel()
    {
        float temp = getWaterLevel();
        this.transform.localScale += new Vector3(0, c_maxWaterLevel - temp, 0);
        this.transform.position += new Vector3(0, (c_maxWaterLevel - temp) * 0.25f, 0);
        //Debug.Log("Full");
    }

    public void setMinWaterLevel()
    {
        float temp = getWaterLevel();
        this.transform.localScale -= new Vector3(0, temp, 0);
        this.transform.position -= new Vector3(0, temp * 0.25f, 0);
    }

    public void reduceWaterLevel()
    {
        if (getWaterLevel() > c_reduceAmount)
        {
            this.transform.localScale -= new Vector3(0, c_reduceAmount , 0); 
            this.transform.position -= new Vector3(0, c_reduceAmount * 0.25f, 0);
        }
        
    }

    public void reduceWaterLevelBy(float x)
    {
        if (getWaterLevel() > x)
        {
            this.transform.localScale -= new Vector3(0, x, 0);
            this.transform.position -= new Vector3(0, x * 0.25f, 0);
        }

    }

    public void growWaterLevelBy(float x)
    {
        if (getWaterLevel() + x < c_maxWaterLevel)
        {
            this.transform.localScale += new Vector3(0, x, 0);
            this.transform.position += new Vector3(0, x * 0.25f, 0);
        }
        else
        {
            while(getWaterLevel() < c_maxWaterLevel)
            {
                this.transform.localScale += new Vector3(0, 1, 0);
                this.transform.position += new Vector3(0, 1 * 0.25f, 0);

                if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level4")
                {
                    FindObjectOfType<Rose>().defeatBoss();
                }
            }
        }

    }

    public void grow()
    {
        if (getWaterLevel() < c_maxWaterLevel)
        {
            this.transform.localScale += new Vector3(0, c_fillSpeed * 0.1f, 0);
            this.transform.position += new Vector3(0, c_fillSpeed * 0.025f, 0);
        }

    }

    private void Update()
    {
        m_colorTime = m_colorTime + Time.deltaTime;

        
        if (getWaterLevel() >= c_reduceAmount && m_colorTime > c_colorFlashingDuration / (getWaterLevel() *2 )&& isBlue)
        {
            m_currentSceeneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            if (m_currentSceeneName != "Level4" || m_currentSceeneName != "Level5" || getWaterLevel() > c_maxWaterLevel - 1)
            {
                m_colorTime = 0;
                isBlue = false;
                ma.color = Color.green;
            }
            
        }
        else if(getWaterLevel() >= c_reduceAmount && m_colorTime > c_colorFlashingDuration / (getWaterLevel() *2 )&& !isBlue)
        {
            m_colorTime = 0;
            isBlue = true;
            ma.color = Color.red;
        }
        else if (getWaterLevel() < c_reduceAmount)
        {
            ma.color = Color.red;
        }
    }
}
