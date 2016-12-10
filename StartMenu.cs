using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

    public MovieTexture movTexture;

    public bool IsDrawMov = true;

    public bool isShowMessage = false;

    public TweenScale logoTweenScale;


    private bool isCanShowSelectRole = false;//是否可以显示角色选择界面

    public TweenPosition selectRoleTween;

    //public UISprite hero1;

    private UISprite heroSprite;    //当前选择的英雄大界面

    void Awake()
    {
        heroSprite = GameObject.Find("hero0").GetComponent<UISprite>();
    }

	// Use this for initialization
	void Start () {
        movTexture.loop = false;
        movTexture.Play();

        logoTweenScale.AddOnFinished(this.OnLogoTweenFinshed);  //????????
	}
	
	// Update is called once per frame
	void Update () {
        if (IsDrawMov)
        {
            if (Input.GetMouseButtonDown(0) && isShowMessage == false)
            {
                isShowMessage = true;
            }
            else if (Input.GetMouseButtonDown(0) && isShowMessage == true)
            {
                StopMov();
            }
        }
        if (IsDrawMov != movTexture.isPlaying)
        {
            StopMov(); 
        }

        if(isCanShowSelectRole){
            if(Input.GetMouseButtonDown(0)){
                           //显示角色选择界面
                            selectRoleTween.PlayForward();
                            isCanShowSelectRole=false;
            }

        }



	}

    void OnGUI()
    {
        if (IsDrawMov)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture);
            if (isShowMessage)
            {
                GUI.Label(new Rect(Screen.width / 2-75, Screen.height / 2-20, 200, 40), "再点击一次屏幕退出动画的播放");
            }
        } 
    }

    private void StopMov()
    {
        movTexture.Stop();
        IsDrawMov = false;

        logoTweenScale.PlayForward();
    }

    private void OnLogoTweenFinshed()
    {
        isCanShowSelectRole = true;
    }

    public void OnPlaybuttonClick()
    {
        BlackMask._instance.Show();
        VSShow._instance.Show(heroSprite.spriteName, "hero" + Random.Range(1, 10));
        //Application.loadedLevel();
        StartCoroutine(LoadPlayScene());
    }

    IEnumerator LoadPlayScene()
    {
        yield return new WaitForSeconds(3f);
        
        Application.LoadLevel(1);
        
    }

}
