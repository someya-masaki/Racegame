using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    GameObject timerText;
    //カウントアップ
    float CountUp = 180.0f;
    public GameObject timeUpText;

    void Start()
    {
        this.timerText = GameObject.Find("TimeText");
        timeUpText.SetActive(false);
    }

    void Update()
    {
        CountUp -= Time.deltaTime;
        if(CountUp < 0)
        {
            timeUpText.SetActive(true);
            CountUp = 0;
            // 2秒後にリトライシーンに移行
            StartCoroutine(DelayMethod(2f, () =>
            {
                SceneManager.LoadScene("RetryScene");
                // 時間切れになったらタイマーをリセット
                ResetTimer();
            }));
        }
        this.timerText.GetComponent<Text>().text = CountUp.ToString("F1");
    }
    
    // タイマーをリセットする
    private void ResetTimer()
    {
        CountUp = 180.0f;
    }

    /// <summary>
    /// 渡された処理を指定時間後に実行する
    /// </summary>
    /// <param name="waitTime">遅延時間[ミリ秒]</param>
    /// <param name="action">実行したい処理</param>
    /// <returns></returns>
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
    
}
