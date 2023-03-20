using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject card;
    public float yPosition;
    public float xPosition;
    public List<int> cardId = new() { 0, 1, 2, 3, 0, 1, 2, 3 };
    public List<int> matchedCards = new();
    public int listLength;
    public int[] cardsFlipped = { -1, -2 };
    public int randomNumber = 0;
    public int matchCount = 0;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        card = GameObject.Find("CardBack");
        listLength = cardId.Count;
        yPosition = 2.0f;
        xPosition = -2.0f;
        for (int i = 0; i < 7; i++)
        {
            randomNumber = Random.Range(0, cardId.Count);
            var tempCard = Instantiate(card, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
            xPosition += 4;
            tempCard.GetComponent<CardScript>().cardFront = cardId[randomNumber];
            cardId.Remove(cardId[randomNumber]);
            if (i == (listLength / 2 - 2))
            {
                yPosition = -2.0f;
                xPosition = -6.0f;
            }
        }
        card.GetComponent<CardScript>().cardFront = cardId[0];
    }

    void Update()
    {
        if (matchCount >= 4)
        {
            GameWon();
        }
    }
    public bool TwoCardsFlipped()
    {
        bool twoCards = false;
        if (cardsFlipped[0] >= 0 && cardsFlipped[1] >= 0)
        {
            twoCards = true;
        }
        return twoCards;
    }

    public void WhichCardFlipped(int cardNum)
    {
        if (cardsFlipped[0] == -1)
        {
            cardsFlipped[0] = cardNum;
        }
        else if (cardsFlipped[1] == -2)
        {
            cardsFlipped[1] = cardNum;
        }
    }

    public void UnflipCards(int cardNum)
    {
        if (cardsFlipped[0] == cardNum)
        {
            cardsFlipped[0] = -1;
        }
        else if (cardsFlipped[1] == cardNum)
        {
            cardsFlipped[1] = -2;
        }
    }

    public bool CheckMatchingCards()
    {
        bool matching = false;
        if (cardsFlipped[0] == cardsFlipped[1])
        {
            matchedCards.Add(cardsFlipped[0]);
            matchedCards.Add(cardsFlipped[1]);
            cardsFlipped[0] = -1;
            cardsFlipped[1] = -2;
            matching = true;
            matchCount++;
        }

        return matching;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameWon()
    {
        gameOverScreen.SetActive(true);
    }


}
