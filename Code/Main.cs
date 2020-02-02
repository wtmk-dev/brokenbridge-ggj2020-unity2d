using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Main : MonoBehaviour
{
    [SerializeField]
    private List<State> states;
    private StateManager stateManager;
    private int main = 2;
    [SerializeField]
    private List<Level> levels;
    [SerializeField]
    private GameObject puzzlePrefab, playerPrefab, startScreenPrefab, 
    mainScreenPrefab, rewardScreenPrefab, soundManagerPrefab, endScreenPrefab;
    private List<PuzzleController> leftPuzzlePool,rightPuzzlePool,
    puzzlesInPlayPool, puzzlesToSpawnPool;
    private Dictionary<PuzzlePiece, PuzzleController> puzzleMap;

    [SerializeField]
    private List<PlayerModel> playerModels;
    private Dictionary<PlayerModel,PlayerController> players;
    private ScoreCard scorecard;

    private Level currentLevel;
    private Dictionary<State,IScreen> screens;

    [SerializeField]
    private AudioClip failedSount, wrongSount, correctSound,buttonSound;
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource winLoseAudio;

    //spawn test
    private Timer spawnTimer;
    private int totalSpawn;
    private int currentSpawn;
    private int spawnIndex;


    [SerializeField]
    private GameObject wallL,wallR,bridge,bridgeWall;

    void Awake()
    {
        screens           = new Dictionary<State, IScreen>();
        players           = new Dictionary<PlayerModel, PlayerController>();
        stateManager      = new StateManager(states);
        leftPuzzlePool    = new List<PuzzleController>();
        rightPuzzlePool   = new List<PuzzleController>();
        puzzlesInPlayPool = new List<PuzzleController>();
        puzzlesToSpawnPool= new List<PuzzleController>();
        puzzleMap         = new Dictionary<PuzzlePiece, PuzzleController>();

        
        stateManager.StateChange(states[0]);

        currentLevel = levels[0];

        BuildScreens();

        
        BuildLevel(currentLevel);
        BuildPlayers();

        RegisterActions();

        spawnTimer = new Timer();
        scorecard  = new ScoreCard();

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        totalSpawn = leftPuzzlePool.Count + rightPuzzlePool.Count;
        currentSpawn = 0;
        spawnIndex = 0;

        stateManager.StateChange(states[1]);
    }

    void Update()
    {
        if(stateManager == null)
        {
            return;
        }

        UpdateStates(stateManager.CurrentState);
    }

    private void HandleStates(State state)
    {
        Debug.Log("CURRENT STATE: " + state);
        
        switch(state.id)
        {
            case 2: // Main
            HandelMainState();
            break;
            case 3: // Reward
            HandelRewardState();
            break;
            case 4: // End
            HandelEndScreen();
            break;
        }
    }

    private void UpdateStates(State state)
    {
        switch(state.id)
        {
            case 2:
            UpdateMainState();
            break;
        }
    }

//Init
    private void BuildScreens()
    {
        BuildScreen(startScreenPrefab);
        BuildScreen(mainScreenPrefab);
        BuildScreen(rewardScreenPrefab);
        BuildScreen(endScreenPrefab);

        GameObject goSM = Instantiate(soundManagerPrefab);
        // SoundManager sm = goSM.GetComponent<SoundManager>(); 
        // sm.Init(stateManager);
    }

    private void BuildScreen(GameObject screenPrefab)
    {
        GameObject ui = Instantiate(screenPrefab);
        IScreen screen = ui.GetComponent<IScreen>();
        screen.Init(stateManager);

        screens.Add(screen.GetState(),screen);
    }

    private void BuildLevel(Level level) 
    {
        foreach(PuzzlePiece puzzle in level.LeftSide)
            {
                GameObject clone = Instantiate(puzzlePrefab);
                PuzzleController pc = clone.GetComponent<PuzzleController>();
                pc.Init(puzzle);
                leftPuzzlePool.Add(pc);
                puzzlesToSpawnPool.Add(pc);
                puzzleMap.Add(puzzle,pc);

                clone.SetActive(false);
            }

            foreach(PuzzlePiece puzzle in level.RightSide)
            {
                GameObject clone = Instantiate(puzzlePrefab);
                PuzzleController pc = clone.GetComponent<PuzzleController>();
                pc.Init(puzzle);
                rightPuzzlePool.Add(pc);
                puzzlesToSpawnPool.Add(pc);
                puzzleMap.Add(puzzle,pc);

                clone.SetActive(false);
            }
    }

    private void BuildPlayers()
    {
        foreach(PlayerModel player in playerModels)
        {
            GameObject clone = Instantiate(playerPrefab);
            PlayerController pc = clone.GetComponent<PlayerController>();
            pc.Init(player);
            players.Add(player,pc);
        }
    }
//*****************************************************


//Event
    private void RegisterActions()
    {
        stateManager.OnStateChange += HandleStates;

        foreach(PuzzlePiece piece in currentLevel.LeftSide)
        {
            piece.OnSelected += PieceSelected;
        }

        foreach(PuzzlePiece piece in currentLevel.RightSide)
        {
            piece.OnSelected += PieceSelected;
        }
    }

    private void UnregisterActions()
    {
        foreach(PuzzlePiece piece in currentLevel.LeftSide)
        {
            piece.OnSelected -= PieceSelected;
        }

        foreach(PuzzlePiece piece in currentLevel.RightSide)
        {
            piece.OnSelected -= PieceSelected;
        }
    }
//*****************************************************

//Start
///*****************************************************

//Main
    private MainScreen mainScreen;
    private int MAX_STRIKES = 3;
    private int currentStrikes;
    private int score;
    private float time = 0;
    private bool failed = false, isSpawningLeft = false, isSpawningRight = false;
    [SerializeField] 
    private float spawnTime = 0.6f;
    private void HandelMainState()
    {
        if(mainScreen == null)
        {
            mainScreen = (MainScreen) screens[stateManager.CurrentState];
        }
    
        if(mainScreen == null)
        {
            Debug.LogWarning("MainScreen is not where it needs to be");
            return;
        }

        currentStrikes = 0;
        score = 0;
        failed = false;
        isSpawningLeft = true;
        isSpawningRight = true;
        mainScreen.RoundTime = currentLevel.RoundTime;

        mainScreen.SetVisable(true);
        mainScreen.HideStrikes();
        mainScreen.StartTimer();
        //alow Player movement
    }

    private void UpdateMainState()
    {
        if(puzzlesToSpawnPool.Count > 0)
        {
            SpawnParts();
        }

        //End Game
        if(currentStrikes >= MAX_STRIKES)
        {
            failed = true;
            stateManager.StateChange(states[3]);
        }

        if(mainScreen.RoundOver)
        {
            stateManager.StateChange(states[4]); //lose
        }

        if(mainScreen.HeartFillAmout() >= 1f)
        {
            stateManager.StateChange(states[3]); //win
        }
    }

    private void SpawnParts()
    {
        if(!spawnTimer.IsLocked())
        {
            spawnTimer.SetLock(true);
            spawnTimer.SetTimer(spawnTime);
        }

        if(spawnTimer.IsLocked())
        {
            spawnTimer.RecordTime(Time.deltaTime);
        }

        if(spawnTimer.IsDone())
        {
            
            spawnTimer.SetLock(false);

            puzzlesToSpawnPool = Shuffle(puzzlesToSpawnPool);
            PuzzleController spawn = puzzlesToSpawnPool[0];

            if(isSpawningLeft && spawn.IsLeftSide())
            {
                puzzlesInPlayPool.Add(spawn);
            
                spawn.SetVisable(true);
                spawn.SetActive(true);

                puzzlesToSpawnPool.Remove(spawn);
            }

            if(isSpawningRight && !spawn.IsLeftSide())
            {
                puzzlesInPlayPool.Add(spawn);
            
                spawn.SetVisable(true);
                spawn.SetActive(true);

                puzzlesToSpawnPool.Remove(spawn);
            }
        }
    }

    private void DisplaySpawned()
    {
        foreach(PuzzleController pc in puzzlesInPlayPool)
        {
            pc.SetVisable(true);
            pc.SetActive(true);
        }
    }

    private int selected = 0;
    private PuzzlePiece leftPick,rightPick;
    private void PieceSelected(PuzzlePiece piece)
    {
        Debug.Log("this the one pop? " + piece.ID);

        if(stateManager.CurrentState != states[2])
        {
            return;
        }

        audioSource.clip = buttonSound;
        audioSource.Play();

        if(selected == players.Count)
        {
            return;
        }

        selected++;

        PuzzleController currentPuzzle = puzzleMap[piece];

        if(piece.isLeftSide)
        {
            isSpawningLeft = false;
            leftPick = piece;
            foreach(PuzzleController puz in puzzlesInPlayPool)
            {
                if(puz.IsLeftSide())
                {
                    puz.SetActive(false);
                    puz.SetVisable(false);
                }
            }
        } else {
            isSpawningRight = false; 
            rightPick = piece; 
            foreach(PuzzleController puz in rightPuzzlePool)
            {
                puz.SetActive(false);
                puz.SetVisable(false);
            }
        }

        currentPuzzle.SetVisable(true);
        puzzlesInPlayPool.Remove(currentPuzzle);

        if(selected == players.Count)
        {
            if(leftPick.ID == rightPick.ID)
            {   
                winLoseAudio.clip = correctSound;
                winLoseAudio.Play();

                mainScreen.FillHeart(.2f);
                mainScreen.AddTime(0);
            } else { 
                winLoseAudio.clip = wrongSount; 
                winLoseAudio.Play();
            }

            foreach(PlayerModel model in playerModels)
            {
                model.HasSelected = false;
            }

            PuzzleController LcurrentPuzzle = puzzleMap[leftPick];
            PuzzleController RcurrentPuzzle = puzzleMap[rightPick];

            LcurrentPuzzle.SetVisable(false);
            RcurrentPuzzle.SetVisable(false);

            leftPick  = null;
            rightPick = null;

            isSpawningRight = true;
            isSpawningLeft  = true;

            DisplaySpawned();

            selected = 0;
        }
    }
//*****************************************************

//Reward
    private RewardScreen rewardScreen;
    private void HandelRewardState()
    {
        if(rewardScreen == null)
        {
            Debug.Log(screens[stateManager.CurrentState]);
            rewardScreen = (RewardScreen) screens[states[3]];
        }

        if(rewardScreen == null)
        {
            Debug.LogWarning("RewardScreen is not where it needs to be");
            return;
        }

        rewardScreen.SetVisable(true);

        wallL.SetActive(false);
        wallR.SetActive(false);
        bridge.SetActive(true);
        bridgeWall.SetActive(true);
    }
//*****************************************************

//End
    private EndScreen endScreen;
    private void HandelEndScreen()
    {
        if(endScreen == null)
        {
            Debug.Log(screens[stateManager.CurrentState]);
            endScreen = (EndScreen) screens[states[4]];
        }

        if(endScreen == null)
        {
            Debug.LogWarning("endScreen is not where it needs to be");
            return;
        }

        endScreen.SetVisable(true);
    }
//*****************************************************


    private System.Random rng = new System.Random();  

    private List<PuzzleController> Shuffle(List<PuzzleController> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            PuzzleController value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }

        return list;  
    }
}
