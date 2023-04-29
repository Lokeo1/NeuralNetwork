using System.Collections;
using System.Collections.Generic;


public class ActivationFunc
{
    int type;
    public ActivationFunc(int Type) {
        type = Type;
        return;
    }
    //Activation
    public double Function(double input)
    {
        if (type == 0)
            return 1.0 / (1.0 + System.Math.Exp(-input));
        else
            return input;
    }
    public double Derivative(double input)
    {
        if (type == 0)
            return Function(input) * (1.0 - Function(input));
        else
            return 1;
    }
}
