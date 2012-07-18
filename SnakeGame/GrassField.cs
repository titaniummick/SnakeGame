using System;

namespace SnakeGame
{
    /// <summary>
    /// class สำหรับสร้าง GrassField Ojbect สนามหญ้า
    /// </summary>
	public class GrassField 
	{
        /// <summary>
        /// เก็บค่าระยะห่างจากด้านบนของหน้าจอจนถึงตำแหน่งด้านในของกำแพงด้านบน
        /// </summary>
	    public int Top { get;set; }


        /// <summary>
        /// เก็บค่าระยะห่างจากด้านบนของหน้าจอจนถึงตำแหน่งด้านในของกำแพงด้านล่าง
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// เก็บค่าระยะห่างจากด้านซ้ายของหน้าจอจนถึงตำแหน่งด้านในของกำแพงด้านซ้าย
        /// </summary>
		public int Left {get; set; }


        /// <summary>
        /// เก็บค่าระยะห่างจากด้านซ้ายของหน้าจอจนถึงตำแหน่งด้านในของกำแพงด้านขวา
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// แสดงสนามหญ้าออกสู่หน้าจอโดยมีกำแพงสี่ด้านเป็นรูปสี่เหลี่ยมพื้นผ้า และมีพื้นที่ว่างตรงกลาง
        /// </summary>
	    public  void Render()
	    {
	        const string borderStyle = "▒";
	        var length=  borderStyle.Length;
            
            //draw field
            const string borderTopBottom = "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒"; 
            const string borderLeftRight = "▒                        ▒";

            // Define window size.
            Left = (Console.WindowWidth - borderTopBottom.Length) / 2 + 1;
            Right = Left + borderTopBottom.Length - 3;
            Top = 3;
            Bottom = Console.WindowHeight - 4;

            // hide the cursor
            Console.CursorVisible = false;
            // draw the top border
            Console.SetCursorPosition((Console.WindowWidth - borderTopBottom.Length) / 2, 2);
            Console.Write(borderTopBottom);
            // draw the bottom border
            Console.SetCursorPosition((Console.WindowWidth - borderTopBottom.Length) / 2,
                                       Console.WindowHeight - 3);
            Console.Write(borderTopBottom);

            // draw the left and right border
            for (int i = 3; i < Console.WindowHeight - 3; i++) {
                Console.SetCursorPosition((Console.WindowWidth - borderTopBottom.Length) / 2, i);
                Console.Write(borderLeftRight);
            }
	    }
	}
}