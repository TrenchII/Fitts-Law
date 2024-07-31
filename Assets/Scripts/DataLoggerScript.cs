using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataLoggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneManagerScript sceneManagerScript;
    public string filename = "";
    public string participant_id = "";
    public enum Device { mouse, touchpad };
    public Device device;
    public enum Width {one, two, three};
    public Width width;
    public Width oldWidth;
    public enum Distance {one, two, three};
    public Distance distance;
    public Distance oldDistance;
    public float time = 0.0f;
    public float FinalTime = 0.0f;
    public int wrong = 0;
    void Start()
    {
        filename = Application.dataPath + "/" + participant_id + ".csv";
        oldWidth = width;
        oldDistance = distance;
    }
    void Update() {
        if(oldWidth != width || oldDistance != distance) {
         if(distance == Distance.one) {
            if (width == Width.one) {
                sceneManagerScript.LoadScene("W1D1");
                oldWidth = width;
                oldDistance = distance;
            }
            else if(width == Width.two) {
                sceneManagerScript.LoadScene("W2D1");
                oldWidth = width;
                oldDistance = distance;
            }
            else {
                sceneManagerScript.LoadScene("W3D1");
                oldWidth = width;
                oldDistance = distance;
            }
        }
        else if (distance == Distance.two) {
            if (width  == Width.one) {
                sceneManagerScript.LoadScene("W1D2");
                oldWidth = width;
                oldDistance = distance;
            }
            else if(width  == Width.two) {
                sceneManagerScript.LoadScene("W2D2");
                oldWidth = width;
                oldDistance = distance;
            }
            else {
                sceneManagerScript.LoadScene("W3D2");
                oldWidth = width;
                oldDistance = distance;
            }
        }
        else {
            if (width  == Width.one) {
                sceneManagerScript.LoadScene("W1D3");
                oldWidth = width;
                oldDistance = distance;
            }
            else if(width  == Width.two) {
                sceneManagerScript.LoadScene("W2D3");
                oldWidth = width;
                oldDistance = distance;
            }
            else {
                sceneManagerScript.LoadScene("W3D3");
                oldWidth = width;
                oldDistance = distance;
            }
        }
    }
}
    public void WriteCSV() {
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine(""+participant_id+", "+device+", "+width+", "+distance+", "+FinalTime+", "+wrong);
        tw.Close();
        time = 0;
        wrong = 0;
        FinalTime = 0;
    }

}
