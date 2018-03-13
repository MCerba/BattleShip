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
     * Interaction logic for the Play Ground user control
     * @author Stanislav Yurchenko
     * @version 16/11/2017
     */
    public partial class UsrCtrlPlayGround : UserControl
    {
		public bool wonState = false;
        public System.Windows.Threading.DispatcherTimer PlayerTimer;
        public System.Windows.Threading.DispatcherTimer EnemyTimer;
		public GameState gameState;
        public int enemySeconds;
        public int playerSeconds;
        public bool? Difficulty;
        public String PlayerName;
        private UserPlayer user;
        private Player enemy;
        private String[] drawnElements = new String[5];
        private bool gameInProgress;
        public UsrCtrlPlayGround(GameState gameState)
        {
            InitializeComponent();
            if (gameState != null)
            {
                this.gameState = gameState;
                this.enemySeconds = this.gameState.getEnemySeconds();
                this.playerSeconds = this.gameState.getPlayerSeconds();
                this.Difficulty = this.gameState.getDifficulty();
                this.PlayerName = this.gameState.getPlayerName();
                this.user = this.gameState.getUser();
                this.enemy = this.gameState.getEnemy();
                this.drawnElements = this.gameState.getDrawElements();
                this.gameInProgress = this.gameState.getGameInProgress();
                if (this.gameInProgress)
                {
                    Mittelspiel();
                }
            }
		}

		public void updateGameState()
		{
            if (this.gameState != null)
            {
                this.gameState.setEnemySeconds(this.enemySeconds);
                this.gameState.setPlayerSeconds(this.playerSeconds);
                this.gameState.setDifficulty(this.Difficulty);
                this.gameState.setPlayerName(this.PlayerName);
                this.gameState.setUser(this.user);
                this.gameState.setEnemy(this.enemy);
                this.gameState.setDrawElements(this.drawnElements);
            }
		}

        /*
         * Hits the label on the enemy board
         * @author Stanislav Yurchenko
         * @version 05/12/2017
         */
        private void HitMouseDown(object sender, MouseButtonEventArgs e)
        {
            bool? state;
            Label lbl = sender as Label;
            lbl.Content = "X";
            int row = Grid.GetRow(lbl);
            int column = Grid.GetColumn(lbl);
            state = user.FireShot(row, column);
            if (state == null)
            {
                foreach (Ship s in enemy.GameGrid.ships)
                {
                    if (s.SinkShip())
                    {
                        DrawShip(s);
                    }

                }
                lbl.Foreground = Brushes.Red;
            }
            else if (state == true)
            {
                lbl.Foreground = Brushes.Red;
            }
            else
            {
                lbl.Foreground = Brushes.Black;
            }
            EnemyDrawHits();
            lbl.IsEnabled = false;
            if (!user.Win() && !enemy.Win())
            {
                enemy.Turn();
                PlayerDrawHits();
            } else if (user.Win())
            {
                Endspiel(true);
            } else if (enemy.Win())
            {
                Endspiel(false);
            }

        }
        /*
         * Show ships on enemy grid for debugging purposes
         * @author Stanislav Yurchenko
         * @version 05/12/2017
         */
        public void VisualiseShips()
        {
            foreach (Ship s in enemy.GameGrid.ships)
            {
                DrawShip(s);
            }
        }
        /*
         * Draw the ship sent to this method
         * @author Stanislav Yurchenko
         * @version 06/12/2017
         */
        private void DrawShip(Ship s)
        {
            bool neverDrawn = true;
            for (int i = 0; i < drawnElements.Length; i++)
            {
                if (drawnElements[i] == null)
                {
                    drawnElements[i] = s.GetName();
                }
                else if (s.GetName().Equals(drawnElements[i]))
                {
                    neverDrawn = false;
                }
            }
            if (neverDrawn)
            {
                int row;
                int column;
                BitmapImage img;
                column = s.Coordinates[0] % 10;
                row = s.Coordinates[0] / 10;
                img = new BitmapImage(new Uri(s.GetPath(), UriKind.Relative));
                Image image = new Image() { Source = img };
                Grid.SetRow(image, row);
                Grid.SetColumn(image, column);
                Grid.SetZIndex(image, 98);
                EnemyGrd.Children.Add(image);
                if (s.Vertical)
                {
                    image.SetValue(Grid.RowSpanProperty, s.GetLength());
                }
                else
                {
                    image.SetValue(Grid.ColumnSpanProperty, s.GetLength());
                }
            }
        }
        /*
         * Initiate the drag event by clicking the image
         * @author Stanislav Yurchenko
         * @version 30/11/2017
         */
        private void DragMouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            DataObject data = new DataObject(typeof(String), img.Name);
            // Check if the image exists and is dragged with the left button
            if (img != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(img, data, DragDropEffects.Move);
            }
        }
        /*
         * Initiate the drop event and if successful, move image from menu to board
         * @author Stanislav Yurchenko
         * @version 03/12/2017
         */
        private void DragAndDrop(object sender, DragEventArgs e)
        {
            Label lbl = sender as Label;
            // Find where the event was fired
            int row = Grid.GetRow(lbl);
            int column = Grid.GetColumn(lbl);
            Image img = new Image();
            // Get name of ship from the dragged content
            Ship s = GetShipReference(e.Data.GetData(typeof(String)) as String);
            // Get the image reference
            BitmapImage bitImage = new BitmapImage(new Uri(s.GetPath(), UriKind.Relative));
            img.Source = bitImage;
            if (s.Vertical)
            {
                img.SetValue(Grid.RowSpanProperty, s.GetLength());
            }
            else
            {
                img.SetValue(Grid.ColumnSpanProperty, s.GetLength());
            }
            try
            {
                user.GameGrid.AddShip(s, row, column);
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
            // Bind the image to the specific row and column
            Grid.SetRow(img, row);
            Grid.SetColumn(img, column);
            // Add the image to the board
            PlayerGrid.Children.Add(img);
            // Render the label inactive
            lbl.AllowDrop = false;
            // Remove ship image from menu, check all images in the grid
            foreach (Image menuShip in SeparationGrd.Children.OfType<Image>())
            {
                if (menuShip.Name.Equals(s.GetName()))
                {
                    SeparationGrd.Children.Remove(menuShip);
                    // Will complain about changing list otherwise
                    break;
                }
            }
            if (user.GameGrid.ShipsPlaced())
            {
                Mittelspiel();
            }

        }
        /*
         * Rotates the ship
         * @author Stanislav Yurchenko
         * @version 30/11/2017
         */
        private void Image_RightClick(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            Ship s = GetShipReference(img.Name);
            // Will turn the ship in previous position if clicked a second time. Tied to the vertical boolean in ship class.
            if (img.RenderTransform is RotateTransform)
            {
                if (s.Vertical)
                {
                    (img.RenderTransform as RotateTransform).Angle -= 90;
                    s.Vertical = false;
                }
                else
                {
                    (img.RenderTransform as RotateTransform).Angle += 90;
                    s.Vertical = true;
                }
            }
            // Liable to turn the ship pointing upwards on the first click
            else
            {
                img.RenderTransform = new RotateTransform(90);
                s.Vertical = true;

            }
        }
        /*
         * Helper method that searches through the array of ships for the appropriate one
         * @author Stanislav Yurchenko
         * @version 02/12/2017
         * @return ship object if found and null if not
         */
        private Ship GetShipReference(String shipName)
        {
            foreach (Ship s in user.GameGrid.ships)
            {
                if (s.GetName().Equals(shipName))
                {
                    return s;
                }
            }
            return null;
        }
        /*
         * Reads difficulty level and initialises enemy AI accordingly
         * @author Mihail Cerba
         * @author Stanislav Yurchenko
         * @version 05/12/2017
         */
        public void SetDifficulty()
        {
            if (Difficulty == null)
            {
                enemy = new EasyComputerPlayer();
            }
            else if (Difficulty == false)
            {
                enemy = new NormalComputerPlayer();
            }
            else if (Difficulty == true)
            {
                enemy = new HardComputerPlayer();
            }
        }
        /*
         * Part of the game where the difficulty is set, both players are initialised and the ships can be set on the board
         * @author Stanislav Yurchenko
         * @version 05/12/2017
         */
        public void Debut()
        {
            SetDifficulty();
            user = new UserPlayer(PlayerName, enemy);
            enemy.SetOpponent(user);
            //  this.VisualiseShips();
        }
        /*
         * Game flow for the part of the game where players take shots at each other
         * @author Mihail Cerba
         * @author Stanislav Yurchenko
         * @version 05/12/2017
         */
        public void Mittelspiel()
        {
            this.gameInProgress = true;

            foreach (UIElement lbl in EnemyGrd.Children)
            {
                if (lbl.GetType() == typeof(Label))
                {
                    lbl.IsEnabled = true;
                }
            }
        }
		/*
		 * Game flow for ending game.
		 * @author Stanislav Yurchenko
		 * @version 06/12/2017
		 */
        private void Endspiel(bool won) 
        {
            if (won)
            {
                MessageBox.Show("You won, " + user.Name);
            } else
            {
                MessageBox.Show("Computer won");
                this.user.gameLost();
            }

            writeFile(this.PlayerName, won);
        }

        /*
         * Writes the user's record in a file
         */
        private static void writeFile(String username, bool won)
        {
            String path = "../../Properties/scores/" + username + ".txt";
            String[] record = File.ReadAllLines(path);

            int wins = int.Parse(record[0].Substring(6));
            int losses = int.Parse(record[1].Substring(8));

            if (won)
                wins++;
            else
                losses++;

            record[0] = ("Wins: " + wins);
            record[1] = ("Losses: " + losses);

            File.WriteAllLines(path, record);

            StringBuilder list = new StringBuilder(20);

            foreach (String s in record)
            {
                list.Append(s + "\n");
            }

            MainWindow.list = list.ToString();
        }

        /*
         * Draws hits that are done on the player Grid
         * @author Stanislav Yurchenko
         * @version 05/12/2017
         */
        public void PlayerDrawHits()
        {
            Label lbl;
            int row;
            int column;
            for (int i = 0; i < user.GameGrid.hitLabels.Length; i++)
            {
                if (user.GameGrid.hitLabels[i])
                {
                    row = i / 10;
                    column = i % 10;
                    lbl = CheckAllChildren(PlayerGrid, row, column);
                    lbl.Content = "X";
                    foreach (Ship s in user.GameGrid.ships)
                    {
                        foreach (int j in s.Coordinates)
                        {
                            if (j == row * 10 + column)
                            {
                                lbl.Foreground = Brushes.Red;
                                Grid.SetZIndex(lbl, 99);
                            }
                        }
                    }
                }
            }
        }
        /*
         * Draws hits that are done on the enemy Grid
         * @author Stanislav Yurchenko
         * @version 05/12/2017
         */
        public void EnemyDrawHits()
        {
            Label lbl;
            int row;
            int column;
            bool? state;
            for (int i = 0; i < enemy.GameGrid.hitLabels.Length; i++)
            {
                if (enemy.GameGrid.hitLabels[i])
                {
                    row = i / 10;
                    column = i % 10;
                    lbl = CheckAllChildren(EnemyGrd, row, column);
                    lbl.Content = "X";
                    foreach (Ship s in enemy.GameGrid.ships)
                    {
                        foreach (int j in s.Coordinates)
                        {
                            if (j == row * 10 + column)
                            {
                                lbl.Foreground = Brushes.Red;
                                Grid.SetZIndex(lbl, 99);
                            }
                        }
                        if (s.SinkShip())
                        {
                            DrawShip(s);
                        }
                    }
                    lbl.IsEnabled = false;
                }
            }
        }
        /*
         * Runs through the given Grid and returns a label placed at the given row and column
         * @author Stanislav Yurchenko
         * @version 06/12/2017
         * @return label from the grid at the position passed to method
         */
        public Label CheckAllChildren(Grid g, int row, int column)
        {
            foreach (UIElement lbl in g.Children)
            {
                if (Grid.GetRow(lbl) == row && Grid.GetColumn(lbl) == column && lbl.GetType() == typeof(Label))
                {
                    return lbl as Label;
                }
            }
            return null;
        }
    }
}
