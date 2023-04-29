using System;
using System.Collections;
using System.Collections.Generic;

public class CostFunc
{
    int type;
    public CostFunc(int costtype) { 
        type = costtype;
    }

    double diffCost(double output, double expected) {
        double Error = output - expected;
        return Error * Error;
    }
    private double diffDer(double output, double expected)
    {
        return 2.0 * (output - expected);
    }

    double logCost(double output, double expected) {
        if (output == 1.0 - expected) return 10000000;
        if(expected == 1.0) return -System.Math.Log(output);
        else return -System.Math.Log(1.0-output);
    }
    double logDer(double output, double expected) {
        if (expected == 1.0) {
            if (output == 0.0) return -100;
            return -1.0 / output;
        }
        else
        {
            if (output == 1.0) return -100;
            return -1.0 / (1.0 - output);
        }
    }

    public double NodeCost(double expected, double output)
    {
        if (type == 0) return diffCost(output, expected);
        else return logCost(output, expected);
    }

    public double NodeCostDerivative(double output, double expected)
    {
        if(type == 0) return diffDer(output, expected);
        else return logDer(output, expected);
    }
}