using System;

namespace SnakeGame
{
    /// <summary>
    /// class สำหรับสร้าง ScoreBoard object
    /// </summary>
	public class ScoreBoard 
	{
        /// <summary>
        /// อ้างอิง GrassField object
        /// </summary>
	    private readonly GrassField grassField;

        /// <summary>
        /// เก็บค่าคะแนนปัจจุบันของเกม
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// constructor ของ ScoreBoard class 
        /// รับค่า GrassField object เข้ามา
        /// </summary>
        /// <param name="grassField">GrassField object</param>
        public ScoreBoard(GrassField grassField)
        {
            this.grassField = grassField;
            Score = 0;
        }

        /// <summary>
        /// แสดงค่าคะแนนของผู้เล่นออกสู่หน้าจอเป็นข้อความและตัวเลข
        /// </summary>
	    public  void Render()
	    {
            Console.SetCursorPosition(grassField.Right + 3, 
                Console.WindowHeight / 2);
            Console.Write("SCORE : {0}", Score);
	    }
	}
}
