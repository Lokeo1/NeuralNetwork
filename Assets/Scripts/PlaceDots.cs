using UnityEngine;

public class PlaceDots : MonoBehaviour
{
    public GameObject Safe;
    public GameObject Poison;
    /*public DrawSinus() {
        for (float x = -10f; x < 10f; x += 0.05f) {
            float sin = (float)System.Math.Sin(x);
            Instantiate(Safe, new Vector3(x, sin, -1), Quaternion.identity);
        }
    }*/
    public float[] dots_x;
    public float[] dots_y;
    NeuralNetwork network;
    void Start()
    {
        Debug.Log("HELLO\n");
        network = new NeuralNetwork(new int[] { 2, 3, 2 });
        Debug.Log(network.layers[0].weights[0,0]);
        int N = 200;
        dots_x = new float[N];
        dots_y = new float[N];
        for(int i = 0; i < N; i ++) {
            dots_x[i] = Random.Range(-10f, 10f);
            dots_y[i] = Random.Range(-5f, 5f);
            float sin = (float)System.Math.Sin(dots_x[i]);
            if (sin < dots_y[i]) {
                Instantiate(Safe, new Vector3(dots_x[i], dots_y[i], -1), Quaternion.identity);
            }
            else {
                Instantiate(Poison, new Vector3(dots_x[i], dots_y[i], -1), Quaternion.identity);
            }
        }

    }
}
