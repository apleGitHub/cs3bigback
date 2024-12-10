using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    [SerializeField] public TMPro.TextMeshProUGUI gameText;
    [SerializeField] SpriteRenderer whiteRect;
    [SerializeField] GameObject _bread;
    [SerializeField] GameObject _toast;
    [SerializeField] GameObject _burnt;
    

    private float reactionTime, startTime, randomDelayBeforeMeasuring;

    private bool clockIsTicking, timerCanBeStopped;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        reactionTime = 0f;
        startTime = 0f;
        randomDelayBeforeMeasuring = 0f;
        gameText.text = "Click to Start!";
        clockIsTicking = false;
        timerCanBeStopped = true;
        _bread.SetActive(false);
        _toast.SetActive(false);
        _burnt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _bread.SetActive(false);
            _toast.SetActive(false);
            _burnt.SetActive(false);

            if(!clockIsTicking)
            {
                StartCoroutine("StartMeasuring");
                gameText.text = "Wait for the toaster light to come on.";
                whiteRect.color = Color.red; 
                clockIsTicking = true;
                timerCanBeStopped = false;
            }else if (clockIsTicking && timerCanBeStopped)
                //try getting rid of timercanbestopped and see if work
            {
                StopCoroutine("StartMeasuring");
                reactionTime = Time.time - startTime;
                if(reactionTime < .5f){
                    gameText.text = "Perfect! You get Toast\n" + "Reaction time:\n" + reactionTime.ToString("N3") + " sec\n" + "Click to try again!";
                   _toast.SetActive(true);
                }else if(reactionTime > .5f){
                    gameText.text = "YOU BURNT IT! WERE COOKED\n" +"Reaction time:\n" + reactionTime.ToString("N3") + " sec\n" + "Click to try again!";
                   _burnt.SetActive(true);
                }
                //gameText.text = "Reaction time:\n" + reactionTime.ToString("N3") + " sec\n" + "Click to try again!";
                clockIsTicking = false;
            }else if (clockIsTicking && !timerCanBeStopped)
            {
                StopCoroutine("StartMeasuring");
                reactionTime = 0f;
                clockIsTicking = false;
                timerCanBeStopped = true;
                _bread.SetActive(true);
                gameText.text = "Too early.\n" + "You get bread.\n" + "Click to try again!";
            }
        } 
    }

    private IEnumerator StartMeasuring(){
        randomDelayBeforeMeasuring = Random.Range(2f, 7f);
        yield return new WaitForSeconds(randomDelayBeforeMeasuring);
        whiteRect.color = Color.green;
        startTime = Time.time;
        clockIsTicking = true;
        timerCanBeStopped = true;
    }
}
