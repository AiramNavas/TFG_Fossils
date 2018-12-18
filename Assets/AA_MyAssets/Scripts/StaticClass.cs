using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticClass
{
    [System.ComponentModel.DefaultValue(false)]
    public static bool InicializadaTablaFosiles { get; set; }

    public static string Edad { get; set; }
    public static List<string> FosilesClasificados { get; set; }
    public static Dictionary<string, string> Fosiles { get; set; }
    public static int Escena { get; set; }
    public static string FosilEnMano { get; set; }
    public static Dictionary<string, int> PosicionCajaDisponible { get; set; }
    public static Dictionary<string, int> FosilEnCaja { get; set; }
    public static Dictionary<string, string> Zonacion { get; set; }

    public static int MisionActual { get; set; }
    public static int ContadorObjetivosConseguidos { get; set; }
    public static List<string> FosilesDeLaMision { get; set; }
    public static bool TieneTrajeDeBuzo { get; set; }
    public static bool Zapatillas { get; set; }

    public static bool JugadorEnElAgua { get; set; }

    public static Dictionary<string, AudioClip> AudiosDelJuego { get; set; }
}