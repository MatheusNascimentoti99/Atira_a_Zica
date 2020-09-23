using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public int speed;
    public GameObject MosquitoPrefab;
    public GameObject ShotPrefab;
    public Text txt_highScore;
    public Text txt_score;
    public Text txt_blood;
    private int score;
    private int blood = 10;

    private float enemyPopOut;
    private float lastShot;
    // Start is called before the first frame update
    void Start()
    {
        UpHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();
        if(blood <= 0)
        {
            LevelManager.levelManeger.Gameover(score);
        }
    }
    private void FixedUpdate()
    {
        MakeEnemy();
    }

    private void Move()
    {
        Vector2 position = this.transform.position;
        if (Input.GetButton("Vertical"))
        {
            position.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        }
        else if (Input.GetButton("Horizontal"))
        {
            position.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        }
        this.transform.position = position;
    }

    private void Shot()
    {
        if (Input.GetButton("Jump") && lastShot > 0.5)
        {
            GetComponent<AudioSource>().Play();
            Instantiate(ShotPrefab, new Vector2(this.transform.position.x, this.transform.position.y + 2), Quaternion.identity);
            lastShot = 0;
        }
        lastShot += Time.deltaTime;
    }


    private void MakeEnemy()
    {
        if (enemyPopOut > 3 - Time.time / 200)
        {
            int positionX = Random.Range(-8, 8);
            Instantiate(MosquitoPrefab, new Vector2(positionX, 5), Quaternion.identity);
            enemyPopOut = 0;
        }

        enemyPopOut += Time.deltaTime;
    }


    public void upScore()
    {
        txt_score.text = "Pontos: " + score;
    }
    public void incrementScore()
    {
        this.score += 1;
    }
    public void upBlood()
    {
        txt_blood.text = "Sangue restante: " + blood;
    }

    private void UpHighScore()
    {
        txt_highScore.text = "Melhor pontuação: " + LevelManager.levelManeger.GetHighScore();
    }
    public void decrementBlood()
    {
        this.blood -= 1;
    }

}
