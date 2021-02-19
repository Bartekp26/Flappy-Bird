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
        CreateGapPipes(50f, 30f, 40f);
    }

    private void CreateGapPipes(float gapY, float gapSize, float xPosition){
        CreatePipe(gapY - gapSize * 0.5f, xPosition, true);
        CreatePipe(CAMERA_ORTHO_SIZE * 2f - gapY - gapSize * 0.5f, xPosition, false);
    }

    private void CreatePipe(float height, float xPosition, bool createBottom)
    {
        // Set up Pipe Head
        Transform pipeHead = Instantiate(GameAssets.getInstance().pfPipeHead);
        float pipeHeadYPosition;
        if (createBottom){
            pipeHeadYPosition = -CAMERA_ORTHO_SIZE + height - PIPE_HEAD_HEIGHT * 0.5f;
        } else {
            pipeHeadYPosition = +CAMERA_ORTHO_SIZE - height + PIPE_HEAD_HEIGHT * 0.5f;
        }
        pipeHead.position = new Vector2(xPosition, pipeHeadYPosition);

        // Set up Pipe Body
        Transform pipeBody = Instantiate(GameAssets.getInstance().pfPipeBody);
        float pipeBodyYPosition;
        if (createBottom){
            pipeHeadYPosition = -CAMERA_ORTHO_SIZE;
        } else {
            pipeHeadYPosition = +CAMERA_ORTHO_SIZE;
            pipeBody.localScale = new Vector2(1, -1);
        }
        pipeBody.position = new Vector2(xPosition, pipeHeadYPosition);

        SpriteRenderer pipeBodySpriteRenderer = pipeBody.GetComponent<SpriteRenderer>();
        pipeBodySpriteRenderer.size = new Vector2(PIPE_WIDTH, height);

        BoxCollider2D pipeBodyBoxCollider = pipeBody.GetComponent<BoxCollider2D>();
        pipeBodyBoxCollider.size = new Vector2(PIPE_WIDTH, height);
        pipeBodyBoxCollider.offset = new Vector2(0f, height * 0.5f);
    }
}
