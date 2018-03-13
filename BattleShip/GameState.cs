using System;

namespace BattleShip
{
	[Serializable]
	public class GameState
	{
		private int enemySeconds;
		private int playerSeconds;
		private bool? Difficulty;
		private String PlayerName;
		private UserPlayer user;
		private Player enemy;
        private String[] drawElements;
        private bool gameInProgress;

		public GameState(int enemySeconds,
			int playerSeconds,
			bool? Difficulty,
			String PlayerName,
			UserPlayer user,
			Player enemy,
            String[] drawElements,
            bool gameInProgress)
		{
			this.enemySeconds = enemySeconds;
			this.playerSeconds = playerSeconds;
			this.Difficulty = Difficulty;
			this.PlayerName = PlayerName;
			this.user = user;
			this.enemy = enemy;
            this.drawElements = drawElements;
            this.gameInProgress = gameInProgress;
		}

        public String toString()
        {
            return (playerSeconds.ToString() + " " + Difficulty + " " + PlayerName + " " + user + " " + enemy + " " + drawElements + " " + gameInProgress);
        }

		public int getEnemySeconds()
		{
			return this.enemySeconds;
		}

		public int getPlayerSeconds()
		{
			return this.playerSeconds;
		}

		public bool? getDifficulty()
		{
			return this.Difficulty;
		}

		public String getPlayerName()
		{
			return this.PlayerName;
		}

		public UserPlayer getUser()
		{
			return this.user;
		}

		public Player getEnemy()
		{
			return this.enemy;
		}

        public String[] getDrawElements()
        {
            return this.drawElements;
        }

        public bool getGameInProgress()
        {
            return this.gameInProgress;
        }

		public void setEnemySeconds(int enemySeconds)
		{
			this.enemySeconds = enemySeconds;
		}

		public void setPlayerSeconds(int playerSeconds)
		{
			this.playerSeconds = playerSeconds;
		}

		public void setDifficulty(bool? Difficulty)
		{
			this.Difficulty = Difficulty;
		}

		public void setPlayerName(String PlayerName)
		{
			this.PlayerName = PlayerName;
		}

		public void setUser(UserPlayer user)
		{
			this.user = user;
		}

		public void setEnemy(Player enemy)
		{
			this.enemy = enemy;
		}

        public void setDrawElements(String[] drawElements)
        {
            this.drawElements = drawElements;
        }

        public void setGameInProgress(bool gameInProgress)
        {
            this.gameInProgress = gameInProgress;
        }
	}
}