using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject normalChart;
    public GameObject infoChart;
    public void infoPut()
    {
        normalChart.SetActive(false);
        infoChart.SetActive(true);
    }
    public void infoQuit()
    {
        normalChart.SetActive(true);
        infoChart.SetActive(false);
    }
}
