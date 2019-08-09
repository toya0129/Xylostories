//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AnimationController : MonoBehaviour
//{

//    private int mainCharacter;

//    [SerializeField]
//    GameObject mainCamera;

//    #region Friend
//    public List<int> friendCharacter = new List<int>();
//    public List<GameObject> friend = new List<GameObject>();
//    private float[] firstPos = new float[] { 45f, -45f };
//    private float[] friendSpeed = new float[] { 2, 1, 3, 1, 1, 1, 1 };
//    [SerializeField]
//    GameObject friendPrefab;
//    [SerializeField]
//    GameObject friendField;
//    #endregion

//    [SerializeField]
//    RuntimeAnimatorController[] characterAnimation = new RuntimeAnimatorController[7];

//    [SerializeField]
//    Sprite[] characters = new Sprite[7];

//    [SerializeField]
//    Sprite[] background = new Sprite[7]; //0:1.61 1:3.1 
//    private float[] backgroundScale = new float[] { 1.61f, 3.1f ,3.1f,1.61f,1.61f, 1.61f, 1.61f, 1.61f};

//    [SerializeField]
//    GameObject hero;
//    [SerializeField]
//    GameObject backgroundField;

//    [SerializeField]
//    GameControllerScript gameControllerScript;

//    #region Animation 
//    private float roteY = 0.0f;
//    private float roteZ = 0.0f;
//    private bool trunFlagY = true;
//    private bool trunFlagZ = true;
//    private int moveCount = 0;
//    private int shakeCount = 0;
//    #endregion

//    #region Bear 1
//    private int bearMoveEnd = 400; //Animation End Flag
//    private int bearShakeEnd = 480;
    
//    private float[] friendEndPos = new float[] {18f,-18f,9f,-9f,27f,-27f,22f};
//    #endregion

//    #region Rabbit 2
//    private int rabbitMoveEnd = 350; //Animation End Flag
//    [SerializeField]
//    Sprite rabbit_back;
//    #endregion

//    #region Tiger 3
//    [SerializeField]
//    GameObject tape;
//    private float[] friendRunPosX = new float[] { 2.5f, -5f, 5f, -3.5f };
//    private float friendRunPosY = 30f;
//    #endregion

//    #region Fox 4
//    private int foxShakeEnd = 240; // Animation End Flag
//    private float ropeRoteZ;
//    [SerializeField]
//    GameObject moon;
//    [SerializeField]
//    GameObject rope;
//    #endregion

//    #region Pig 5

//    #endregion

//    #region Giraffe 6
//    [SerializeField]
//    GameObject stem;
//    [SerializeField]
//    GameObject leaf;
//    [SerializeField]
//    Sprite leaf_half;
//    private bool trunLeafFrag = true;
//    private int fallCount = 6;
//    private bool eatTrigger = true;
//    private int eatCount = 4;
//    #endregion

//    #region Monkey 7
//    [SerializeField]
//    GameObject trainField;
//    [SerializeField]
//    List<GameObject> train;
//    private bool trainMoveTrigger = true;
//    private float[] characterX = new float[]{-17f,-10f,-4f,2.3f,8.7f,15f,21.5f,28f};
//    private float characterY = -8;
//    #endregion


//    // Use this for initialization
//    void Start()
//    {
//        moon.SetActive(false);
//        stem.SetActive(false);
//        leaf.SetActive(false);
//        tape.SetActive(false);
//        trainField.SetActive(false);
//        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();

//        mainCharacter = 0;
////        mainCharacter = gameControllerScript.MainCharacter;

//        CharacterSet();
//        FriendCreate();

//        switch (mainCharacter)
//        {
//            case 1:
//                Debug.Log("Bear Animation Start");
//                StartCoroutine(BearAnimation());
//                break;
//            case 2:
//                Debug.Log("Rabbit Animation Start");
//                StartCoroutine(RabbitAnimation());
//                break;
//            case 3:
//                Debug.Log("Tiger Animation Start");
//                StartCoroutine(TigerAnimation());
//                break;
//            case 4:
//                Debug.Log("Fox Animation Start");
//                StartCoroutine(FoxAnimation());
//                break;
//            case 5:
//                Debug.Log("Pig Animation Start");
//                StartCoroutine(PigAnimation());
//                break;
//            case 6:
//                Debug.Log("Giraffe Animation Start");
//                StartCoroutine(GiraffeAnimation());
//                break;
//            case 7:
//                Debug.Log("Monkey Animation Start");
//                StartCoroutine(MonkeyAnimation());
//                break;
//            case 8:
//                Debug.Log("Small Bear Animation Start");
//                hero.transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
//                StartCoroutine(BearAnimation());
//                break;
//            default:
//                break;
//        }

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void CharacterSet()
//    {
//        hero.GetComponent<SpriteRenderer>().sprite = characters[mainCharacter - 1];
//        hero.GetComponent<Animator>().runtimeAnimatorController = characterAnimation[mainCharacter - 1];
//        backgroundField.GetComponent<SpriteRenderer>().sprite = background[mainCharacter - 1];
//        backgroundField.transform.localScale = new Vector3(backgroundScale[mainCharacter - 1], backgroundScale[mainCharacter - 1], 1);
//    }

