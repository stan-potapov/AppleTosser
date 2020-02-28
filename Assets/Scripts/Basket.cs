using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
    [Header("Set Dynamically")]
    public Text scoreGT;

    [Header("Set in Inspector")]
    // Speed at which the Basket moves
    public float speed = 10f;
    // Distance where Basket turns around
    public float leftAndRightEdge = 25f;
    // Chance that the Basket will change directions
    public float chanceToChangeDirections = 0.02f;

    void Start() {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        // Set the starting number of points to 0
        scoreGT.text = "0";
    }

    void OnCollisionEnter(Collision coll) {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);
            // Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            // Add points for catching the apple
            score += 100;
            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();
            // Track the high score
            if (score > HighScore.score) {
                HighScore.score = score;
            }
        }
    }

    void Update() {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); // Move right
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate() {
        // Changing Direction Randomly is now time-based because of FixedUpdate()
        if (Random.value < chanceToChangeDirections) {
            speed *= -1; // Change direction
        }
    }
}