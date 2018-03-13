using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShip
{
    /*
     * Main Window behaviour
     * @author Stanislav Yurchenko
     * @version 16/11/2017
     */
    public partial class MainWindow : Window
    {
        public UsrCtrlMainMenu MainMenu = new UsrCtrlMainMenu();
        public static GameState gameState;
		public UsrCtrlPlayGround PlayGround = new UsrCtrlPlayGround(gameState);
        public UsrCtrlGameOptions GameOptions = new UsrCtrlGameOptions();
        public static String list;
        public static String playerName;
        public MainWindow()
        {
            InitializeComponent();
            this.MenuGameGrd.Content = MainMenu;
            MainMenu.StartNewGameClick += new EventHandler(StartNewGame);
            MainMenu.OptionsClick += new EventHandler(Options);
            MainMenu.ContinueClick += new EventHandler(Continue);
            MainMenu.QuitClick += new EventHandler(Quit);
        }
        private void Options(object sender, EventArgs e)
        {
            this.MenuGameGrd.Content = GameOptions;
            MainMenuBtn.IsEnabled = true;
        }
        private void StartNewGame(object sender, EventArgs e)
        {
            if (gameState == null)
            {
                gameState = new GameState(0, 0, null, null, null, null, new String[5], false);
            }
            this.PlayGround = new UsrCtrlPlayGround(gameState);
            this.MenuGameGrd.Content = PlayGround;
			PlayGround.PlayerName = MainMenu.playerName;
			PlayGround.Difficulty = GameOptions.difficulty;
            PlayGround.Debut();
			MainMenu.OptBtn.IsEnabled = false;
            MainMenuBtn.IsEnabled = true;
        }
        private void Continue(object sender, EventArgs e)
        {
            this.MenuGameGrd.Content = PlayGround;
            MainMenuBtn.IsEnabled = true;
        }
        private void MainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            this.MenuGameGrd.Content = MainMenu;
            MainMenuBtn.IsEnabled = false;
			if (PlayGround.wonState)
			{
				MainMenu.OptBtn.IsEnabled = true;
				MainMenu.ContinueBtn.IsEnabled = false;
				this.PlayGround = new UsrCtrlPlayGround(gameState);
			}
			PlayGround.updateGameState();
			gameState = PlayGround.gameState;
        }
        private void Quit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshScoresButton_Click(object sender, RoutedEventArgs e)
        {
            Scores.Text = list;
            DisplayName.Content = playerName;
        }
        /*
         * Show all ships cheatcode
         * @author Stanislav Yurchenko
         * @version 06/12/2017
         */
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString().Equals("LeftCtrl"))
            {
                PlayGround.VisualiseShips();
            }
        }
    }
}
