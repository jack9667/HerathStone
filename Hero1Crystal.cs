using UnityEngine;
using System.Collections;

public class Hero1Crystal : MonoBehaviour {

    public int usableNumber = 1;    //当前可用数量
    public int totalNumber = 1;     //拥有总数   拥有减去可用就是已经用掉的就是暗色的
    public int maxNumber;           //最大数量
    public UISprite[] crystals;     //水晶数组

    private UILabel label;

    void Awake(){
        maxNumber = crystals.Length;
        label = this.GetComponent<UILabel>();
    }

    void Update(){
        UpdateShow();
    }

    void UpdateShow(){
        //从水晶2开始所有置为false
        for (int i = totalNumber; i < maxNumber; i++){
            crystals[i].gameObject.SetActive(false);
        }
        //改变可用水晶
        for (int i = 0; i < totalNumber; i++) {
            crystals[i].gameObject.SetActive(true);
        }
        //把不可用的显示为空水晶
        for (int i = usableNumber; i < totalNumber; i++) {
            crystals[i].spriteName = "TextInlineImages_normal";
        }
        //改变可用水晶update显示
        for (int i = 0; i < usableNumber; i++) {
            if (i == 9) {
                crystals[i].spriteName = "TextInlineImages_" + (i + 1);
            }else {
                crystals[i].spriteName = "TextInlineImages_0" + (i + 1);
            }
            
        }
        label.text = usableNumber + "/" + totalNumber;
    }
}
