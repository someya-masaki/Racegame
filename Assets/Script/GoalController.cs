using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    GameObject timerText;
    //カウントアップ
    float CountUp = 180.0f;
    // ゴール時に表示するテキスト
    public GameObject GoalText;

    void Start()
    {
        this.timerText = GameObject.Find("TimeText");
    }

    // トリガーに接触した瞬間に呼ばれる処理
    private void OnTriggerEnter(Collider collider)
    {
        // 接触したのがプレイヤーか
        if(collider.gameObject.CompareTag("Player"))
        {
            // ゴールが表示
            GoalText.SetActive(true);
            // 2秒後にリトライシーンに移行
            StartCoroutine(DelayMethod(2f, () =>
            {
                SceneManager.LoadScene("RetryScene");
                // ゴールしたらタイマーをリセット
                ResetTimer();
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
