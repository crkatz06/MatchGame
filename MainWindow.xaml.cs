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

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;  //findingMatch tracks if user clicked on 1st emoji of a pair and is trying to find its match

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            if (findingMatch == false)  //Player clicked 1st emoji of pair so emoji is made invisible and keeps track of TextBlock if needed to be made visible again
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)   //Match found, second emoji made invisible;unclickable as 1st. Resets findingMatch so next emoji clicked
            {                                                       //is considered 1st of pair again
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else    //emoji clicked that does not match 1st, 1st made visible again and resets findingMatch
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
    }
}