//    private void FriendCreate(){
//        for (int i = 0; i < gameControllerScript.FriendsCharacter.Length; i++)
//        {
//            if (gameControllerScript.FriendsCharacter[i] == true)
//            {
//                friendCharacter.Add(i);
//            }
//        }

//        for (int i = 0; i < friendCharacter.Count;i++){
//            friend.Add(Instantiate(friendPrefab));
//            friend[i].GetComponent<SpriteRenderer>().sprite = characters[friendCharacter[i]];
//            friend[i].GetComponent<Animator>().runtimeAnimatorController = characterAnimation[friendCharacter[i]];
//            friend[i].transform.parent = friendField.transform;
//            if (i % 2 == 0)
//            {
//                friend[i].transform.localPosition = new Vector3(firstPos[0], -17, 0);
//            }
//            else
//            {
//                friend[i].transform.localPosition = new Vector3(firstPos[1], -17, 0);
//            }
//            friend[i].SetActive(false);
//        }
//    }

//    #region Common Character Animation
//    IEnumerator CharacterMove(int endCount) // Move a Characters Left and Right
//    {
//        if (trunFlagY == true)
//        {
//            if (hero.transform.localPosition.x > -20)
//            {
//                hero.transform.localPosition -= new Vector3(0.3f, 0, 0);
//            }
//            else
//            {
//                yield return StartCoroutine(TrunCharactar());
//                trunFlagY = false;
//            }
//        }
//        else if (trunFlagY == false)
//        {
//            if (hero.transform.localPosition.x < 20)
//            {
//                hero.transform.localPosition += new Vector3(0.3f, 0, 0);
//            }
//            else
//            {
//                yield return StartCoroutine(TrunCharactar());
//                trunFlagY = true;
//            }
//        }
//        yield return new WaitForSeconds(0.005f);

//        moveCount++;

//        if (endCount < moveCount)
//        {
//            yield break;
//        }

//        yield return StartCoroutine(CharacterMove(endCount));
//        yield break;
//    }

//    IEnumerator TrunCharactar() // Trun a Characters (y)
//    {
//        if (trunFlagY == true)
//        {
//            if (roteY < 180)
//            {
//                hero.transform.localRotation = Quaternion.Euler(0, roteY, roteZ);
//                roteY += 5.0f;
//            }
//            else
//            {
//                yield break;
//            }
//        }
//        else if (trunFlagY == false)
//        {
//            if (roteY > 0)
//            {
//                hero.transform.localRotation = Quaternion.Euler(0, roteY, roteZ);
//                roteY -= 5.0f;
//            }
//            else
//            {
//                yield break;
//            }
//        }
//        yield return new WaitForSeconds(0.005f);
//        yield return StartCoroutine(TrunCharactar());
//        yield break;
//    }

//    IEnumerator ShakeCharacter(int endCount){
//        if (trunFlagZ == true)
//        {
//            if (roteZ < 13)
//            {
//                hero.transform.localRotation = Quaternion.Euler(0, roteY, roteZ);
//                roteZ += 0.5f;
//            }
//            else
//            {
//                trunFlagZ = false;
//            }
//        }
//        else if (trunFlagZ == false)
//        {
//            if (roteZ > -13)
//            {
//                hero.transform.localRotation = Quaternion.Euler(0, roteY, roteZ);
//                roteZ -= 0.5f;
//            }
//            else
//            {
//                trunFlagZ = true;
//            }
//        }
//        shakeCount++;
//        if(endCount < shakeCount){
//            yield break;
//        }
//        yield return new WaitForSeconds(0.005f);
//        yield return StartCoroutine(ShakeCharacter(endCount));
//        yield break;
//    }
//    #endregion

