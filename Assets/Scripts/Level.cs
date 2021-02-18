using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float CAMERA_ORTHO_SIZE = 50f;
    private const float PIPE_WIDTH = 7.8f;
    private const float PIPE_HEAD_HEIGHT = 3.75f;

    private void Start()
    {
        CreatePipe(50f, 20f);
        CreatePipe(40f, 40f);
        CreatePipe(30f, 60f);
        CreatePipe(20f, 80f);
        CreatePipe(10f, 100f);
    }

    private void CreatePipe(float height, float xPosition)
    {
        // Set up Pipe Head
        Transform pipeHead = Instantiate(GameAssets.getInstance().pfPipeHead);
        pipeHead.position = new Vector2(xPosition, -CAMERA_ORTHO_SIZE + height - PIPE_HEAD_HEIGHT * 0.5f);

        // Set up Pipe Body
        Transform pipeBody = Instantiate(GameAssets.getInstance().pfPipeBody);
        pipeBody.position = new Vector2(xPosition, -CAMERA_ORTHO_SIZE);

        SpriteRenderer pipeBodySpriteRenderer = pipeBody.GetComponent<SpriteRenderer>();
        pipeBodySpriteRenderer.size = new Vector2(PIPE_WIDTH, height);

        BoxCollider2D pipeBodyBoxCollider = pipeBody.GetComponent<BoxCollider2D>();
        pipeBodyBoxCollider.size = new Vector2(PIPE_WIDTH, height);
        pipeBodyBoxCollider.offset = new Vector2(0f, height * 0.5f);
    }
}
