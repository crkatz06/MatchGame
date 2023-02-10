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

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }
        //Method to randomly place emoji's on the grid
        private void SetUpGame()
        {
            //Create a list of eight pairs of emoji
            List<string> animalEmoji = new List<string>()
            {
                "🐙","🐙",
                "🐡", "🐡",
                "🐘", "🐘",
                "🐳", "🐳",
                "🐪", "🐪",
                "🦕", "🦕",
                "🦘", "🦘",
                "🦔", "🦔",
            };
            //Create a new random number generator
            Random random = new Random();

            //Find every TextBlock in the main grid and repeat the following statements for each of them
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count); //Picks a random # between 0 and remaining # of emoji in the list and calling it "index"
                string nextEmoji = animalEmoji[index];  //Use random number "index" to get a random emoji from the list
                textBlock.Text = nextEmoji; //Updates TextBlock with the random emoji from the list
                animalEmoji.RemoveAt(index);    //Ending cycle by removing the random emoji from the list
            }
        }
    }
}
