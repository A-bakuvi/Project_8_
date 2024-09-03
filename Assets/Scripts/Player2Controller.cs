using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    // rotate the player use rigidbody
    // move player use rigidbody
    // make player spawn point
    // dont end game unless both players die
    // copy same code to other player but use wasd
    // check if theyre touching the exit point then move to next level
    // make each level wider and more enemy spawn points
    // make enemys move randomly
    // if player touches enemy die
    // make bullets shoot and disappear after 3 seconds
    // if touching shield logo destroy bullet
    // fix mbullet
    // fix shield


    Rigidbody2D _rb;

    float _moveVertical;
    float _moveHorizontal;
    float _moveSpeed = 10f;


    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _bullet1;
    [SerializeField] GameObject _bullet2;
    [SerializeField] GameObject _bullet3;
    [SerializeField] GameObject _bulletSpawner;
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _shield;
    [SerializeField] GameObject _bouncing;
    [SerializeField] GameObject _mBullet;
    [SerializeField] GameObject _shieldBig;

    float _bulletSpeed = 15f;
    float _bulletSpeed1 = 15f;

    public int number1 = 0;

    bool _isShooting = false;
    bool _isMbullet = false;
    bool _isShield = false;
    bool _isBouncing = false;
    bool canShoot = true;
    //bool _isBullet2 = false;

    GameManager _gameManager;
    Vector2 _offset;
    //int _damage = 33;
    //int _damageMinus = -33;

    Coroutine _coroutine;
    Coroutine _coroutine1;

    float _screenX;
    float _screenY;
    Vector2 _pos;


    void Start()
    {
        _shield.SetActive(false);
        _isShield = false;
        _rb = GetComponent<Rigidbody2D>();
        _rb.rotation = 90f;
    }

    void Update()
    {
        Vector3 targetPosition = transform.position;
        _shield.transform.position = targetPosition;

        _moveVertical = Input.GetAxisRaw("Vertical");
        //_shield.transform.position = gameObject.transform.position;
        //_coroutine = StartCoroutine(Fire1());

        if (Input.GetKey(KeyCode.W))
        {
            _rb.velocity = -transform.up * _moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {

            if (_isMbullet == true)
            {
                if (canShoot)
                {
                    //ShootAtPlayer();
                    _coroutine = StartCoroutine(Fire1());
                    StartCoroutine(StopFire1());
                    if (_isBouncing == true)
                    {
                        _isBouncing = false;
                        _bouncing.SetActive(true);
                    }
                    if (_isShield == true)
                    {
                        _isShield = false;
                        _shieldBig.SetActive(true);
                    }
                }
            }
            else if (_isBouncing == true)
            {
                _coroutine1 = StartCoroutine(Shoot());
                StartCoroutine(StopFire2());
                if (_isMbullet == true)
                {
                    _isMbullet = false;
                    _mBullet.SetActive(true);
                }
                if (_isShield == true)
                {
                    _isShield = false;
                    _shieldBig.SetActive(true);
                }
            }
            else if (_isShield == true)
            {
                _isShooting = true;
                if (_isMbullet == true)
                {
                    _isMbullet = false;
                    _mBullet.SetActive(true);
                }
                if (_isBouncing == true)
                {
                    _isBouncing = false;
                    _bouncing.SetActive(true);
                }
            }
            else
            {
                _isShooting = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _rb.rotation += -5f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rb.rotation += 5f;
        }
        if (_isShooting)
        {
            StartCoroutine(Fire());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _screenX = Random.Range(-30, 30);
        _screenY = Random.Range(-17, 17);
        _pos = new Vector2(_screenX, _screenY);

        /*if (collision.gameObject.tag == "Wall")
        {
            StartCoroutine(DontRotate());
        }*/
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mbullets")
        {
            if (!_isBouncing && !_isShield && !_isMbullet)
            {
                _isMbullet = true;
                collision.gameObject.SetActive(false);
                number1 -= 1;
            }


            /*for(int i = 5; i > 0; i--)
            {
                ShootAtPlayer();
            }*/
            //StartCoroutine(Fire1());
        }
        if (collision.gameObject.tag == "Shield")
        {
            if (!_isBouncing && !_isShield && !_isMbullet)
            {
                _isShield = true;
                collision.gameObject.SetActive(false);
                StartCoroutine(Shield());
                number1 -= 1;

            }
            //StartCoroutine(Fire1());
        }
        /*if(collision.gameObject.tag == "Bullet2")
        {
            _isBullet2 = true;
            /*if (_isShield == true)
            {
                collision.gameObject.GetComponent<EnemyHealth>().DamageEnemy(_damageMinus);
                Destroy(collision.gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyHealth>().DamageEnemy(_damage);
                Destroy(_bullet2);
            }

        }*/

        if (collision.gameObject.tag == "Bouncing")
        {
            if (!_isBouncing && !_isShield && !_isMbullet)
            {
                _isBouncing = true;
                collision.gameObject.SetActive(false);
                number1 -= 1;
            }
        }
    }

    /*IEnumerator DontRotate()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(0.5f);
        _rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
    }*/


    IEnumerator Fire()
    {
        _isShooting = false; //because its safe now

        //_offset = new Vector2(_enemy.transform.position.x - transform.position.x, _enemy.transform.position.y - transform.position.y).normalized;

        GameObject bullet = Instantiate(_bullet, _bulletSpawner.transform.position, transform.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity = -transform.up * _bulletSpeed; // so its gonna go forward at the speed of _bulletSpeed;

        yield return new WaitForSeconds(3);

        Destroy(bullet);
    }

    IEnumerator Fire1()
    {
        canShoot = false;

        GameObject bullet1 = Instantiate(_bullet1, _bulletSpawner.transform.position, transform.rotation);

        bullet1.GetComponent<Rigidbody2D>().velocity = -transform.up * _bulletSpeed1; // so its gonna go forward at the speed of _bulletSpeed;

        yield return new WaitForSeconds(0.5f);

        canShoot = true;

        yield return new WaitForSeconds(3);

        Destroy(bullet1);



    }

    IEnumerator Fire2()
    {

        GameObject bullet3 = Instantiate(_bullet3, _bulletSpawner.transform.position, transform.rotation);

        bullet3.GetComponent<Rigidbody2D>().velocity = -transform.up * _bulletSpeed; // so its gonna go forward at the speed of _bulletSpeed;

        yield return new WaitForSeconds(3);

        Destroy(bullet3);


    }

    IEnumerator Shield()
    {

        _isShield = true;
        _shield.SetActive(true);
        yield return new WaitForSeconds(10);
        _shield.SetActive(false);
        _isShield = false;
    }

    IEnumerator StopFire1()
    {
        yield return new WaitForSeconds(10);
        StopCoroutine(_coroutine);
        _isMbullet = false;
        canShoot = true;
    }

    IEnumerator StopFire2()
    {
        yield return new WaitForSeconds(10);
        StopCoroutine(_coroutine1);
        _isBouncing = false;
    }

    IEnumerator Shoot()
    {
        StartCoroutine(Fire2());
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Fire2());
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Fire2());
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Fire2());
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Fire2());
    }


    // rotate the player use rigidbody
    // move player use rigidbody
    // make player spawn point
    // dont end game unless both players die
    // copy same code to other player but use wasd
    // check if theyre touching the exit point then move to next level
    // make each level wider and more enemy spawn points
    // make enemys move randomly
    // if player touches enemy die
    // make bullets shoot and disappear after 3 seconds


    /*Rigidbody2D _rb;
    float _moveVertical;
    float _moveHorizontal;
    float _moveSpeed = 10f;
    //int _damage99 = 99;

    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _bulletSpawner;
    [SerializeField] GameObject _enemy;
    float _bulletSpeed = 15f;
    bool _isShooting = false;
    GameManager _gameManager;
    Vector2 _offset;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.rotation = 270f;
    }

    void Update()
    {
        _moveVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            _rb.velocity = transform.up * _moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            _isShooting = true;
        }

    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.D))
        {
            _rb.rotation += -5f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rb.rotation += 5f;
        }
        if (_isShooting)
        {
            StartCoroutine(Fire());
           
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //_rb.rotation = 180f;
            StartCoroutine(DontRotate());
        }*/
    /*if (collision.gameObject.tag == "BigBullet")
    {
        collision.gameObject.GetComponent<Enemy2Health>().DamageEnemy3(_damage99);
    }*/
    /*
    IEnumerator Fire()
    {
        _isShooting = false; //because its safe now

        //_offset = new Vector2(_enemy.transform.position.x - transform.position.x, _enemy.transform.position.y - transform.position.y).normalized;

        GameObject bullet = Instantiate(_bullet, _bulletSpawner.transform.position, transform.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * _bulletSpeed; // so its gonna go forward at the speed of _bulletSpeed;

        yield return new WaitForSeconds(3);

        Destroy(bullet);
    }*/
}
