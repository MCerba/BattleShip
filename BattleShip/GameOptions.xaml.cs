using System;
using System.Collections.Generic;
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
     * Interaction logic for the Options Menu
     * @author Stanislav Yurchenko
     * @version 20/11/2017
     */
    public partial class UsrCtrlGameOptions : UserControl
    {
        public UsrCtrlGameOptions()
        {
            InitializeComponent();
        }
		public bool? difficulty = null;

        private void EasyBtn_Checked(object sender, RoutedEventArgs e)
        {
			difficulty = null;
        }

        private void MediumBtn_Checked(object sender, RoutedEventArgs e)
        {
			difficulty = false;
        }

        private void HardBtn_Checked(object sender, RoutedEventArgs e)
        {
			difficulty = true;
        }
        
    }
}
