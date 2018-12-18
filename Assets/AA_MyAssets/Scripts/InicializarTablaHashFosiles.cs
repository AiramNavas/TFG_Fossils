using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializarTablaHashFosiles : MonoBehaviour {

    public AudioClip AbrirLibro;
    public AudioClip CerrarLibro;
    public AudioClip Excavar;
    public AudioClip Picar;
    public AudioClip MisionCompletada;
    public AudioClip PisarArena1;
    public AudioClip PisarArena2;
    public AudioClip PisarPiedra1;
    public AudioClip PisarPiedra2;

    // Use this for initialization
    void Start () {
        if (!StaticClass.InicializadaTablaFosiles) {

            StaticClass.FosilesClasificados = new List<string>();
            StaticClass.FosilEnCaja = new Dictionary<string, int>();
            StaticClass.FosilEnMano = "";
            StaticClass.TieneTrajeDeBuzo = false;
            StaticClass.Zapatillas = false;
            StaticClass.JugadorEnElAgua = false;
            StaticClass.Edad = "Cuaternario";
            StaticClass.Escena = 0;
            StaticClass.MisionActual = 1;
            StaticClass.ContadorObjetivosConseguidos = 0;

            StaticClass.PosicionCajaDisponible = new Dictionary<string, int>
            {
                { "Cuaternario", 0 },
                { "Neogeno", 0 },
                { "Ambos", 0 }
            };

            StaticClass.Fosiles = new Dictionary<string, string>
            {
                { "Bolma_rugosa", "Cuaternario" },
                { "Bursa_Scrobilator", "Cuaternario" },
                { "Cantharus_viverratus", "Cuaternario" },
                { "Certium_vulgatum", "Ambos" },
                { "Charonia", "Cuaternario" },
                { "Cymatium_trigonum", "Cuaternario" },
                { "Hexaplex_Trunculus", "Cuaternario" },
                { "Mitra_Zonata_Marryat", "Ambos" },
                { "Erosaria_Spurca", "Cuaternario" },
                { "Saccostrea_Cuccullata", "Neogeno" },
                { "Stramonita_haemastoma", "Cuaternario" },
                { "Tetraclita", "Neogeno" },
                { "Venus_verrucosa", "Cuaternario" },
                { "Vermetus_Adansonii", "Ambos" },
                { "Patella_Candei", "Cuaternario" },
                { "Pecten_Jacobaeus", "Ambos" },
                { "Persististrombus_latus", "Cuaternario" }
            };

            StaticClass.Zonacion = new Dictionary<string, string>
            {
                { "Bolma_rugosa", "Rocosa" },
                { "Bursa_Scrobilator", "Rocosa" },
                { "Cantharus_viverratus", "Rocosa" },
                { "Certium_vulgatum", "Arenosa" },
                { "Charonia", "Arenosa" },
                { "Cymatium_trigonum", "Arenosa" },
                { "Hexaplex_Trunculus", "Arenosa" },
                { "Mitra_Zonata_Marryat", "Rocosa" },
                { "Erosaria_Spurca", "Rocosa" },
                { "Saccostrea_Cuccullata", "Arenosa" },
                { "Stramonita_haemastoma", "Rocosa" },
                { "Tetraclita", "Arenosa" },
                { "Venus_verrucosa", "Arenosa" },
                { "Vermetus_Adansonii", "Rocosa" },
                { "Patella_Candei", "Rocosa" },
                { "Pecten_Jacobaeus", "Arenosa" },
                { "Persististrombus_latus", "Arenosa" }
            };

            StaticClass.FosilesDeLaMision = new List<string>
            {
                { "Bolma_rugosa" },
                { "Bursa_Scrobilator" },
                { "Cantharus_viverratus" },
                { "Charonia" },
                { "Cymatium_trigonum" },
                { "Hexaplex_Trunculus" }
            };
            
            StaticClass.AudiosDelJuego = new Dictionary<string, AudioClip>
            {
                { "AbrirLibro", AbrirLibro },
                { "CerrarLibro", CerrarLibro },
                { "Excavar", Excavar },
                { "Picar", Picar },
                { "MisionCompletada", MisionCompletada },
                { "PisarArena1", PisarArena1 },
                { "PisarArena2", PisarArena2 },
                { "PisarPiedra1", PisarPiedra1 },
                { "PisarPiedra2", PisarPiedra2 }
            };

            StaticClass.InicializadaTablaFosiles = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
