using UnityEngine;
using TMPro;


public class Calculator : MonoBehaviour
{ 
    
   //Interface of the calculator is complete on Unity, but over all is not functional but I tried my best with what I could do. The main issue was Unity not allowing me to attach the TextMeshPro 
   //variable to the inspector because of some unknown errors that showed up when importing Calculator.cs.
   
    public class TextMeshProUGUI textResult;

    private float prevInput = 0f;
    private bool clearPrevInput = false;
    private EquationType equationType;

    private void Start()
    {
        Clear();
    }
    
    public void AddInput(string input)
    {
      

        if (clearPrevInput)
        {
            textResult.text = string.Empty;
            clearPrevInput = false;
        }


        textResult.text += input;

    }

    public void SetEquationAsAdd()
    {

        prevInput = float.Parse(textResult.text);
        clearPrevInput = true;
        equationType = EquationType.ADD;
    }


    public void SetEquationAsSubtract()
    {

        prevInput = float.Parse(textResult.text);
        clearPrevInput = true;
        equationType = EquationType.SUBTRACT;


    }

    public void SetEquationAsMultiply()
    {

        prevInput = float.Parse(textResult.text);
        clearPrevInput = true;
        equationType = EquationType.MULTIPLY;


    }

    public void SetEquationAsDIVIDE()
    {

        prevInput = float.Parse(textResult.text);
        clearPrevInput = true;
        equationType = EquationType.DIVIDE;


    }

    public void Add()
    {


        {
            float currentInput = float.Parse(textResult.text);
            float result = prevInput + currentInput;
            textResult.text = result.ToString();
        }

    }


    public void Subtract()
    {

        {
            float currentInput = float.Parse(textResult.text);
            float result = prevInput - currentInput;
            textResult.text = result.ToString();
        }

    }

    public void Multiply()
    {
  

        {
            float currentInput = float.Parse(textResult.text);
            float result = prevInput * currentInput;
            textResult.text = result.ToString();
        }

    }


    public void Divide()
    {
     

        {
            float currentInput = float.Parse(textResult.text);
            float result = prevInput / currentInput;
            textResult.text = result.ToString();
        }

    }

    public void Clear()
    {
  

        textResult.text = "0";
        clearPrevInput = true;
        prevInput = 0;

     
        equationType = EquationType.None;        
    }

    public void Calculate()
    {
    
        if (equationType == EquationType.ADD) Add();
        else if (equationType == EquationType.SUBTRACT) Subtract();
        else if (equationType == EquationType.MULTIPLY) Multiply();
        else if (equationType == EquationType.DIVIDE) Divide();
    }

    public enum EquationType
    {
        None = 0,
        ADD = 1,
        SUBTRACT = 2,
        MULTIPLY = 3,
        DIVIDE = 4
    }
}
