using System;

namespace Aula_26_05
{
    public class MyQueue
    {
        private int[] _queueSlots = { };

        public int GetLenghtOfMyQueue
        {
            get { return _queueSlots.Length; }
        }

        public string GetFirstItemQueue
        {
            get { return ((_queueSlots.Length > 0) ? _queueSlots[0].ToString() : "Nenhum item na fila"); }
        }

        public void QueueIn(int newValue)
        {
            int arrayLenght = (_queueSlots.Length > 0) ? (_queueSlots.Length + 1) : 1;

            int[] newItem = new int[arrayLenght];
            if (_queueSlots.Length > 0)
                for (int i = 0; i < arrayLenght - 1; i++)
                    newItem[i] = _queueSlots[i];

            newItem[arrayLenght - 1] = newValue;

            _queueSlots = newItem;
        }

        public string QueueOut()
        {
            int arrayLenght =
                (_queueSlots.Length == 0) ? _queueSlots.Length : _queueSlots.Length - 1;

            int[] newItem = new int[arrayLenght];

            if (arrayLenght > 0)
                for (int i = arrayLenght; i > 0; i--)
                    newItem[i - 1] = _queueSlots[i];

            _queueSlots = newItem;

            return (_queueSlots.Length > 0) ? _queueSlots[0].ToString() : "Fila vazia";
        }

        public void ClearMyQueue()
        {
            _queueSlots = new int[0];
        }

        public bool ContainInMyQueue(string value)
        {
            foreach (var item in _queueSlots)
            {
                if (item.ToString() == value)
                    return true;
            }
            return false;
        }
    }
}