//    #region Bear Animation (Friend Find)
//    IEnumerator BearAnimation()
//    {
//        StartCoroutine(ShakeCharacter(bearShakeEnd));
//        yield return StartCoroutine(CharacterMove(bearMoveEnd));
//        for (int i = 0; i < friend.Count; i++)
//        {
//            friend[i].SetActive(true);
//            yield return StartCoroutine(ComeFriend(i));
//        }
//        StopAllCoroutines();
//        Debug.Log("Bear Animation End");
//        gameControllerScript.OnLoadStudy();
//        yield break;
//    }

//    IEnumerator ComeFriend(int number)
//    {
//        if (number % 2 == 0)
//        {
//            if (friend[number].transform.localPosition.x > friendEndPos[number])
//            {
//                friend[number].transform.localPosition -= new Vector3(friendSpeed[number], 0, 0);
//            }
//            else
//            {
//                yield break;
//            }
//        }
//        else
//        {
//            if (friend[number].transform.localPosition.x < friendEndPos[number])
//            {
//                friend[number].transform.localPosition += new Vector3(friendSpeed[number], 0, 0);
//            }
//            else
//            {
//                yield break;
//            }
//        }
//        yield return new WaitForSeconds(0.1f);
//        yield return StartCoroutine(ComeFriend(number));
//        yield break;
//    }

//    #endregion

//    #region RabbitAnimation (Go Back Home)
//    IEnumerator RabbitAnimation()
//    {
//        hero.transform.localPosition = new Vector3(25.0f, -17.0f, 0);
//        yield return StartCoroutine(CharacterMove(rabbitMoveEnd));
//        yield return new WaitForSeconds(1.0f); // delay
//        yield return StartCoroutine(TrunCharactar());
//        hero.GetComponent<Animator>().enabled = false;
//        hero.GetComponent<SpriteRenderer>().sprite = rabbit_back;
//        yield return StartCoroutine(GoBackHome());
//        StopAllCoroutines();
//        Debug.Log("Rabbit Animation End");
//        gameControllerScript.OnLoadStudy();
//        yield break;
//    }

//    IEnumerator GoBackHome()
//    {
//        if (hero.transform.localScale.x > 1)
//        {
//            hero.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
//            hero.transform.localPosition += new Vector3(0.0f, 0.5f, 0.0f);
//        }
//        else
//        {
//            hero.SetActive(false);
//            yield break;
//        }
//        yield return new WaitForSeconds(0.1f);
//        yield return StartCoroutine(GoBackHome());
//        yield break;
//    }
//    #endregion

//    #region TigerAnimation (Running)
//    IEnumerator TigerAnimation(){
//        tape.SetActive(true);
//        hero.transform.localPosition = new Vector3(-3.5f, 12.0f, 0);
//        hero.transform.localScale= new Vector3(1.0f, 1.0f, 1.0f);
//        for (int i = 0; i < friend.Count; i++)
//        {
//            friend[i].SetActive(true);
//            friend[i].transform.localPosition = new Vector3(friendRunPosX[i % 4], friendRunPosY, 0);
//            friend[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
//            StartCoroutine(RunningFriend(i));
//        }
//        yield return StartCoroutine(RunningAnimation());
//        StopAllCoroutines();
//        Debug.Log("End Tiger Animation");
//        gameControllerScript.OnLoadStudy();
//        yield break;
//    }

//    IEnumerator RunningAnimation()
//    {
//        if (hero.transform.localPosition.y > -30.0f)
//        {
//            hero.transform.localScale += new Vector3(0.05f, 0.05f, 0);
//            hero.transform.localPosition -= new Vector3(0.02f, 0.4f, 0.0f);
//        }
//        else
//        {
//            yield break;
//        }
//        yield return new WaitForSeconds(0.1f);
//        yield return StartCoroutine(RunningAnimation());
//        yield break;
//    }

//    IEnumerator RunningFriend(int number)
//    {
//        switch (number % 4)
//        {
//            case 0:
//                friend[number].transform.localScale += new Vector3(0.005f, 0.005f, 0);
//                friend[number].transform.localPosition -= new Vector3(0.003f, 0.2f, 0.0f);
//                break;
//            case 1:
//                friend[number].transform.localScale += new Vector3(0.02f, 0.02f, 0);
//                friend[number].transform.localPosition -= new Vector3(0.1f, 0.3f, 0.0f);
//                break;
//            case 2:
//                friend[number].transform.localScale += new Vector3(0.025f, 0.025f, 0);
//                friend[number].transform.localPosition -= new Vector3(-0.1f, 0.4f, 0.0f);
//                break;
//            case 3:
//                friend[number].transform.localScale += new Vector3(0.015f, 0.015f, 0);
//                friend[number].transform.localPosition -= new Vector3(0.003f, 0.25f, 0.0f);
//                break;
//        }
//        yield return new WaitForSeconds(0.1f);
//        yield return StartCoroutine(RunningFriend(number));
//        yield break;
//    }
//    #endregion

