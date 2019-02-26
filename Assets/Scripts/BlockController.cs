using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class BlockController : MonoBehaviour
{
    public GameObject parentCanvas;
    public GameObject blockPrefeb;
    public int blockSeriesRow;
    public int blockSeriesCol;
    private GameObject[,] blockSeries = new GameObject[27, 15];

    public string touchStr = "";
    private string lastTouchStr = "";

    // Start is called before the first frame update
    void Start()
    {
        blockSeries = new GameObject[blockSeriesRow, blockSeriesCol];

        for (int i = 0; i < blockSeriesRow; i++)
        {
            for (int j = 0; j < blockSeriesCol; j++)
            {
                blockSeries[i, j] = Instantiate(blockPrefeb, parentCanvas.transform);
                blockSeries[i, j].transform.localPosition = new Vector3((i - (blockSeriesRow - 1) / 2) * 50, (j - (blockSeriesCol - 1) / 2) * 50, 0);
                blockSeries[i, j].transform.Find("Text").GetComponent<Text>().text = "0";
            }
        }
        
        //blockSeries[i].GetComponent<Image>().color = new Color(1, 1, 1);
        //blockSeries[i].transform.Find("Text").GetComponent<Text>().text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (touchStr != lastTouchStr)
        {
            try
            {
                string[] newTouch = touchStr.Split(',');
                blockSeries[Int32.Parse(newTouch[0]), Int32.Parse(newTouch[1])].GetComponent<Image>().color = new Color(1, 1 - float.Parse(newTouch[2]) / 255, 1 - float.Parse(newTouch[2]) / 255);
                blockSeries[Int32.Parse(newTouch[0]), Int32.Parse(newTouch[1])].transform.Find("Text").GetComponent<Text>().text = newTouch[2].ToString();
            }
            catch (Exception)
            {
                Debug.Log("Invalid touch string -- " + touchStr);
            }

            lastTouchStr = touchStr;
        }
    }
}
