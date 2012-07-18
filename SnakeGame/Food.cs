using System;

namespace SnakeGame
{
    /// <summary>
    /// class สำหรับสร้าง Food object
    /// </summary>
    public class Food 
    {
        /// <summary>
        /// อ้างอิงถึง GrassField object
        /// </summary>
        private readonly GrassField grassField;

        /// <summary>
        /// เก็บค่าตำแหน่งของอาหารที่แสดงในหน้าจอ
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// constructor ของ Food class
        /// รับ GrassField object เข้ามา
        /// </summary>
        /// <param name="grassField">GrassField object</param>
        public Food(GrassField grassField)
        {
            this.grassField = grassField;
        }

        /// <summary>
        /// แสดงอาหารออกสู่หน้าจอเป็นตัวอักษร @
        /// โดยทำการสุ่มตำแหน่งออกมา
        /// </summary>
        public  void Render()
        {
            Random generateRandom = new Random();
            // Creates a new food.
            Point = new Point(generateRandom
                .Next(grassField.Left, grassField.Right),
                generateRandom.Next(grassField.Top, grassField.Bottom));
            //TODO not in point of snake

            Console.SetCursorPosition(Point.X, Point.Y);
            Console.Write("@");
        }
    }
}
