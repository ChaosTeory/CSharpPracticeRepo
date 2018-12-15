using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.VersionControl;
using UnityEngine;

public class WebsiteController : MonoBehaviour {
    
	// Use this for initialization
	  public List<string> urls;

    //private async void Start()
    //{
    //    await Task.Run(()=>DownloadWebSite());    
    //}


    private void DownloadWebSiteAsync()
    {
        foreach (string url in urls)
        {
            using (WWW www = new WWW(url))
            {
                if (!www.isDone)
                    return;
                //yield return www;
                Renderer renderer = GetComponent<Renderer>();
                Debug.Log("MESSAGE-" + urls.IndexOf(url) + ": " + www.text);
                //renderer.material.mainTexture = www.texture;

            }
        }

    }
}
