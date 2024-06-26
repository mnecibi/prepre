using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class introCine : MonoBehaviour
{
    public GameObject main;
    public carnet_anim carnet;
    public carnet_fill cf;
    public float speed1 = 1.0f;
    public float speed2 = 1.0f;
    public float waintingTime = 0.0f;

    public LeanTweenType easeType;
    public LeanTweenType easeType1;

    public flicker flckr;

    private bool first = true;


    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveY(main,0.0f,speed1)/*.setOnComplete(startGame)*/.setEase(easeType);
        lightOn();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && first)
        {
            startGame();
            first = false;
        }
    }

    private void firstLaunch()
    {
        carnet.open();
        cf.writeSound();
        //enabled = false;
    }

    public void startGame()
    {
        LeanTween.moveX(main,-0.36f,speed2).setDelay(waintingTime).setOnComplete(pauseFirst).setEase(easeType1);
    }

    private void pauseFirst()
    {
        StartCoroutine(pauseLaunch());
    }

    private IEnumerator pauseLaunch()
    {
        yield return new WaitForSeconds(0.5f);
        firstLaunch();
    }

    async void lightOn()
    {
        await Task.Delay(5000);
        flckr.enabled = true;
    }
}

