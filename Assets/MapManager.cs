using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public float mapSizeXWidth;
    public float mapSizeZDepth;

    float mapThresholdMinX = 9;
    float mapThresholdMinZ = 12;

    float spawnWallThreshold = 7;

    float mapSizeXOld;
    float mapSizeZOld;
    public GameObject floor;
    public GameObject barrierXLeft;
    public GameObject barrierXRight;
    public GameObject barrierZFront;
    public GameObject barrierZBack;
    public GameObject pedestalFrontLeft;
    public GameObject pedestalBackRight;
    public GameObject spawnWallRed;
    public GameObject spawnWallBlue;
    public GameObject wallBack;
    public GameObject wallFront;
    public GameObject wallLeft;
    public GameObject wallRight;
    public GameObject pedestalWallFrontLeft;
    public GameObject pedestalWallBackRight;
    public GameObject wallCornerBack;
    public GameObject wallCornerFront;
    public GameObject centerWallRight;
    public GameObject centerWallLeft;

    public GameObject spawnLocationRed;
    public GameObject spawnLocationBlue;

    public GameObject redLight;
    public GameObject blueLight;


    // Update is called once per frame
    void Update()
    {
        if (mapSizeXOld != mapSizeXWidth || mapSizeZOld != mapSizeZDepth)
        {
            mapSizeXOld = mapSizeXWidth;
            mapSizeZOld = mapSizeZDepth;
            UpdateMap(mapSizeXWidth, mapSizeZDepth);
        }

        if (mapSizeXWidth < mapThresholdMinX)
        {
            //mapSizeXWidth = mapThresholdMinX;

            centerWallRight.SetActive(false);
            centerWallLeft.SetActive(false);

        } else
        {

            centerWallRight.SetActive(true);
            centerWallLeft.SetActive(true);
        }

        if (mapSizeZDepth < mapThresholdMinZ)
        {
            //mapSizeZDepth = mapThresholdMinZ;
            wallCornerBack.SetActive(false);
            wallCornerFront.SetActive(false);

        } else
        {
            wallCornerBack.SetActive(true);
            wallCornerFront.SetActive(true);

        }

        if (mapSizeXWidth < spawnWallThreshold || mapSizeZDepth < spawnWallThreshold)
        {
            spawnWallRed.SetActive(false);
            spawnWallBlue.SetActive(false);
        } else
        {
            spawnWallRed.SetActive(true);
            spawnWallBlue.SetActive(true);
        }
    }

    // Update map function
    public void UpdateMap(float x, float z)
    {
        mapSizeXWidth = x;
        mapSizeZDepth = z;

        floor.transform.localScale = new Vector3(mapSizeXWidth, 1, mapSizeZDepth);
        barrierXLeft.transform.localScale = new Vector3(0.01f, 3, mapSizeZDepth);
        barrierXRight.transform.localScale = new Vector3(0.01f, 3, mapSizeZDepth);
        barrierZFront.transform.localScale = new Vector3(0.01f, 3, mapSizeXWidth);
        barrierZBack.transform.localScale = new Vector3(0.01f, 3, mapSizeXWidth);

        barrierXLeft.transform.position = new Vector3(-mapSizeXWidth / 2, 1.5f, 0);
        barrierXRight.transform.position = new Vector3(mapSizeXWidth / 2, 1.5f, 0);
        barrierZFront.transform.position = new Vector3(0, 1.5f, mapSizeZDepth / 2);
        barrierZBack.transform.position = new Vector3(0, 1.5f, -mapSizeZDepth / 2);

        wallLeft.transform.position = new Vector3(-mapSizeXWidth / 2, wallLeft.transform.position.y, 0);
        wallRight.transform.position = new Vector3(mapSizeXWidth / 2, wallRight.transform.position.y, 0);

        wallFront.transform.position = new Vector3(0, wallFront.transform.position.y, mapSizeZDepth / 2);
        wallBack.transform.position = new Vector3(0, wallBack.transform.position.y, -mapSizeZDepth / 2);

        spawnLocationRed.transform.position = new Vector3(-mapSizeXWidth / 2 + 1, 1, -mapSizeZDepth / 2 + 1);
        spawnLocationBlue.transform.position = new Vector3(mapSizeXWidth / 2 - 1, 1, mapSizeZDepth / 2 - 1);
        redLight.transform.position = new Vector3(-mapSizeXWidth / 2 + 1, redLight.transform.position.y, -mapSizeZDepth / 2 + 1);
        blueLight.transform.position = new Vector3(mapSizeXWidth / 2 - 1,blueLight.transform.position.y, mapSizeZDepth / 2 - 1);

        spawnWallRed.transform.position = new Vector3(-mapSizeXWidth / 2 + 2, 1, -mapSizeZDepth / 2 + 2);
        spawnWallBlue.transform.position = new Vector3(mapSizeXWidth / 2 - 2, 1, mapSizeZDepth / 2 - 2);

        pedestalFrontLeft.transform.position = new Vector3(-mapSizeXWidth / 2 + 1, pedestalFrontLeft.transform.position.y, mapSizeZDepth / 2 - 1);
        pedestalBackRight.transform.position = new Vector3(mapSizeXWidth / 2 - 1, pedestalBackRight.transform.position.y, -mapSizeZDepth / 2 + 1);

        pedestalWallFrontLeft.transform.position = new Vector3(-mapSizeXWidth / 2 + 2, pedestalWallFrontLeft.transform.position.y, mapSizeZDepth / 2 - 2);
        pedestalWallBackRight.transform.position = new Vector3(mapSizeXWidth / 2 - 2, pedestalWallBackRight.transform.position.y, -mapSizeZDepth / 2 + 2);

        wallCornerBack.transform.position = new Vector3(mapSizeXWidth / 8, wallCornerBack.transform.position.y, -mapSizeZDepth / 4);
        wallCornerFront.transform.position = new Vector3(-mapSizeXWidth / 8, wallCornerFront.transform.position.y, mapSizeZDepth / 4);

    }
}
