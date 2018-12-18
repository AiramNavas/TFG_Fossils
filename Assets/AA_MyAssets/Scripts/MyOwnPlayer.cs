using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MyOwnPlayer : MonoBehaviour {

    private FirstPersonController FPC;

    private GameObject fosil;
    
    private GameObject panelMision;
    private bool panelMisionesON = false;
    private bool wantMission = false;

    private GameObject panelFosil;
    private bool panelFosilON = false;
    private Text textoFosil;
    
    private GameObject Glosario;
    private GameObject targetGlosario;
    private bool panelGlosarioON = false;

    public GameObject pressA;
    public GameObject pressA0;
    public GameObject canvasPressACambio;
    private Camera camara;

    public GameObject canvasBreathBar;
    public Image breathBar;
    bool respirando = false;

    // Características del Jugador
    bool enElAgua = false;

    // Use this for initialization
    void Start () {
        FPC = GameObject.FindObjectOfType<FirstPersonController>();
        DelegateHandler.delegateHandler.jugadorEntraAlAgua += PlayerInWater;
        DelegateHandler.delegateHandler.jugadorSaleDelAgua += PlayerOutWater;
        DelegateHandler.delegateHandler.jugadorEntraAlAgua += ActiveBreathBar;
        DelegateHandler.delegateHandler.jugadorSaleDelAgua += ResetBreathBar;
        DelegateHandler.delegateHandler.zapatillasConseguidas += ZapatillasON;

        camara = GetComponent<Camera>();
        panelFosil = GameObject.Find("CanvasInfoFosil");
        Glosario = GameObject.Find("CanvasGlosario");
        targetGlosario = GameObject.Find("TargetGlosario");
        textoFosil = GameObject.Find("TextoFosil").GetComponent<Text>();
        panelMision = GameObject.Find("CanvasPanelMission");
        panelMision.transform.Translate(new Vector3(0, -1000, 0));
    }
	
	// Update is called once per frame
	void Update () {
        if (fosil != null && fosil.transform.GetChild(0).tag == "Fosiles")
        {
            if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("1"))
            {
                DesactivarPaneles();
                SetPanel(fosil.name);
            }
        }

        if (wantMission) {
            if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("1"))
            {
                if (!panelMisionesON)
                {
                    DesactivarPaneles();
                    SetMissionPanel();
                    DelegateHandler.delegateHandler.CallAudioAbrirLibro();
                }
            }
        }

        if (Input.GetKeyDown("joystick button 3") || Input.GetKeyDown("7"))
        {
            DesactivarPaneles();
            Glosario.transform.position = targetGlosario.transform.position;
            Glosario.transform.LookAt(camara.transform);
            panelGlosarioON = true; 
        }

        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("3"))
        {
            DesactivarPaneles();
        }

        if (Input.GetKey("joystick button 2") || Input.GetKey("2"))
        {
            if (!StaticClass.Zapatillas && !enElAgua)
                FPC.m_WalkSpeed = 10;
            else if (!StaticClass.Zapatillas && enElAgua)
            {
                FPC.m_WalkSpeed = 5;
            }
            else if (StaticClass.Zapatillas && enElAgua)
            {
                FPC.m_WalkSpeed = 10;
            }
            else {
                FPC.m_StepInterval = 10;
                FPC.m_WalkSpeed = 20;
            }
        }
        else {
            FPC.m_StepInterval = 5;
            FPC.m_WalkSpeed = 5;
        }

        if (respirando) {
            breathBar.fillAmount -= 1.0f / 20 * Time.deltaTime;
            if (breathBar.fillAmount <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void ZapatillasON() {
        StaticClass.Zapatillas = true;
    }

    private void DesactivarPaneles() {
        if (panelFosilON) panelFosil.transform.Translate(new Vector3(0, -1000, 0));
        if (panelGlosarioON) Glosario.transform.Translate(new Vector3(0, -1000, 0));
        panelFosilON = false;
        panelGlosarioON = false;
        if (panelMisionesON)
        {
            panelMision.transform.Translate(new Vector3(0, -1000, 0));
            panelMisionesON = false;
            DelegateHandler.delegateHandler.CallAudioCerrarLibro();
        }
    }

    public void TakeFosilName(GameObject f) {
        fosil = f;
    }

    public void TakeFosilNameObjetive(GameObject f)
    {
        fosil = GameObject.Find(f.GetComponent<Text>().text);
    }

    public void ResetFosilName() {
        fosil = null;
    }

    public void QuestBook() {
        if (DelegateHandler.delegateHandler.CallDentroDelAreaDelLibro())
        {
            wantMission = true;
            SetActivePressAInfoON();
        }
        else {
            wantMission = false;
        }
    }

    public void SetActivePressAInfoON() {
        if (StaticClass.Escena == 0)
            pressA0.SetActive(true);
        else
            pressA.SetActive(true);
    }

    public void SetActivePressACambio() {
        if(canvasPressACambio.activeSelf)
            canvasPressACambio.SetActive(false);
        else
            canvasPressACambio.SetActive(true);
    }

    public void SetActivePressAInfoOFF() {
        if (StaticClass.Escena == 0)
            pressA0.SetActive(false);
        else
            pressA.SetActive(false);
        wantMission = false;
    }

    void SetMissionPanel() {
        panelMision.transform.Translate(new Vector3(0, 1000, 0));
        panelMisionesON = true;
    }

    void PlayerInWater() {
        enElAgua = true;
        if (!StaticClass.TieneTrajeDeBuzo)
        {
            FPC.m_WalkSpeed = 3;
            FPC.m_GravityMultiplier = 1;
            FPC.m_RunSpeed = 3;
        }
        else {
            FPC.m_WalkSpeed = 4;
            FPC.m_GravityMultiplier = 2;
            FPC.m_RunSpeed = 6;
        }
        DelegateHandler.delegateHandler.CallMutearPiesBajoAgua(false);
    }

    void PlayerOutWater() {
        enElAgua = false;
        if (!StaticClass.Zapatillas)
        {
            FPC.m_WalkSpeed = 5;
            FPC.m_GravityMultiplier = 2;
            FPC.m_RunSpeed = 10;
        }
        else {
            FPC.m_WalkSpeed = 5;
            FPC.m_GravityMultiplier = 2;
            FPC.m_RunSpeed = 15;
        }
        DelegateHandler.delegateHandler.CallMutearPiesBajoAgua(true);
    }
    

    void SetPanel(string nombreFosil)
    {
        TextAsset text = (TextAsset)Resources.Load(nombreFosil, typeof(TextAsset));

        string[] lineas = text.text.Split("\n"[0]);
        GameObject.Find("NombreFosil").GetComponent<Text>().text = lineas[0];

        textoFosil.text = "";
        for (int i = 1; i < lineas.Length; i++)
        {
            textoFosil.text += ("\n" + lineas[i]);
        }
        
        if (StaticClass.Escena != 0)
        {
            panelFosil.transform.position = fosil.transform.position;
            panelFosil.transform.LookAt(camara.transform);
            panelFosil.transform.GetChild(0).LookAt(camara.transform);
        }
        else
        {
            panelFosil.transform.position = GameObject.Find("PanelFosilPosition").transform.position;
        }

        panelFosilON = true;
    }

    void ActiveBreathBar() {
        if (!StaticClass.TieneTrajeDeBuzo) {
            canvasBreathBar.SetActive(true);
            respirando = true;
        }
    }

    void ResetBreathBar() {
        respirando = false;
        breathBar.fillAmount = 1;
        canvasBreathBar.SetActive(false);
    }

    private void OnDisable()
    {
        DelegateHandler.delegateHandler.jugadorEntraAlAgua -= PlayerInWater;
        DelegateHandler.delegateHandler.jugadorSaleDelAgua -= PlayerOutWater;
        DelegateHandler.delegateHandler.jugadorEntraAlAgua -= ActiveBreathBar;
        DelegateHandler.delegateHandler.jugadorSaleDelAgua -= ResetBreathBar;
        DelegateHandler.delegateHandler.zapatillasConseguidas -= ZapatillasON;
    }
}
