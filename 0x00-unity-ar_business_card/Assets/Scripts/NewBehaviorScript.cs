using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviorScript : MonoBehaviour
{
    public string GithubUrl;
    public string TwitterUrl;
    // public string FacebookUrl;
    // public string InstagramUrl;
    // public string YoutubeUrl;
    // public string TwitchUrl;
    // public string DiscordUrl;
    // public string WebsiteUrl;
    // public string EmailUrl;
    // public string SteamUrl;
    public string LinkedInUrl;
    public GameObject trueSend;
    public GameObject topButton;
    public GameObject backButton;


    public void OpenGithub()
    {
        Application.OpenURL(GithubUrl);
    }

    public void OpenEmail()
    {
        System.Diagnostics.Process.Start("mailto:christopher.caswell@rocketmail.com?subject=Sweet%20AR%20card%20my%20dude&body=Sell%20me%20your%20product%20nao");
    }

    public void OpenTwitter()
    {
        Application.OpenURL(TwitterUrl);
    }

    public void OpenLinkedIn()
    {
        Application.OpenURL(LinkedInUrl);
    }

    public void OpenTrueSend()
    {
        backButton.SetActive(true);
        trueSend.SetActive(true);
        topButton.SetActive(false);
    }

    public void CloseTrueSend()
    {
        backButton.SetActive(false);
        trueSend.SetActive(false);
        topButton.SetActive(true);
    }
}
