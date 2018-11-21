using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssigningPin
{
  class Program
  {
    public static Random random = new Random();
    public static List<int> pinList = new List<int>();
    public static int pinCount = 0;

    static void Main(string[] args)
    {
      
      GenerateListOfPin();

      Console.ReadLine();
    }

    public static void GenerateListOfPin()
    {

      while (pinCount < 1000)
      {
        var pin = "";

        int pinLength = 0;

        while (pinLength < 4)
        {
          var tempPin = pin;

          tempPin += GenerateRandomNumber(pinLength).ToString();

          if (!CheckIncremental(tempPin, pinLength) && !CheckRepeated(tempPin))
          {
            pin = tempPin;
            pinLength++;
          }
        }

        int finalPin = int.Parse(pin);

        if (!CheckUnique(finalPin))
        {
          pinList.Add(finalPin);

          Console.WriteLine(pin);

          pinCount++;
        }
      }

    }

    public static int GenerateRandomNumber(int index)
    {
      try
      {
        int randomNumber;

        if (index == 0 || index == 2)
          randomNumber = random.Next(2, 9);
        else
          randomNumber = random.Next(1, 9);

        return randomNumber;
      }
      catch (Exception)
      {

        throw;
      }

    }

    public static bool CheckUnique(int pinParam)
    {

      try
      {
        foreach (int pin in pinList)
        {
          if (pin == pinParam)
          {
            return true;
          }
        }
      }
      catch (Exception)
      {

        throw;
      }

      return false;
    }

    public static bool CheckRepeated(string pinParam)
    {

      try
      {
        int pinLength = pinParam.Count();

        for (int i = 0; i < pinLength - 1; i++)
        {
          for (int j = 0; j < pinLength; j++)
          {
            if (i == j)
            {
              continue;
            }
            else
            {
              if (pinParam[i] == pinParam[j])
              {
                return true;
              }
            }
          }
        }
      }
      catch (Exception)
      {

        throw;
      }

      return false;
    }

    public static bool CheckIncremental(string pinParam, int index)
    {

      try
      {
        int pinLength = pinParam.Count();     

        for (int i = index; i < pinLength - 1; i++)
        {
          if (pinParam[i - 1] < pinParam[i])
          {
            return true;
          }
        }

      }
      catch (Exception)
      {

        throw;
      }

      return false;

    }

  }
}
