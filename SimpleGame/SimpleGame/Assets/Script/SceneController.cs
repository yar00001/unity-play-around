using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh scoreObj;
    [SerializeField] private TextMesh gameOverObj;

    private MemoryCard firstCard;
    public MemoryCard FirstCard
    {
        get { return firstCard; }
    }

    private MemoryCard secondCard;
    public MemoryCard SecondCard
    {
        get { return secondCard; }
    }

    private int score = 0;

    // assuming we only have two cards
    int[] numbers = { 0, 0, 1, 1 };

    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    // Use this for initialization
    void Start()
    {
        // // get a random id
        // int imageId = Random.Range(0, images.Length);
        // // set the Sprite image
        // originalCard.SetCard(imageId, images[imageId]);

        // Debug.Log("random image is set to id: " + imageId + " image: " + images[imageId].name);

        createImageGrid();
    }

    void createImageGrid()
    {
        Vector3 basePosition = originalCard.transform.position;

        shuffle(numbers);
        Debug.Log(numbers.ToString());
        int count = numbers.Length - 1;

        for (int i = 0; i < images.Length; i++)
        {
            for (int j = 0; j < images.Length; j++)
            {
                MemoryCard memoryCard;
                if (i == 0 && j == 0)
                {
                    memoryCard = originalCard;
                }
                else
                {
                    memoryCard = Instantiate(originalCard) as MemoryCard;
                }
                int id = numbers[count];
                count--;
                memoryCard.SetCard(id, images[id]);

                // Debug.Log("random image is set to id: " + id +
                // " image: " + images[id].name + " - Position: " + i + " + " + j);

                // moving the cards
                float posX = (offsetX * i) + basePosition.x;
                float posY = -(offsetY * j) + basePosition.y;
                memoryCard.transform.position = new Vector3(posX, posY, basePosition.z);
            }
        }
    }

    void shuffle(int[] arr)
    {
        // 3 times
        for (int t = 0; t < 3; t++)
        {
            int i = Random.Range(0, arr.Length);
            int j = Random.Range(0, arr.Length);
            Debug.Log("swapping " + i + " and " + j);
            swapArray(arr, i, j);
        }
    }

    void swapArray(int[] arr, int i, int j)
    {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }

    public void Reveal(MemoryCard card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else
        {
            secondCard = card;
            // https://docs.unity3d.com/Manual/Coroutines.html
            StartCoroutine(CheckScore());
        }
    }

    public bool CanReveal()
    {
        return secondCard == null;
    }

    private IEnumerator CheckScore() {

        if (firstCard.ID == secondCard.ID) {
            score++;
            scoreObj.text = "Score: " + score;
            Debug.Log("Found a match! New Score is: " + score);

            if (score == images.Length) {
                gameOverObj.text = "Game Over!";
            }
        } else {
            // the function will paues at 'yield' part and resume in next frame
            yield return new WaitForSeconds(.5F);
            firstCard.Unreveal();
            secondCard.Unreveal();
        }

        firstCard = null;
        secondCard = null;
    }

    public void RestartGame() {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
