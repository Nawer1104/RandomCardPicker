using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public static class WebRequest
{
    private class WebRequestMonoBehaviour : MonoBehaviour { }

    private static WebRequestMonoBehaviour web;

    private static void Init()
    {
        if (web == null)
        {
            GameObject gameObject = new GameObject("WebRequest");
            web = gameObject.AddComponent<WebRequestMonoBehaviour>();
        }
    }

    [Obsolete]
    public static void Get(string url, Action<string> onError, Action<string> onSuccess)
    {
        Init();
        web.StartCoroutine(GetCoroutine(url, onError, onSuccess));
    }

    [Obsolete]
    private static IEnumerator GetCoroutine(string url, Action<string> onError, Action<string> onSuccess)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                onError(unityWebRequest.error);
            } else
            {
                onSuccess(unityWebRequest.downloadHandler.text);
            }
        }
    }

    public static void GetTexture(string url, Action<string> onError, Action<Texture2D> onSuccess)
    {
        Init();
        web.StartCoroutine(GetTextureCoroutine(url, onError, onSuccess));
    }

    private static IEnumerator GetTextureCoroutine(string url, Action<string> onError, Action<Texture2D> onSuccess)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError || unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                onError(unityWebRequest.error);
            }
            else
            {
                DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                onSuccess(downloadHandlerTexture.texture);
            }
        }
    }
}
