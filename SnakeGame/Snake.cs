using System;
using System.Collections.Generic;

namespace SnakeGame
{
    /// <summary>
    /// class สำหรับสร้าง Snake object
    /// </summary>
    public class Snake 
    {
        /// <summary>
        /// สำหรับอ้างอิงถึง GlassField object
        /// </summary>
        private readonly GrassField grassField;
       
        /// <summary>
        /// เก็บค่าจุดที่หางของงูก่อนที่จะ update point
        /// </summary>
        private Point tailPoint;

        /// <summary>
        /// เก็บค่าจุดใหม่ที่หัวของงูกำลังมั่งหน้าไป
        /// </summary>
        private Point direction;

        /// <summary>
        /// ปุ่ม key board ล่าสุดที่ผู้ใช้กดได้แก่ up down left rihgt arrow
        /// </summary>
        public ConsoleKey LastKeyBoardInput { get; set; }

        /// <summary>
        /// จุดของหัว ลำตัว และหางของงู
        /// </summary>
        public List<Point> Points { get; set; }

        /// <summary>
        /// property อ้างอิงถึง Food Object ไว้สำหรับตรวจสอบว่างูกินอาหารแล้วหรือไม่
        /// </summary>
        public Food Food { get; set; }

        /// <summary>
        /// constructor ของ Snack class รับ GrassField object เข้ามา
        /// </summary>
        /// <param name="grassField">GrassField object</param>
        public Snake(GrassField grassField) {
            this.grassField = grassField;

            LastKeyBoardInput = ConsoleKey.RightArrow;

            Points = new List<Point>();

            Points.Add(new Point(4, 0)); // Head
            Points.Add(new Point(3, 0)); // Body
            Points.Add(new Point(2, 0)); // Body
            Points.Add(new Point(1, 0)); // Body
            Points.Add(new Point(0, 0)); // Tail

            direction = new Point(0, 0);
        }

        /// <summary>
        /// เลื่อนค่าตำแหน่งในตัวของงูไปข้างหน้า
        /// </summary>
        private void UpdatePoint() {
            tailPoint = Points[Points.Count - 1];

            //update ค่าภายใน
            for (int i = Points.Count - 1; i >= 0; i--) {
                if (i == 0) {
                    // Is this the head of the snake?
                    // Move the snake to its new direction.
                    Points[0] = new Point(Points[0].X + direction.X,
                                          Points[0].Y + direction.Y);
                }
                else {
                    // Track the body.
                    //
                    // [n].x <- [n-1].x
                    // [n].y <- [n-1].y
                    // 
                    // example:
                    //     [4].x = [3].x : [4].y = [3].y
                    //     [3].x = [2].x : [3].y = [2].y
                    //     [2].x = [1].x : [2].y = [1].y
                    //     [1].x = [0].x : [1].y = [0].y
                    Points[i] = new Point(Points[i - 1].X,
                                          Points[i - 1].Y);
                }
            }
        }

        /// <summary>
        /// สั่งให้งูเคลื่อนที่ไปข้างหน้า
        /// </summary>
        public void Forward() {
            switch (LastKeyBoardInput)
            {   
                case ConsoleKey.UpArrow:
                    direction.X = 0; // same direction  ค่า x คงที่ ค่า y เปลี่ยน
                    direction.Y = 1; // above.
                    break;

                case ConsoleKey.DownArrow:
                    direction.X = 0; // same direction
                    direction.Y = -1; // below.
                    break;

                case ConsoleKey.LeftArrow:
                    direction.X = -1; // left.
                    direction.Y = 0;  // same direction
                    break;

                case ConsoleKey.RightArrow:
                    direction.X = 1; // right.
                    direction.Y = 0;  // same direction
                    break;
            }
            UpdatePoint();
        }

        /// <summary>
        /// ตรวจสอบว่างูชนกับกำแพงของสนามหญ้า (GrassField) 
        /// หรือชนตัวมันเองแล้วหรือยัง
        /// </summary>
        /// <returns>true เมื่องูได้ชนกำแพงหรือตัวมันเอง</returns>
        public bool IsCollide() {
            int headX = Points[0].X + grassField.Left; // head_x + window_left
            int headY = Points[0].Y + grassField.Top; // head_y + window_top

            // Is out of boundary?
            if ((headX > grassField.Right)
                || (headY < grassField.Top)) {
                return true;
            }

            for (int i = 1; i <= Points.Count - 1; i++) {
                // Is the head of the snake collided to the body?
                if (headX == (Points[i].X + grassField.Left)
                    && headY == (Points[i].Y + grassField.Top)) {
                    return true;
                }
            }
            return false;
        }
 
        /// <summary>
        /// ตรวจสอบว่างูได้กินอาหารไปแล้วหรือไม่
        /// </summary>
        /// <returns>true เมื่องูได้กินอาหารไปแล้ว</returns>
        public bool IsEatFood() {
            if (Points[0].X + grassField.Left == Food.Point.X &&
          Points[0].Y + grassField.Top == Food.Point.Y)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// ยืดตัวของงูให้ยาวขึ้นไปหนึ่งจุด
        /// </summary>
        public void Lengthen() {
            Points.Add(new Point(tailPoint.X, tailPoint.Y));
        }

        /// <summary>
        /// แสดงตัวส่วนหัว ลำตัว และหางของงูออกสู่หน้าจอโดยใช้ตัวอักษร #
        /// </summary>
        public  void Render() {
            if (tailPoint != null) {
                // remove the trail ลบหางก่อนแล้วค่อยวาดหัว
                Console.SetCursorPosition(tailPoint.X + grassField.Left,
                                          tailPoint.Y + grassField.Top);
                Console.Write(" ");
            }

            //draw snake
            foreach (Point point in Points) {
                Console.SetCursorPosition(point.X + grassField.Left,
                   point.Y + grassField.Top);
                Console.Write("#");
            }
        }
    }
}
