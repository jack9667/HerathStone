using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HistoryCard : MonoBehaviour {

    //定义卡牌位置，计算动画播放
    public Transform inCard;
    public Transform outCard;
    public Transform card1;
    public Transform card2;
    public GameObject cardPrefab;   //卡牌预制体


    private float yOffset;
    private List<GameObject> cardList = new List<GameObject>(); //历史卡牌list


    void Start() {
        yOffset = card2.position.y - card1.position.y;
    }

    void Update() {
        //右键ctrl创建卡牌
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            StartCoroutine(AddCard());
            
            
        }
    }

    //外部函数添加卡牌
    public IEnumerator AddCard() {
        GameObject go = GameObject.Instantiate(cardPrefab, inCard.position, Quaternion.identity) as GameObject ;    //下一帧NGUI才会调初始incard.position
        yield return null;//等一针
        go.transform.position = inCard.position;
        iTween.MoveTo(go, card1.position, 1f);//动画异步执行
        cardList.Add(go);       //新加的入list
        if (cardList.Count > 7) {
            //remove index at 0
            iTween.MoveTo(cardList[0], outCard.position, 1f);
            Destroy(cardList[0], 2);
            cardList.RemoveAt(0);
        }
        //list遍历往下移
        for (int i = 0; i < cardList.Count - 1; i++) {
            iTween.MoveTo(cardList[i], cardList[i].transform.position + new Vector3(0, yOffset, 0),0.5f);
        }
    }

}
