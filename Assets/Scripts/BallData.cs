using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class BallData : MonoBehaviour
{
    public static BallData instance;
    public BallItemData[] balls;

    public BallItemData GetRandomBall()
    {
        return balls[Random.Range(0, balls.Length)];
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        instance = this;
    }
}
[System.Serializable]
public class BallItemData
{
    public GameObject ball;
    public Color color;
}
[CustomEditor(typeof(BallData))]
public class BallDataEditor:Editor
{
    BallData script;
    public void OnEnable()
    {
        script = (BallData)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Balls To Colors"))
        {
            SetColorsByBalls(script.balls);
        }    
        if (GUILayout.Button("Colors To Balls"))
        {
            SetBallsByColors(script.balls);
        }

        EditorGUILayout.Space();
        DrawDefaultInspector();
    }

    private void SetColorsByBalls(BallItemData[] balls)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].color = balls[i].ball.GetComponent<MeshRenderer>().sharedMaterial.color;
        }
    }

    private void SetBallsByColors(BallItemData[] balls)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].ball.GetComponent<MeshRenderer>().sharedMaterial.color= balls[i].color;
        }
    }
}

