using UnityEngine;
using System.Collections;

public class Hero2Crystal : MonoBehaviour {

    public int usableNumber = 1;    //当前可用数量
    public int totalNumber = 1;     //拥有总数   拥有减去可用就是已经用掉的就是暗色的

    private UILabel label;

    void Awake() {
        label = this.GetComponent<UILabel>();
    }

    //显示水晶方法
    public void UpdateShow() {
        label.text = usableNumber + "/" + totalNumber;
    }
    
}
