using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MejorasStatic 
{
    public static int coins;
    public static bool[] mejorasDesbloqueadas = new bool[] { false, false, false};

    public static void compraMejora(int i)
    {
        if(i==0 && coins>=5)
        {
            coins -= 5;
            mejorasDesbloqueadas[0] = true;
        }
        else
            if(i==1 && coins>=10)
        {
            coins -= 10;
            mejorasDesbloqueadas[1] = true;
        }
        else 
            if(i==2 && coins >=15)
        {
            coins -= 15;
            mejorasDesbloqueadas[2] = true;
        }
    }
}
