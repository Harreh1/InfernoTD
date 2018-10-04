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
    int previousCounter = 0;
    Time startTime;
    int averageWhite = 0;
    int amountForAverage = 0;
    float buildingProgress = 0;
    int averageBlock = 0;
    Dictionary<int, int> trackedNumbers = new Dictionary<int, int>();
    List<int> numbers = new List<int>();
    List<int> allNumbers = new List<int>();
    public Text loading;
    public Text noMoney;
    public Slider constructionBar;
    float setup = 0;
    
    public GameObject t;
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
        //Data is 640 * 480
        data = backCam.GetPixels32();
        int counter = 0;
        if (setup > 3)
        {
            noMoney.text = "";
        }
        setup += Time.deltaTime;
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].r > 230 && data[i].b > 230 && data[i].g > 230)
            {
                if (!trackedNumbers.ContainsKey(i))
                {
                    if (averageBlock == 0) { 
                        averageBlock = i;
                        numbers.Add(i);
                        counter++;
                    } else
                    {
                        averageBlock += i;
                        counter++;
                        numbers.Add(i);
                    }
                } 
            }
        }
        constructionBar.value = buildingProgress / 3;
        if(Time.fixedTime > 5)
        {
            Destroy(loading);
            if (counter > 150)
            {
                buildingProgress += Time.deltaTime;
            } else
            {
                buildingProgress = 0;
            }
        } else
        {
            for (int j = 0; j < numbers.Count; j++)
            {
                trackedNumbers.Add(numbers[j], 1);
            }
        }
        if (buildingProgress > 4)
        {
            Debug.Log(numbers.Count);
            if(background.GetComponent<buildManager>().GetMoney() >= 80)
            {
                buildingProgress = 0;
                averageWhite = counter;
                int averageX = 0;
                int averageY = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    trackedNumbers.Add(numbers[j], 1);
                    averageX += numbers[j] % 640;
                    averageY += numbers[j] / 640;
                }
                averageX /= numbers.Count - 1;
                averageY /= numbers.Count - 1;
                float xPercent = (float)averageX / 520f;
                float yPercent = (float)averageY / 420f;
                float trueX = -0.28f - 0.67f + 4.6f * xPercent;
                float trueY = -2.2f - 0.3f + 3.7f * yPercent;
                Instantiate(t, new Vector3(trueX, trueY, t.transform.position.z), Quaternion.identity);
                background.GetComponent<buildManager>().SetMoney(-80);
                Debug.Log("Built");
                Debug.Log(averageX + " " + xPercent + " " + trueX);
            } else
            {
                noMoney.text = "NOT ENOUGH \nMONEY";
                setup = 0;
            }
            buildingProgress = 0;
        }
        Debug.Log(counter);
    }

}
