using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingCtrl : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image loadingBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation aop = SceneManager.LoadSceneAsync(nextScene);
        aop.allowSceneActivation = false;

        float timer = 0f;
        while (!aop.isDone)
        {
            yield return null;

            if(aop.progress > 0.9f)  //90% 이전
            {
                //로딩 진행도에 따라 로딩바가 채워짐
                loadingBar.fillAmount = aop.progress;
            }
            else  //90% 이후
            {
                //페이크 로딩. 10%를 1초간 채운 뒤 씬을 불러옴.
                timer += Time.unscaledDeltaTime;
                loadingBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(loadingBar.fillAmount >= 1f)
                {
                    aop.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
