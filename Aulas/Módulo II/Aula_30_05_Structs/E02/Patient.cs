using System;

namespace E02
{
    public class Patient
    {
        public string name;

        public int age;

        public IMC IMC;

        public static double ImcCalculator(double weight, double height)
        {
            double IMC = weight / (height * height);

            return IMC;
        }

        public static string ImcDiagnosis(double IMC)
        {
            if (IMC < 16)
                return "Baixo peso Grau III";
            else if (IMC >= 16 && IMC < 17)
                return "Baixo peso Grau II";
            else if (IMC >= 17 && IMC < 18.5)
                return "Baixo peso Grau I";
            else if (IMC >= 18.5 && IMC < 25)
                return "Peso Ideal";
            else if (IMC >= 25 && IMC < 30)
                return "Sobrepeso";
            else if (IMC >= 30 && IMC < 35)
                return "Obesidade Grau I";
            else if (IMC >= 35 && IMC < 40)
                return "Obesidade Grau II";
            else
                return "Obesidade Grau III";
        }
    }
}
