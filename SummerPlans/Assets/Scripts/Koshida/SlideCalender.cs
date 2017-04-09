using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCalender : MonoBehaviour {

    public AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public Vector2 inPosition;        // スライドイン後の位置
    public Vector2 outPosition;      // スライドアウト後の位置
    public float duration = 1.0f;    // スライド時間（秒）

    // スライドイン（Pauseボタンが押されたときに、これを呼ぶ）
    public void SlideIn()
    {
        StartCoroutine("StartSlidePanel");
    }

    private IEnumerator StartSlidePanel()
    {
        float startTime = Time.time;    // 開始時間
        Vector2 startPos = transform.localPosition;  // 開始位置
        Vector2 moveDistance;            // 移動距離および方向

        if(CalenderManager.turn_flag)
            moveDistance = (inPosition - startPos);
        else
            moveDistance = (outPosition - startPos);

        while ((Time.time - startTime) < duration)
        {
            transform.position = startPos + moveDistance * animCurve.Evaluate((Time.time - startTime) / duration);
            yield return 0;        // 1フレーム後、再開
        }
        transform.position = startPos + moveDistance;
        
    }
}
