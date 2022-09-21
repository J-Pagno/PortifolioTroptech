namespace E03_Bonus
{
    public class Seat
    {
        private int _seatId;

        public bool isPriority { get; }

        public bool isBeingUsed { get; set; }

        public int seatId
        {
            get { return _seatId; }
        }

        public Seat(int setSeatId)
        {
            if (_seatId % 2 == 0 && _seatId > 5)
                isPriority = true;

            _seatId = setSeatId;

            isBeingUsed = false;
        }
    }
}
