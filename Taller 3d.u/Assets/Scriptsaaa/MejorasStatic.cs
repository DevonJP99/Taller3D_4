using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MejorasStatic 
{
    public static int coins;
    public static bool[] mejorasDesbloqueadasGaranty = new bool[] { false, false, false};
    public static bool[] mejorasDesbloqueadasCarrito = new bool[] { false };
    public static bool ofertaslimitas=false;
    public static bool pesado=false;
    public static int totalP;
    public static int puntoT;
    public static int mejorP;
    public static void compraMejora(int i)
    {
        if(i==0 && coins>=5)
        {
            coins -= 5;
            mejorasDesbloqueadasGaranty[0] = true;
        }
        else
            if(i==1 && coins>=10)
        {
            coins -= 10;
            mejorasDesbloqueadasGaranty[1] = true;
        }
        else 
            if(i==2 && coins >=15)
        {
            coins -= 15;
            mejorasDesbloqueadasGaranty[2] = true;
        }
    }
    public static void Cart(int g)
    {
        if(g==0 && coins>=5)
        {
            coins -= 5;
            mejorasDesbloqueadasCarrito[0] = true;
        }
    }
}