//    #region FoxAnimation (Get Moon)
//    IEnumerator FoxAnimation(){
//        moon.SetActive(true);
//        rope.SetActive(true);
//        backgroundField.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);
//        hero.transform.localPosition = new Vector3(25.0f, -17.0f, 0);
//        ropeRoteZ = rope.transform.localEulerAngles.z;
//        yield return StartCoroutine(ShakeCharacter(foxShakeEnd));
//        yield return StartCoroutine(ThrowRope());
//        rope.transform.SetParent(moon.transform);
//        yield return StartCoroutine(GetMoon());
//        StopAllCoroutines();
//        Debug.Log("End Fox Animation");
//        gameControllerScript.OnLoadStudy();
//        yield break;
//    }

//    IEnumerator ThrowRope(){
//        if (rope.transform.localPosition.x > 13.0f)
//        {
//            rope.transform.localPosition -= new Vector3(0.9f, 0, 0);
//            rope.transform.localPosition += new Vector3(0, 0.2f, 0);
//            rope.transform.localRotation = Quaternion.Euler(0, 0, ropeRoteZ);
//            ropeRoteZ -= 0.3f; 
//        }
//        else
//        {
//            yield break;
//        }
//        yield return new WaitForSeconds(0.1f);
//        yield return StartCoroutine(ThrowRope());
//        yield break;
//    }

//    IEnumerator GetMoon(){
//        if(moon.transform.localPosition.x < hero.transform.localPosition.x){
//            if (trunFlagZ == true)
//            {
//                if (roteZ < 13)
//                {
//                    hero.transform.localRotation = Quaternion.Euler(0, 0, roteZ);
//                    roteZ += 1.0f;
//                }
//                else
//                {
//                    trunFlagZ = false;
//                }
//            }
//            else if (trunFlagZ == false)
//            {
//                if (roteZ > -13)
//                {
//                    hero.transform.localRotation = Quaternion.Euler(0, 0, roteZ);
//                    roteZ -= 1.0f;
//                }
//                else
//                {
//                    moon.transform.localPosition += new Vector3(2.0f, 0, 0);
//                    moon.transform.localPosition -= new Vector3(0, 0.7f, 0);
//                    trunFlagZ = true;
//                }
//            }
//        }else{
//            hero.transform.localRotation = Quaternion.Euler(0, 0, 0);
//            rope.SetActive(false);
//            if (hero.transform.localPosition.x > 0)
//            {
//                hero.transform.localPosition -= new Vector3(0.5f, 0, 0);
//                moon.transform.localPosition -= new Vector3(0.5f, 0, 0);
//            }
//            else
//            {
//                yield break;
//            }
//        }
//        yield return new WaitForSeconds(0.01f);
//        yield return StartCoroutine(GetMoon());
//        yield break;
//    }
//    #endregion


//    #region PigAnimation (Candy House)
//    IEnumerator PigAnimation(){

//        StopAllCoroutines();
//        Debug.Log("End Pig Animation");
//        gameControllerScript.OnLoadStudy();
//        yield break;
//    }
//    #endregion

//    #region GiraffeAnimation (Eat Reef)
//    IEnumerator GiraffeAnimation(){
//        stem.SetActive(true);
//        leaf.SetActive(true);
//        int count = 0;
//        yield return StartCoroutine(FallLeaf());
//        yield return StartCoroutine(EatLeaf(count));
//        StopAllCoroutines();
//        Debug.Log("End Giraffe Animation");
//        gameControllerScript.OnLoadStudy();
//        yield break;
//    }

//    IEnumerator FallLeaf(){
//        if(trunLeafFrag == true){
//            if(leaf.transform.localPosition.x > 0){
//                leaf.transform.localPosition -= new Vector3(0.8f, 0, 0);
//            }
//            else{
//                trunLeafFrag = false;
//                fallCount--;
//            }
//        }else{
//            if (leaf.transform.localPosition.x < 15)
//            {
//                leaf.transform.localPosition += new Vector3(0.8f, 0, 0);
//            }
//            else
//            {
//                trunLeafFrag = true;
//                fallCount--;
//            }
//        }
//        leaf.transform.localPosition -= new Vector3(0, 0.2f, 0);
//        if(fallCount < 0){
//            yield break;
//        }

