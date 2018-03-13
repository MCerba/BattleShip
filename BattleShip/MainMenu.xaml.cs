using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
     * Interaction logic for the Main Menu user control
     * @author Stanislav Yurchenko
     * @version 16/11/2017
     */
    public partial class UsrCtrlMainMenu : UserControl
    {
        public event EventHandler StartNewGameClick;
        public event EventHandler OptionsClick;
        public event EventHandler ContinueClick;
        public event EventHandler QuitClick;
        public UsrCtrlMainMenu()
        {
            InitializeComponent();
        }
		public String playerName;
		private void NewGameBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.StartNewGameClick != null)
            {
                this.StartNewGameClick(this, e);
				ContinueBtn.IsEnabled = true;
            }
        }

        private void OptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.OptionsClick != null)
            {
                this.OptionsClick(this, e);
            }
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.ContinueClick != null)
            {
                this.ContinueClick(this, e);
            }
        }
        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.QuitClick != null)
            {
                this.QuitClick(this, e);
            }
        }
        /*
         * Gets player name and removes the text field
         * @author Mihail Cerba
         * @version 05/12/2017
         */
		private void UserNameTxt_KeyDown(object sender, KeyEventArgs e)
		{
			String enter = e.Key.ToString();
			if (enter.Equals("Return"))
			{
				playerName = (sender as TextBox).Text.ToString();
				(sender as TextBox).Visibility = Visibility.Hidden;
                readRecord(this.playerName, sender, e);
			}
		}
        /*
         * Removes text from text field when it is in focus
         * @author Mihail Cerba
         * @version 05/12/2017
         */
		private void UserNameTxt_GotFocus(object sender, RoutedEventArgs e)
		{
			(sender as TextBox).Text = "";
		}

		private void LoadBtn_Click(object sender, RoutedEventArgs e)
		{
			BinaryFormatter reader = new BinaryFormatter();

			String path = "../../Properties/savedGames/" + this.playerName + ".txt";

            if (!File.Exists(path))
            {
                Display.Text = "No saved games found";
            }
            else
            {
                using (FileStream input = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    MainWindow.gameState = (GameState)reader.Deserialize(input);
                }

                this.StartNewGameClick(this, e);
            }
		}

		private void SaveBtn_Click(object sender, RoutedEventArgs e)
		{
            if (playerName == null)
            {

            }
            else
            {
                BinaryFormatter writer = new BinaryFormatter();

                String path = "../../Properties/savedGames/" + this.playerName + ".txt";

                using (FileStream output = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    writer.Serialize(output, MainWindow.gameState);
                }

                Display.Text = ("Game Saved\n" + MainWindow.gameState.toString());

            }
		}

        private void readRecord(String username, object sender, EventArgs e)
        {
            String[] record;
            try
            {
                record = File.ReadAllLines("../../Properties/scores/" + username + ".txt");
            }
            catch (FileNotFoundException fnfe)
            {
                createFlie(username);
                record = File.ReadAllLines("../../Properties/scores/" + username + ".txt");
            }

            StringBuilder list = new StringBuilder(20);

            foreach (String s in record)
            {
                list.Append(s + "\n");
            }

            MainWindow.list = list.ToString();
            MainWindow.playerName = username;
        }

        /*
         * Creates a file with the user's record
         */
        private static void createFlie(String username)
        {
            String path = ("../../Properties/scores/" + username + ".txt");
            String[] record = new String[2];

            record[0] = "Wins: 0";
            record[1] = "Losses: 0";
            
            File.WriteAllLines(path, record);
        }
    }
}
