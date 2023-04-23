using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
    int NumNodesIn, NumNodesOut;
    public double[,] weights;
    double[] biases;
    public Layer(int numNodesIn, int numNodesOut) {
        NumNodesIn = numNodesIn;
        NumNodesOut = numNodesOut;
        weights = new double[NumNodesIn, NumNodesOut];
        biases = new double[NumNodesOut];
    }
    public double[] calculateOutputs(double[] inputs) {
        double[] outputs = new double[NumNodesOut];
        for (int NodeOut = 0; NodeOut < NumNodesOut; NodeOut++) {
            double output = biases[NodeOut];
            for(int NodeIn = 0; NodeIn < NumNodesIn; NodeIn ++) { 
                output += inputs[NodeOut] * weights[NodeIn, NodeOut];
            }
            outputs[NodeOut] = output;
        }
        return outputs;
    }
}

public class NeuralNetwork
{
    public Layer[] layers;

    public NeuralNetwork(params int[] layerSizes) { 
        layers = new Layer[layerSizes.Length - 1];
        for(int i = 0; i < layers.Length; i++) {
            layers[i] = new Layer(layerSizes[i], layerSizes[i+1]);
        }
    }
    public double[] calculateOutputs(double[] inputs) { 
        foreach(Layer layer in layers) { 
            inputs = layer.calculateOutputs(inputs);
        }
        return inputs;
    }
    int Classify(double[] inputs) {
        double[] outputs = calculateOutputs(inputs);
        if (outputs[0] > outputs[1]) return 0;
        else return 1;
    }
}