//        yield return new WaitForSeconds(0.1f);
//        yield return StartCoroutine(FallLeaf());
//        yield break;
//    }

//    IEnumerator EatLeaf(int count)
//    {
//        if (eatTrigger == true)
//        {
//            if (hero.transform.localScale.x < 5)
//            {
//                hero.transform.localScale += new Vector3(0.3f, 0.1f, 0);
//            }
//            else
//            {
//                eatTrigger = false;
//            }
//        }
//        else
//        {
//            if (hero.transform.localScale.x > 4)
//            {
//                hero.transform.localScale -= new Vector3(0.3f, 0.1f, 0);
//            }
//            else
//            {
//                eatTrigger = true;
//                count++;
//            }
//        }

//        if (eatCount < count)
//        {
//            leaf.SetActive(false);
//            yield break;
//        }
//        else if (eatCount / 2 == count){
//            leaf.GetComponent<SpriteRenderer>().sprite = leaf_half;
//        }

//        yield return new WaitForSeconds(0.1f);
//        yield return StartCoroutine(EatLeaf(count));
//        yield break;
//    }


//    #endregion

//    #region MonkeyAnimation (Train)
//    IEnumerator MonkeyAnimation()
//    {
//        trainField.SetActive(true);
//        hero.transform.localScale = new Vector3(2, 2, 1);
//        hero.transform.localPosition = new Vector3(characterX[mainCharacter - 1], characterY, 0);
//        hero.transform.parent = train[mainCharacter - 1].transform;

//        for (int i = 0; i < friend.Count;i++){
//            friend[i].SetActive(true);
//            if (friendCharacter[i] == 7)
//            {
//                friend[i].transform.localScale = new Vector3(1, 1, 1);
//                friend[i].transform.localPosition = new Vector3(characterX[friendCharacter[i]], characterY + 2, 0);
//            }
//            else
//            {
//                friend[i].transform.localScale = new Vector3(2, 2, 1);
//                friend[i].transform.localPosition = new Vector3(characterX[friendCharacter[i]], characterY, 0);
//            }
//            friend[i].transform.parent = train[friendCharacter[i]].transform;
//        }
        
//        StartCoroutine(TrainMove());
//        yield return new WaitForSeconds(2f);
//        yield return StartCoroutine(CameraMove());
//        StopAllCoroutines();
//        Debug.Log("End Monkey Animation");
//        gameControllerScript.OnLoadStudy();
//        yield break;
//    }

//    IEnumerator TrainMove()
//    {
//        if (trainMoveTrigger == true)
//        {
//            for (int j = 0; j < train.Count; j++)
//            {
//                if (j % 2 == 0)
//                {
//                    train[j].transform.localPosition = new Vector3(0, 1.0f, 0);
//                }
//                else
//                {
//                    train[j].transform.localPosition = new Vector3(0, 0, 0);
//                }
//            }
//            trainMoveTrigger = false;
//        }
//        else
//        {
//            for (int j = 0; j < train.Count; j++)
//            {
//                if (j % 2 == 0)
//                {
//                    train[j].transform.localPosition = new Vector3(0, 0, 0);
//                }
//                else
//                {
//                    train[j].transform.localPosition = new Vector3(0, 1.0f, 0);
//                }
//            }
//            trainMoveTrigger = true;
//        }
//        yield return new WaitForSeconds(0.3f);
//        yield return StartCoroutine(TrainMove());
//        yield break;
//    }

//    IEnumerator CameraMove()
//    {
//        if (mainCamera.transform.localPosition.z < -15f)
//        {
//            mainCamera.transform.localPosition += new Vector3(0, 0, 1.0f);
//            mainCamera.transform.localPosition -= new Vector3(1.0f, 0.15f, 0);
//        }
//        else
//        {
//            if (mainCamera.transform.localPosition.x < 15f)
//            {
//                mainCamera.transform.localPosition += new Vector3(0.5f, 0, 0);
//            }
//            else
//            {
//                yield break;
//            }
//        }
//        yield return new WaitForSeconds(0.1f);
//        yield return StartCoroutine(CameraMove());
//        yield break;
//    }
//    #endregion
//}