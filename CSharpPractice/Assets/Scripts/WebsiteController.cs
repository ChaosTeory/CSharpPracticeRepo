using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.VersionControl;
using UnityEngine;
//using Threading.Tasks;

public class WebsiteController : MonoBehaviour {
    
	// Use this for initialization
	  public List<string> urls;


    /*
    private async Task TriggerMethod()
    {
        string _result = await Task.Run(() => DownloadWebSiteAsync());
        return _result;

    }
    */
    private string DownloadWebSiteAsync()
    {
        string s = "";
        foreach (string url in urls)
        {
            using (WWW www = new WWW(url))
            {
                //if (!www.isDone)
                //    return;
                //yield return www;
                Renderer renderer = GetComponent<Renderer>();
                s += www.text;
                Debug.Log("MESSAGE-" + urls.IndexOf(url) + ": " + www.text);
                //renderer.material.mainTexture = www.texture;
                
            }
        }
        return s;
    }
}
