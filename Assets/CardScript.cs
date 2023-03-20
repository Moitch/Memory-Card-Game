using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public LogicScript logic;
    public SpriteRenderer spriteRenderer;
    public Sprite back;
    public Sprite[] front;
    public int cardFront;
    public bool matchingCards = false;
    public bool alreadyMatched = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        for (int i = 0; i < logic.matchedCards.Count; i++)
        {
            Debug.Log(logic.matchedCards[i]);
            if (cardFront == logic.matchedCards[i])
            {
                alreadyMatched = true;
            }
        }
        if (!matchingCards && !alreadyMatched)
        {
            if (spriteRenderer.sprite == back)
            {
                if (logic.TwoCardsFlipped() == false)
                {
                    spriteRenderer.sprite = front[cardFront];
                    logic.WhichCardFlipped(cardFront);
                    matchingCards = logic.CheckMatchingCards();
                }
            }
            else
            {
                spriteRenderer.sprite = back;
                logic.UnflipCards(cardFront);

            }
        }

    }


}