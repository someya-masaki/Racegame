using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    GameObject timerText;
    //カウントアップ
    float CountUp = 180.0f;
    // ステージから落ちた時に表示するテキスト
    public GameObject GameOverText;

    void Start()
    {
        this.timerText = GameObject.Find("TimeText");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            GameOverText.SetActive(true);
            // 1.5秒後にリトライシーンに移行
            StartCoroutine(DelayMethod(1.5f, () =>
            {
                // ステージ外に入ったらタイマーをリセット
                ResetTimer();
                SceneManager.LoadScene("RetryScene");
            }));
            this.timerText.GetComponent<Text>().text = CountUp.ToString("F1");
        }
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
