using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoginController : MonoBehaviour {

    private const string Login = "Aljoker";
    private const string Pass = "123";

    [SerializeField]
    private InputField usuario = null;
    [SerializeField]
    private InputField senha = null;
    [SerializeField]
    private Text FeedBackMsg = null;
    [SerializeField]
    private Toggle LembrarDados = null;

    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
