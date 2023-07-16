
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pod : MonoBehaviour
{
    public enum PodState
    {
        ROTATION, // ban đầu
        SHOOT, // nhấn xuống
        REMIND, // kéo lên
    }

    #region Serialize
    [SerializeField]
    private float _rotateSpeed = 1;
    [SerializeField]
    private float _speed = 10;
    #endregion

    PodState podState = PodState.ROTATION;

    private float _angle;

    private float _slowDown;

    private Vector3 _Origin;

    public static Transform _rod;

    private bool _flagrod;

    private int[] _gift;

    public static int randomNum;

    public static int numplay = num.k;

    private int voucher;

    private int image;

    public static string strVoucher;

    public static string strImage;

    public static string nameObj;



    UIManager m_ui;

    


    void OnTriggerEnter2D(Collider2D col)
    {
        if(_flagrod) return;
        _flagrod = true;
        _rod = col.transform;
        _rod.SetParent(transform);
        _slowDown = _rod.GetComponent<rod>().slowDown;
        _gift = _rod.GetComponent<rod>().gift;
        randomNum = _gift[Random.Range(0, _gift.Length - 1)];

        podState = PodState.REMIND;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        m_ui = FindObjectOfType<UIManager> ();
        m_ui.SetNumPlay(numplay + " lượt");
    }

    void Awake()
    {
        _Origin = transform.position; // vi tri ban dau
    }

    // Update is called once per frame
    void Update()
    {
        num.delete();
        switch (podState)
        {
            case PodState.ROTATION:
                transform.position = _Origin;
                if(Input.GetKeyDown(KeyCode.Space))
                    if(numplay > 0)
                    {
                        numplay --;
                        m_ui.SetNumPlay(numplay + " lượt");
                        podState = PodState.SHOOT;// nhấn space chuyển qua shoot
                    }
                    else
                    {
                        SceneManager.LoadScene("input");
                    }

                
                _angle += _rotateSpeed; //tăng góc quay

                if(_angle>70||_angle<-70)// góc quay từ -80 đến 80
                    _rotateSpeed *= -1;// đổi chiều
                
                transform.rotation = Quaternion.AngleAxis(_angle,Vector3.forward);

                break;
            case PodState.SHOOT:
                transform.Translate(Vector3.down * _speed * Time.deltaTime);

                //đi ngược  lại nếu chạm giới hạn
                if(Mathf.Abs(transform.position.x) > 10 || transform.position.y < -7)
                    podState = PodState.REMIND;

                break;
            case PodState.REMIND:
                transform.Translate(Vector3.up * (_speed - _slowDown) * Time.deltaTime);// di len
                
                if(Mathf.Floor(transform.position.x) == _Origin.x || Mathf.Floor(transform.position.y) == _Origin.y)
                {
                    if (_rod != null)
                    {
                        _flagrod = false;
                        _slowDown = 0;
                        num.objectList.Add(_rod.gameObject.name);
                        SceneManager.LoadScene("con Scene");
                        if (randomNum > 10 && randomNum < 14)
                        {
                            randomNum = randomNum - 10;
                            numplay = numplay + randomNum;
                            m_ui.SetNumPlay(numplay + " Lượt");
                            randomNum = randomNum + 10;
                        }

                        if (randomNum > 0 && randomNum < 10)
                        {
                            image = randomNum;
                            strImage = strImage + "\n" + "hình " + image ;
                            playername.database.Add("hình " + image);
                        }

                         if (randomNum > 20 && randomNum < 28)
                        {
                            randomNum = randomNum - 20;
                            voucher = randomNum;
                            strVoucher = strVoucher + "\n" + "Voucher  " + voucher + "0%" ;
                            randomNum = randomNum + 20;
                            playername.database.Add("Voucher  " + voucher + "0%");
                        }


                                

                    }
                    
                    podState = PodState.ROTATION;
                }    
                break;
        }

        num.NUM();
        
    }

}
