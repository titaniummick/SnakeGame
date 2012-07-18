namespace SnakeGame
{
    /// <summary>
    /// class สำหรับสร้าง Point object ตำแหน่งของจุดบนหน้าจอ คู่ลำดับ x,y (x,y)
    /// </summary>
    public class Point
    {
        /// <summary>
        /// ค่าในแนวแกน X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// ค่าในแนวแกน Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// constructor ของ Point class
        /// </summary>
        /// <param name="x">ค่า x</param>
        /// <param name="y">ค่า y</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
