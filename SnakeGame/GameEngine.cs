using System;
using System.Threading;

namespace SnakeGame
{
    /// <summary>
    /// class สำหรับเป็นจุดเริ่มต้นของเกม (Main method)
    /// และสำหรับสั่งให้เกมมีการทำงานซ้ำ เพื่อให้งูเเคลื่อนที่ไปเรื่อยๆ 
    /// รับ keyboard input จากผู้ใช้เพื่อเปลี่ยนทิศทางการเคลื่อนที่ของงู
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// อ้างอิงถึง GrassField object
        /// </summary>
        static GrassField grassField;

        /// <summary>
        /// อ้างอิงถึง Snake object
        /// </summary>
        static Snake snake;

        /// <summary>
        /// อ้างอิงถึง Food object
        /// </summary>
        static Food food;

        /// <summary>
        /// อ้างอิงถึง ScoreBoard object
        /// </summary>
        static ScoreBoard scoreBoard;

        /// <summary>
        /// อ้างอิงถึงปุ่มที่ผู้เล่นได้กด
        /// </summary>
        static ConsoleKey keyboardInput;

        /// <summary>
        /// จุดเริ่มต้นของ Game
        /// </summary>
        public static void Main() {
            Console.CursorVisible = false;
            grassField = new GrassField();
            snake = new Snake(grassField);
            food = new Food(grassField);
            snake.Food = food;
            scoreBoard = new ScoreBoard(grassField);

            grassField.Render();
            snake.Render();
            food.Render();
            scoreBoard.Render();

            Loop();
        }

        /// <summary>
        /// ทำให้เกมมีการทำงานซ้ำ สั่งให้งูเคลื่อนที่ข้างหน้าไปเรื่อย แสดงอาหารให้งูเข้าไปจับกินได้
        /// </summary>
        public static void Loop() {
            while (true) {
                Thread.Sleep(1); //sleep for 1 second

                if (Console.KeyAvailable) {
                    keyboardInput = Console.ReadKey(true).Key; // get key input
                    snake.LastKeyBoardInput = keyboardInput;
                }
                snake.Forward();

                if (snake.IsCollide()) {
                    Console.SetCursorPosition(grassField.Left,
                        grassField.Bottom + 2);
                    Console.WriteLine("Game Over");
                    return;
                }

                if (snake.IsEatFood()) {
                    food = new Food(grassField);
                    snake.Food = food;
                    food.Render();

                    snake.Lengthen();
                }
                snake.Render();
            }
        }
    }
}
