namespace SimpleRobotLogic
{
    public class SimpleRobot
    {
        private int _col;
        private int _row;
        Direction _direction;

        public SimpleRobot()
        {
            _col = 2;
            _row = 2;
            _direction = Direction.Up;
        }

        public void Show()
        {
            Console.SetCursorPosition(_col, _row);
            var character = _direction switch
            {
                Direction.Down => 'V',
                Direction.Up => '^',
                Direction.Left => '<',
                Direction.Right => '>',
            };
            Console.Write(character);
        }

        public void TurnLeft()
        {
            var newDirection = (int) _direction + 3;
            _direction = (Direction)(newDirection % 4);
        }

        public bool Go()
        {
            var deltaRow = _direction switch
            {
                Direction.Up => -1,
                Direction.Down => 1,
                _ => 0,
            };
            var deltaCol = _direction switch
            {
                Direction.Left => -1,
                Direction.Right => 1,
                _ => 0,
            };
            var newRow = _row + deltaRow;
            var newCol = _col + deltaCol;
            var isOutsideBounds = newRow < 0 
                    || newRow >= Console.WindowWidth
                    || newCol < 0 
                    || newCol >= Console.WindowHeight;
            if (isOutsideBounds) return false;
            _col = newCol;
            _row = newRow;
            return true;
        }
    }
}
