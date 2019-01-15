using System.Collections;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class WebCamera : MonoBehaviour {

    static WebCamTexture backCam;
    int screenshotNumber = 1;
    Color32[] data;
    bool data2Set = false;
    int counter = 0;
    int orangeCounter = 0;
    int previousOrange = 0;
    int previousCounter = 0;
    int purpleCounter = 0;
    int previousPurple = 0;
    Time startTime;
    int averageWhite = 0;
    int averageOrange =0;
    int averagePurple = 0;
    int amountForAverage = 0;
    float buildingProgress = 0;
    float orangeBuildingProgress = 0;
    float purpleBuildingProgress = 0;
    int averageBlock = 0;
    Dictionary<int, int> trackedNumbers = new Dictionary<int, int>();
    List<int> numbers = new List<int>();
    List<int> orangeNums = new List<int>();
    List<int> allNumbers = new List<int>();
    List<int> purpleNums = new List<int>();
    public Text loading;
    public Text noMoney;
    public Slider constructionBar;
    float setup = 0;
    
    public GameObject t;
    public GameObject t2;
    public GameObject t3;
    public GameObject background;
    // Use this for initialization
    void Start () {
        if (backCam == null)
            backCam = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = backCam;
        
        if (!backCam.isPlaying)
            backCam.Play();
        noMoney.text = "";
    }

    // Update is called once per frame
    void Update() {
        averageBlock = 0;
        numbers.Clear();
        orangeNums.Clear();
        //Data is 640 * 480
        data = backCam.GetPixels32();
        int counter = 0;
        int orangeCounter = 0;
        int purpleCounter = 0;
        if (setup > 3)
        {
            noMoney.text = "";
        }
        setup += Time.deltaTime;

        for (int i = 0; i < data.Length; i++)
        {
            if(i == 2000)
            {
               //Debug.Log(data[i].r);
            }
            if (data[i].r > 170 && (data[i].b < 200 || data[i].b > 100) && data[i].g < 100 )
            {
                if (!trackedNumbers.ContainsKey(i))
                {
                    if (averageBlock == 0) { 
                        averageBlock = i;
                        orangeNums.Add(i);
                        orangeCounter++;
                    } else
                    {
                        averageBlock += i;
                        orangeCounter++;
                        orangeNums.Add(i);
                    }
                } 
            } else if (data[i].r > 230 && data[i].b > 230 && data[i].g > 230)
            {
                if (!trackedNumbers.ContainsKey(i))
                {
                    if (averageBlock == 0)
                    {
                        averageBlock = i;
                        numbers.Add(i);
                        counter++;
                    }
                    else
                    {
                        averageBlock += i;
                        counter++;
                        numbers.Add(i);
                    }
                }
            }
            
            else if ((data[i].r > 180 && data[i].r < 210) && (data[i].b > 80 || data[i].b < 130) && (data[i].g > 160 && data[i].g < 210) )
            {
                if (!trackedNumbers.ContainsKey(i))
                {
                    if (averageBlock == 0)
                    {
                        averageBlock = i;
                        purpleNums.Add(i);
                        purpleCounter++;
                    }
                    else
                    {
                        averageBlock += i;
                        purpleCounter++;
                        purpleNums.Add(i);
                    }
                }
            } 
        }

        float bbb = Mathf.Max(orangeBuildingProgress, buildingProgress);
        constructionBar.value = Mathf.Max(bbb, purpleBuildingProgress) / 4;
        if(Time.fixedTime > 5)
        {
            Destroy(loading);
            if (counter > 500)
            {
                buildingProgress += Time.deltaTime;
            } else
            {
                buildingProgress = 0;
            }
            if (orangeCounter > 25)
            {
                orangeBuildingProgress += Time.deltaTime;
            } else
            {
                orangeBuildingProgress = 0; 
            }
            if (purpleCounter > 3500)
            {
                purpleBuildingProgress += Time.deltaTime;
            }
            else
            {
                purpleBuildingProgress = 0;
            }
        } else
        {
            for (int j = 0; j < numbers.Count; j++)
            {
                if (!trackedNumbers.ContainsKey(numbers[j]))
                {
                    trackedNumbers.Add(numbers[j], 1);
                }
            }
            for (int j = 0; j < orangeNums.Count; j++)
            {
                if (!trackedNumbers.ContainsKey(orangeNums[j]))
                {
                    trackedNumbers.Add(orangeNums[j], 1);
                }
            }
            for (int j = 0; j < purpleNums.Count; j++)
            {
                if(!trackedNumbers.ContainsKey(purpleNums[j]))
                {
                    trackedNumbers.Add(purpleNums[j], 1);
                }
            }
        }
        if (buildingProgress >4)
        {
            //Debug.Log(numbers.Count);
            if(background.GetComponent<buildManager>().GetMoney() >= 80)
            {
                buildingProgress = 0;
                averageWhite = counter;
                int averageX = 0;
                int averageY = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if(trackedNumbers.ContainsKey(j) == false)
                    {
                        trackedNumbers.Add(numbers[j], 1);
                    }
                    averageX += numbers[j] % 640;
                    averageY += numbers[j] / 640;
                }
                averageX /= numbers.Count - 1;
                averageY /= numbers.Count - 1;
                float xPercent = (float)averageX / 520f;
                float yPercent = (float)averageY / 420f;
                float trueX = -0.28f - 0.87f + 4.6f * xPercent;
                float trueY = -2.2f - 0.8f + 3.7f * yPercent;
                Instantiate(t, new Vector3(trueX, trueY, t.transform.position.z), Quaternion.identity);
                background.GetComponent<buildManager>().SetMoney(-80);
                //Debug.Log("Built");
                //Debug.Log(averageX + " " + xPercent + " " + trueX);
            } else
            {
                noMoney.text = "NOT ENOUGH \nMONEY";
                setup = 0;
            }
            buildingProgress = 0;
        }
        if(orangeBuildingProgress > 4)
        {
            if (background.GetComponent<buildManager>().GetMoney() >= 130)
            {
                orangeBuildingProgress = 0;
                averageOrange = orangeCounter;
                int averageX = 0;
                int averageY = 0;
                for (int j = 0; j < orangeNums.Count; j++)
                {
                    if(trackedNumbers.ContainsKey(j) == false)
                    {
                        trackedNumbers.Add(orangeNums[j], 1);
                    }
                    averageX += orangeNums[j] % 640;
                    averageY += orangeNums[j] / 640;
                }
                averageX /= orangeNums.Count - 1;
                averageY /= orangeNums.Count - 1;
                float xPercent = (float)averageX / 520f;
                float yPercent = (float)averageY / 420f;
                float trueX = -0.28f - 0.87f + 4.6f * xPercent;
                float trueY = -2.2f - 0.8f + 3.7f * yPercent;
                Instantiate(t2, new Vector3(trueX, trueY, t2.transform.position.z), Quaternion.identity);
                background.GetComponent<buildManager>().SetMoney(-130);
                //Debug.Log("Built");
                //Debug.Log(averageX + " " + xPercent + " " + trueX);
            }
            else
            {
                noMoney.text = "NOT ENOUGH \nMONEY";
                setup = 0;
            }
            buildingProgress = 0;
        }
        if (purpleBuildingProgress > 4)
        {
            if (background.GetComponent<buildManager>().GetMoney() >= 180)
            {
                purpleBuildingProgress = 0;
                averagePurple = purpleCounter;
                int averageX = 0;
                int averageY = 0;
                for (int j = 0; j < purpleNums.Count; j++)
                {
                    if (!trackedNumbers.ContainsKey(purpleNums[j]))
                    {
                        trackedNumbers.Add(purpleNums[j], 1);
                    }
                    averageX += purpleNums[j] % 640;
                    averageY += purpleNums[j] / 640;
                }
                averageX /= purpleNums.Count - 1;
                averageY /= purpleNums.Count - 1;
                float xPercent = (float)averageX / 520f;
                float yPercent = (float)averageY / 420f;
                float trueX = -0.28f - 0.87f + 4.6f * xPercent;
                float trueY = -2.2f - 0.8f + 3.7f * yPercent;
                Instantiate(t3, new Vector3(trueX, trueY, t3.transform.position.z), Quaternion.identity);
                background.GetComponent<buildManager>().SetMoney(-180);
                //Debug.Log("Built");
                //Debug.Log(averageX + " " + xPercent + " " + trueX);
            }
            else
            {
                noMoney.text = "NOT ENOUGH \nMONEY";
                setup = 0;
            }
            buildingProgress = 0;
        }
        //Debug.Log(trackedNumbers.Count);
        Debug.Log(counter);
    }

}
