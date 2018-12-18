using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour {

    public Color fosilConceguido;
    public Color fosilNOConceguido;

    Text misionText;

    Text fosilMision1;
    Text fosilMision2;
    Text fosilMision3;
    Text fosilMision4;
    Text fosilMision5;
    Text fosilMision6;

    public GameObject panelMisionBuzoCompletada;

    // Use this for initialization
    void Start () {
        misionText = GameObject.Find("TextMission").GetComponent<Text>();
        fosilMision1 = GameObject.Find("FosilMission1").GetComponent<Text>();
        fosilMision2 = GameObject.Find("FosilMission2").GetComponent<Text>();
        fosilMision3 = GameObject.Find("FosilMission3").GetComponent<Text>();
        fosilMision4 = GameObject.Find("FosilMission4").GetComponent<Text>();
        fosilMision5 = GameObject.Find("FosilMission5").GetComponent<Text>();
        fosilMision6 = GameObject.Find("FosilMission6").GetComponent<Text>();
        ActualizarMision();
        ActualizamosColores();
        DelegateHandler.delegateHandler.fosilBienClasificadoYDeMision += FosilDeMision;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActualizarMision() {
        if (StaticClass.MisionActual == 1 || StaticClass.MisionActual == 2)
        {
            TextAsset text;
            if (StaticClass.MisionActual == 1) text = (TextAsset)Resources.Load("Mision_1", typeof(TextAsset));
            else text = (TextAsset)Resources.Load("Mision_2", typeof(TextAsset));

            string[] lineas = text.text.Split("\n"[0]);
            misionText.text = "";
            for (int i = 0; i < lineas.Length; i++)
            {
                misionText.text += ("\n" + lineas[i]);
            }

            fosilMision1.text = StaticClass.FosilesDeLaMision[0];
            fosilMision2.text = StaticClass.FosilesDeLaMision[1];
            fosilMision3.text = StaticClass.FosilesDeLaMision[2];
            fosilMision4.text = StaticClass.FosilesDeLaMision[3];
            fosilMision5.text = StaticClass.FosilesDeLaMision[4];
            fosilMision6.text = StaticClass.FosilesDeLaMision[5];
        }
        else if (StaticClass.MisionActual == 3) {
            TextAsset text = (TextAsset)Resources.Load("Mision_3", typeof(TextAsset));

            string[] lineas = text.text.Split("\n"[0]);
            misionText.text = "";
            for (int i = 0; i < lineas.Length; i++)
            {
                misionText.text += ("\n" + lineas[i]);
            }

            fosilMision1.text = StaticClass.FosilesDeLaMision[0];
            fosilMision2.text = StaticClass.FosilesDeLaMision[1];
            fosilMision3.text = StaticClass.FosilesDeLaMision[2];
            fosilMision4.text = StaticClass.FosilesDeLaMision[3];
            fosilMision5.text = StaticClass.FosilesDeLaMision[4];

            fosilMision6.gameObject.SetActive(false);
        }
    }

    public void ActualizamosColores()
    {
        Transform obj = GameObject.Find("Objectives").transform;
        
        for (int i = 0; i < obj.childCount; i++) {
            if (StaticClass.FosilEnCaja.ContainsKey(obj.GetChild(i).GetComponent<Text>().text))
                obj.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = fosilConceguido;
            else
                obj.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = fosilNOConceguido;
        }
    }

    public void ComprobarCambioMision()
    {
        if (StaticClass.MisionActual == 1)
        {
            if (StaticClass.ContadorObjetivosConseguidos == 6)
            {
                DelegateHandler.delegateHandler.CallAudioMisionCompletada();
                StartCoroutine(MisionBuzoCompletada());
                StaticClass.ContadorObjetivosConseguidos = 0;
                StaticClass.MisionActual ++;
                StaticClass.TieneTrajeDeBuzo = true;

                StaticClass.FosilesDeLaMision.Clear();
                StaticClass.FosilesDeLaMision.Add("Erosaria_Spurca");
                StaticClass.FosilesDeLaMision.Add("Stramonita_haemastoma");
                StaticClass.FosilesDeLaMision.Add("Venus_verrucosa");
                StaticClass.FosilesDeLaMision.Add("Patella_Candei");
                StaticClass.FosilesDeLaMision.Add("Persististrombus_latus");
                StaticClass.FosilesDeLaMision.Add("Certium_vulgatum");

                ActualizarMision();
                ActualizamosColores();
            }
        }
        else if (StaticClass.MisionActual == 2)
        {
            Debug.Log(StaticClass.ContadorObjetivosConseguidos);
            if (StaticClass.ContadorObjetivosConseguidos == 6)
            {
                DelegateHandler.delegateHandler.CallAudioMisionCompletada();
                DelegateHandler.delegateHandler.CallZapatillasConseguidas();
                StaticClass.ContadorObjetivosConseguidos = 0;
                StaticClass.MisionActual++;

                StaticClass.FosilesDeLaMision.Clear();
                StaticClass.FosilesDeLaMision.Add("Mitra_Zonata_Marryat");
                StaticClass.FosilesDeLaMision.Add("Saccostrea_Cuccullata");
                StaticClass.FosilesDeLaMision.Add("Tetraclita");
                StaticClass.FosilesDeLaMision.Add("Vermetus_Adansonii");
                StaticClass.FosilesDeLaMision.Add("Pecten_Jacobaeus");

                ActualizarMision();
                ActualizamosColores();
            }
        }
        else if (StaticClass.MisionActual == 3)
        {
            if (StaticClass.ContadorObjetivosConseguidos == 5)
            {
                // SE TERMINA EL JUEGO !!
                DelegateHandler.delegateHandler.CallAudioMisionCompletada();
                StaticClass.ContadorObjetivosConseguidos = 0;
                StaticClass.MisionActual++;
                StaticClass.FosilesDeLaMision.Clear();

                TextAsset text = (TextAsset)Resources.Load("FinMisiones", typeof(TextAsset));

                string[] lineas = text.text.Split("\n"[0]);
                misionText.text = "";
                for (int i = 0; i < lineas.Length; i++)
                {
                    misionText.text += ("\n" + lineas[i]);
                }

                fosilMision1.gameObject.SetActive(false);
                fosilMision2.gameObject.SetActive(false);
                fosilMision3.gameObject.SetActive(false);
                fosilMision4.gameObject.SetActive(false);
                fosilMision5.gameObject.SetActive(false);
                fosilMision6.gameObject.SetActive(false);
                Debug.Log("FIN DEL JUEGO !!");
            }
        }
    }

    public bool FosilDeMision (string fosil) {
        if (StaticClass.FosilesDeLaMision.Contains(fosil)) {
            Transform objetivos = GameObject.Find("Objectives").transform;
            for (int i = 0; i < objetivos.childCount; i++) {
                if (objetivos.GetChild(i).GetComponent<Text>().text == fosil)
                    objetivos.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = fosilConceguido;
            }
            StaticClass.ContadorObjetivosConseguidos++;
            ComprobarCambioMision();
            return true;
        }
        return false;
    }

    IEnumerator MisionBuzoCompletada()
    {
        panelMisionBuzoCompletada.SetActive(true);
        yield return new WaitForSeconds(5);
        panelMisionBuzoCompletada.SetActive(false);
    }

    private void OnDisable()
    {
        DelegateHandler.delegateHandler.fosilBienClasificadoYDeMision -= FosilDeMision;
    }
}
