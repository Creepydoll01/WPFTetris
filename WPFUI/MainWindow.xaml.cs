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
using WPFUI;



namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        static public Game NewGame;
       
        

        public MainWindow()
        {
            
            InitializeComponent();
            
           
            this.KeyDown += UI.MoveLeft;
            this.KeyDown += UI.MoveRight;
            this.KeyDown += UI.Rotate;
            
            UI.GenerateGrid(WPFTetrisGrid);
            UI.GenerateNextFigureGrid(NewFigureGrid);
            NewGame = new Game();
            NewGame.Play(Score);



        }

        

        
    }
}
